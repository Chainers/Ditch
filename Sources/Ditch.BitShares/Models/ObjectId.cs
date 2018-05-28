using System;
using Ditch.Core.Attributes;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// object_id
    /// libraries\db\include\graphene\db\object_id.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ObjectId : ICustomJson
    {
        /// <summary>
        /// API name: space_id
        /// = SpaceID;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [MessageOrder(10)]
        [JsonProperty("space_id")]
        public byte SpaceId { get; set; }

        /// <summary>
        /// API name: type_id
        /// = TypeID;
        /// </summary>
        /// <returns>API type: uint8_t</returns>
        [MessageOrder(20)]
        [JsonProperty("type_id")]
        public byte TypeId { get; set; }

        /// <summary>
        /// API name: instance
        /// 
        /// </summary>
        /// <returns>API type: unsigned_int</returns>
        [MessageOrder(20)]
        [JsonProperty("instance")]
        public UInt32 Instance { get; set; }


        public ObjectId() { }

        public ObjectId(byte spaceId, byte typeId, UInt32 instance)
        {
            SpaceId = spaceId;
            TypeId = typeId;
            Instance = instance;
        }

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
