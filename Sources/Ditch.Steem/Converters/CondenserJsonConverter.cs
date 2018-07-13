using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ditch.Core.Converters;
using Ditch.Core.Models;
using Ditch.Steem.Models;
using Ditch.Steem.Operations;

namespace Ditch.Steem.Converters
{
    public class CondenserJsonConverter : JsonConverter
    {
        protected Dictionary<string, (Func<JsonReader, Type, object, JsonSerializer, object>, Action<JsonWriter, JsonSerializer, object>)> ExtendedTypeNames;


        public CondenserJsonConverter()
        {
            InitDictionary();
        }

        protected virtual void InitDictionary()
        {
            ExtendedTypeNames = new Dictionary<string, (Func<JsonReader, Type, object, JsonSerializer, object>, Action<JsonWriter, JsonSerializer, object>)>
                {
                    {nameof(Asset), (ReadAsset, WriteAsset)},
                    {nameof(LegacyAsset), (ReadLegacyAsset, WriteLegacyAsset)},
                    {nameof(Operation), (ReadOperation, WriteOperation)},
                    {nameof(BroadcastTransactionArgs), (ReadBroadcastTransactionArgs, WriteBroadcastTransactionArgs)},
                    {nameof(GetActiveWitnessesReturn), (ReadGetActiveWitnessesReturn, WriteGetActiveWitnessesReturn)},
                    {nameof(GetPotentialSignaturesArgs), (ReadGetPotentialSignaturesArgs, WriteGetPotentialSignaturesArgs)},
                    {nameof(GetPotentialSignaturesReturn), (ReadGetPotentialSignaturesReturn, WriteGetPotentialSignaturesReturn)},
                    {nameof(GetTransactionHexArgs), (ReadGetTransactionHexArgs, WriteGetTransactionHexArgs)},
                    {nameof(GetRequiredSignaturesArgs), (ReadGetRequiredSignaturesArgs, WriteGetRequiredSignaturesArgs)},
                    {nameof(VerifyAuthorityArgs), (ReadVerifyAuthorityArgs, WriteVerifyAuthorityArgs)},
                    {nameof(VerifyAuthorityReturn), (ReadVerifyAuthorityReturn, WriteVerifyAuthorityReturn)},
                    {nameof(CommentPayoutBeneficiaries), (ReadCommentPayoutBeneficiaries, WriteCommentPayoutBeneficiaries)},
                    {nameof(GetAccountHistoryReturn), (ReadGetAccountHistoryReturn, WriteGetAccountHistoryReturn)},
                    //{nameof(), (Read, Write)},
                };
        }


        public override bool CanConvert(Type objectType)
        {
            return ExtendedTypeNames.ContainsKey(objectType.Name) || 
                   objectType.GetInterfaces().Contains(typeof(ICustomJson));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (ExtendedTypeNames.ContainsKey(objectType.Name))
                return ExtendedTypeNames[objectType.Name].Item1(reader, objectType, existingValue, serializer);

            var entity = (ICustomJson)Activator.CreateInstance(objectType);
            entity.ReadJson(reader, serializer);
            return entity;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var tName = value.GetType().Name;
            if (ExtendedTypeNames.ContainsKey(tName))
                ExtendedTypeNames[tName].Item2(writer, serializer, value);
            else
                ((ICustomJson)value).WriteJson(writer, serializer);
        }


        #region Asset

        protected virtual void WriteAsset(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (Asset)obj;
            writer.WriteValue(value.ToOldFormatString());
        }

        protected virtual Asset ReadAsset(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var val = reader.Value.ToString();
            var asset = new Asset();
            asset.FromOldFormat(val);
            return asset;
        }

        #endregion

        #region LegacyAsset

        protected virtual void WriteLegacyAsset(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (LegacyAsset)obj;
            writer.WriteValue(value.ToOldFormatString());
        }

        protected virtual LegacyAsset ReadLegacyAsset(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var val = reader.Value.ToString();
            var asset = new LegacyAsset();
            asset.FromOldFormat(val);
            return asset;
        }

        #endregion

        #region Operation

        protected virtual void WriteOperation(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            BaseOperation value = (Operation)obj;
            writer.WriteStartArray();
            var name = value.TypeName;
            if (name.EndsWith("_operation"))
                name = name.Remove(name.Length - 10);
            writer.WriteValue(name);
            serializer.Serialize(writer, value);
            writer.WriteEndArray();

        }

