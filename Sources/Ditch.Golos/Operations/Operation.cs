using System.IO;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Ditch.Golos.Operations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Golos.Models
{
    [JsonConverter(typeof(CustomConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public class Operation : ICustomJson, ICustomSerializer
    {
        private BaseOperation _baseOperation;

        public Operation() { }

        public Operation(BaseOperation baseOperation)
        {
            _baseOperation = baseOperation;
        }


        public static implicit operator BaseOperation(Operation d)
        {
            return d._baseOperation;
        }

        public static implicit operator Operation(BaseOperation baseOperation)
        {
            return new Operation(baseOperation);
        }

        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                var opName = reader.ReadAsString();
                reader.Read();
                switch (opName)
                {
                    case VoteOperation.OperationName:
                        _baseOperation = serializer.Deserialize<VoteOperation>(reader);
                        break;
                    case CommentOperation.OperationName:
                        _baseOperation = serializer.Deserialize<CommentOperation>(reader);
                        break;

                    case TransferOperation.OperationName:
                        _baseOperation = serializer.Deserialize<TransferOperation>(reader);
                        break;
                    case TransferToVestingOperation.OperationName:
                        _baseOperation = serializer.Deserialize<TransferToVestingOperation>(reader);
                        break;
                    case WithdrawVestingOperation.OperationName:
                        _baseOperation = serializer.Deserialize<WithdrawVestingOperation>(reader);
                        break;

                    //LimitOrderCreate,
                    //LimitOrderCancel,

                    //FeedPublish,
                    //Convert,


                    case AccountCreateOperation.OperationName:
                        _baseOperation = serializer.Deserialize<AccountCreateOperation>(reader);
                        break;
                    case AccountUpdateOperation.OperationName:
                        _baseOperation = serializer.Deserialize<AccountUpdateOperation>(reader);
                        break;

                    case WitnessUpdateOperation.OperationName:
                        _baseOperation = serializer.Deserialize<WitnessUpdateOperation>(reader);
                        break;
                    //AccountWitnessVote,
                    //AccountWitnessProxy,

                    //Pow,

                    //Custom,

                    //ReportOverProduction,

                    case DeleteCommentOperation.OperationName:
                        _baseOperation = serializer.Deserialize<DeleteCommentOperation>(reader);
                        break;
                    case CustomJsonOperation.OperationName:
                        _baseOperation = serializer.Deserialize<CustomJsonOperation>(reader);
                        break;
                    case CommentOptionsOperation.OperationName:
                        _baseOperation = serializer.Deserialize<CommentOptionsOperation>(reader);
                        break;
                    //SetWithdrawVestingRoute,
                    //LimitOrderCreate2,
                    //ChallengeAuthority,
                    //ProveAuthority,
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
                    //DelegateVestingShares,
                    //AccountCreateWithDelegation,
                    //AccountMetadata,
                    case ProposalCreateOperation.OperationName:
                        _baseOperation = serializer.Deserialize<ProposalCreateOperation>(reader);
                        break;
                    case ProposalUpdateOperation.OperationName:
                        _baseOperation = serializer.Deserialize<ProposalUpdateOperation>(reader);
                        break;
                    //ProposalDelete,
                    //ChainPropertiesUpdate,

                    ///// virtual operations below this point
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
                    //CommentBenefactorReward,
                    //ReturnVestingDelegation


                    default:
                        _baseOperation = new UnsupportedOperation(opName, serializer.Deserialize<JObject>(reader));
                        break;
                }

                reader.Read();
            }
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            writer.WriteValue(_baseOperation.TypeName);
            serializer.Serialize(writer, _baseOperation);
            writer.WriteEndArray();
        }

        #endregion

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            serializeHelper.AddToMessageStream(stream, _baseOperation.GetType(), _baseOperation);
        }

        #endregion
    }
}