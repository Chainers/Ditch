using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// libraries\chain\include\graphene\chain\protocol\types.hpp
    ///  typedef object_id<protocol_ids, asset_object_type,asset_object> asset_id_type;
    /// </summary>
    [JsonConverter(typeof(CustomConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public class AssetIdType : ObjectId, ICustomSerializer, ICustomJson
    {

        public AssetIdType()
        {
        }

        public AssetIdType(byte spaceId, byte typeId, UInt32 instance)
            : base(spaceId, typeId, instance)
        {
        }

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            serializeHelper.AddToMessageStream(stream, typeof(string), $"{SpaceId}.{TypeId}.{Instance}");
        }

        #endregion

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