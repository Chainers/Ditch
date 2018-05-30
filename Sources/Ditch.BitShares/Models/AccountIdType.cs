using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// libraries\chain\include\graphene\chain\protocol\types.hpp
    /// typedef object_id<protocol_ids, account_object_type, account_object> account_id_type;
    /// </summary>
    [JsonConverter(typeof(CustomConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public class AccountIdType : ObjectId, /*ICustomSerializer,*/ ICustomJson
    {

        public AccountIdType()
        {
            SpaceId = (byte)1;
            TypeId = (byte)2;
            Instance = 5;
        }

        public AccountIdType(byte spaceId, byte typeId, UInt32 instance)
            : base(spaceId, typeId, instance)
        {
        }

        //#region ICustomSerializer

        //public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        //{
        //    serializeHelper.AddToMessageStream(stream, typeof(string), $"{SpaceId}.{TypeId}.{Instance}");
        //}

        //#endregion

        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var value = reader.ReadAsString();
            if (string.IsNullOrEmpty(value))
                return;

            var args = value.Split('.');

            SpaceId = byte.Parse(args[0]);
            TypeId = byte.Parse(args[1]);
            Instance = uint.Parse(args[2]);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteValue($"{SpaceId}.{TypeId}.{Instance}");
        }

        #endregion ICustomJson
    }
}