        protected virtual Operation ReadOperation(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var opName = reader.ReadAsString();
            reader.Read();
            if (!opName.EndsWith("_operation"))
                opName += "_operation";
            var op = DeserializeOperation(reader, serializer, opName);

            reader.Read();

            return new Operation(op);
        }

        protected BaseOperation DeserializeOperation(JsonReader reader, JsonSerializer serializer, string opName)
        {
            switch (opName)
            {
                case VoteOperation.OperationName:
                    return serializer.Deserialize<VoteOperation>(reader);
                case CommentOperation.OperationName:
                    return serializer.Deserialize<CommentOperation>(reader);

                case TransferOperation.OperationName:
                    return serializer.Deserialize<TransferOperation>(reader);
                case TransferToVestingOperation.OperationName:
                    return serializer.Deserialize<TransferToVestingOperation>(reader);
                case WithdrawVestingOperation.OperationName:
                    return serializer.Deserialize<WithdrawVestingOperation>(reader);

                //LimitOrderCreate,
                //LimitOrderCancel,

                //FeedPublish,
                //Convert,

                case AccountCreateOperation.OperationName:
                    return serializer.Deserialize<AccountCreateOperation>(reader);
                case AccountUpdateOperation.OperationName:
                    return serializer.Deserialize<AccountUpdateOperation>(reader);

                case WitnessUpdateOperation.OperationName:
                    return serializer.Deserialize<WitnessUpdateOperation>(reader);
                //AccountWitnessVote,
                //AccountWitnessProxy,

                //Pow,

                //Custom,

                //ReportOverProduction,

                case DeleteCommentOperation.OperationName:
                    return serializer.Deserialize<DeleteCommentOperation>(reader);
                case CustomJsonOperation.OperationName:
                    return serializer.Deserialize<CustomJsonOperation>(reader);
                case CommentOptionsOperation.OperationName:
                    return serializer.Deserialize<CommentOptionsOperation>(reader);
                //SetWithdrawVestingRoute,
                //LimitOrderCreate2,
                //ClaimAccount,
                //CreateClaimedAccount,
                //RequestAccountRecovery,
                //RecoverAccount,
                //ChangeRecoveryAccount,
                //EscrowTransfer,
                //EscrowDispute,
                //EscrowRelease,
                //Pow2,
                //EscrowApprove,
                //TransferToSavings,
                //TransferFromSavings,
                //CancelTransferFromSavings,
                //CustomBinary,
                //DeclineVotingRights,
                //ResetAccount,
                //SetResetAccount,
                case ClaimRewardBalanceOperation.OperationName:
                    return serializer.Deserialize<ClaimRewardBalanceOperation>(reader);
                //DelegateVestingShares,
                //AccountCreateWithDelegation,
                //WitnessSetProperties,

                //# ifdef STEEM_ENABLE_SMT
                //        /// SMT operations
                //        ClaimRewardBalance2,

                //        SmtSetup,
                //        SmtCapReveal,
                //        SmtRefund,
                //        SmtSetupEmissions,
                //        SmtSetSetupParameters,
                //        SmtSetRuntimeParameters,
                //        SmtCreate,
                //#endif
                //// virtual operations below this point
                //FillConvertRequest,
                //AuthorReward,
                //CurationReward,
                //CommentReward,
                //LiquidityReward,
                //Interest,
                //FillVestingWithdraw,
                //FillOrder,
                //ShutdownWitness,
                //FillTransferFromSavings,
                //Hardfork,
                //CommentPayoutUpdate,
                //ReturnVestingDelegation,
                //CommentBenefactorReward,
                //ProducerReward

                default:
                    return new UnsupportedOperation(opName, serializer.Deserialize<JObject>(reader));
            }
        }

        #endregion

        #region BroadcastTransactionArgs

        protected virtual void WriteBroadcastTransactionArgs(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (BroadcastTransactionArgs)obj;
            writer.WriteStartArray();
            serializer.Serialize(writer, value.Trx);
            writer.WriteEndArray();
        }

