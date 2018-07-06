using System;
using System.IO;
using Ditch.Core;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// object_id
    /// libraries\db\include\graphene\db\object_id.hpp
    /// </summary>
    [JsonConverter(typeof(CustomConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ObjectId : ICustomJson, ICustomSerializer
    {
        /// <summary>
        /// API name: space_id
        /// = SpaceID;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = TypeID;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: instance
        /// 
        /// </summary>
        /// <returns>API type: unsigned_int</returns>
        public UnsignedInt Instance { get; set; }


        public ObjectId() { }

        public ObjectId(byte spaceId, byte typeId, UInt32 instance)
        {
            SpaceId = spaceId;
            TypeId = typeId;
            Instance = instance;
        }


        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            Instance.Serializer(stream, serializeHelper);
        }

        #endregion ICustomSerializer

        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var value = serializer.Deserialize<string>(reader);
            if (string.IsNullOrEmpty(value))
                return;

            var args = value.Split('.');

            SpaceId = byte.Parse(args[0]);
            TypeId = byte.Parse(args[1]);
            Instance = uint.Parse(args[2]);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteValue($"{SpaceId}.{TypeId}.{Instance.Value}");
        }

        #endregion ICustomJson
    }
}