        protected virtual Operation ReadBroadcastTransactionArgs(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region GetActiveWitnessesReturn

        protected virtual void WriteGetActiveWitnessesReturn(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (GetActiveWitnessesReturn)obj;
            serializer.Serialize(writer, value.Witnesses);
        }

        protected virtual GetActiveWitnessesReturn ReadGetActiveWitnessesReturn(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            return new GetActiveWitnessesReturn
            {
                Witnesses = serializer.Deserialize<string[]>(reader)
            };
        }

        #endregion

        #region GetPotentialSignaturesArgs

        protected virtual void WriteGetPotentialSignaturesArgs(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (GetPotentialSignaturesArgs)obj;
            serializer.Serialize(writer, value.Trx);
        }

        protected virtual GetPotentialSignaturesArgs ReadGetPotentialSignaturesArgs(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new GetPotentialSignaturesArgs
            {
                Trx = serializer.Deserialize<SignedTransaction>(reader)
            };
        }

        #endregion

        #region GetPotentialSignaturesReturn

        protected virtual void WriteGetPotentialSignaturesReturn(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (GetPotentialSignaturesReturn)obj;
            serializer.Serialize(writer, value.Keys);
        }

        protected virtual GetPotentialSignaturesReturn ReadGetPotentialSignaturesReturn(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new GetPotentialSignaturesReturn
            {
                Keys = serializer.Deserialize<PublicKeyType[]>(reader)
            };
        }

        #endregion

        #region GetTransactionHexArgs

        protected virtual void WriteGetTransactionHexArgs(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (GetTransactionHexArgs)obj;
            serializer.Serialize(writer, value.Trx);
        }

        protected virtual GetTransactionHexArgs ReadGetTransactionHexArgs(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new GetTransactionHexArgs
            {
                Trx = serializer.Deserialize<SignedTransaction>(reader)
            };
        }

        #endregion

        #region GetRequiredSignaturesArgs

        protected virtual void WriteGetRequiredSignaturesArgs(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (GetRequiredSignaturesArgs)obj;
            serializer.Serialize(writer, value.Trx);
        }

        protected virtual GetRequiredSignaturesArgs ReadGetRequiredSignaturesArgs(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new GetRequiredSignaturesArgs
            {
                Trx = serializer.Deserialize<SignedTransaction>(reader)
            };
        }

        #endregion

        #region GetRequiredSignaturesReturn

        protected virtual void WritGetRequiredSignaturesReturn(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (GetRequiredSignaturesReturn)obj;
            serializer.Serialize(writer, value.Keys);
        }

        protected virtual GetRequiredSignaturesReturn ReadGetRequiredSignaturesReturn(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new GetRequiredSignaturesReturn
            {
                Keys = serializer.Deserialize<PublicKeyType[]>(reader)
            };
        }

        #endregion

        #region VerifyAuthorityArgs

        protected virtual void WriteVerifyAuthorityArgs(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (VerifyAuthorityArgs)obj;
            writer.WriteStartArray();
            serializer.Serialize(writer, value.Trx);
            writer.WriteEndArray();
        }

        protected virtual VerifyAuthorityArgs ReadVerifyAuthorityArgs(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region VerifyAuthorityReturn

        protected virtual void WriteVerifyAuthorityReturn(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (VerifyAuthorityReturn)obj;
            serializer.Serialize(writer, value.Valid);
        }

        protected virtual VerifyAuthorityReturn ReadVerifyAuthorityReturn(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new VerifyAuthorityReturn { Valid = (bool)reader.Value };
        }

        #endregion

        #region CommentPayoutBeneficiaries

        protected virtual void WriteCommentPayoutBeneficiaries(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (CommentPayoutBeneficiaries)obj;
            writer.WriteStartArray();
            writer.WriteValue(0);
            writer.WriteStartObject();
            writer.WritePropertyName("beneficiaries");
            serializer.Serialize(writer, value.Beneficiaries);
            writer.WriteEndObject();
            writer.WriteEndArray();
        }

        protected virtual CommentPayoutBeneficiaries ReadCommentPayoutBeneficiaries(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var beneficiaries = serializer.Deserialize<Beneficiary[]>(reader);
            return new CommentPayoutBeneficiaries(beneficiaries);
        }

        #endregion

        #region GetAccountHistoryReturn

        protected virtual void WriteGetAccountHistoryReturn(JsonWriter writer, JsonSerializer serializer, object obj)
        {
            var value = (GetAccountHistoryReturn)obj;
            serializer.Serialize(writer, value.History);
        }

        protected virtual GetAccountHistoryReturn ReadGetAccountHistoryReturn(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new GetAccountHistoryReturn { History = serializer.Deserialize<MapContainer<uint, AppliedOperation>>(reader) };
        }

        #endregion
    }
}