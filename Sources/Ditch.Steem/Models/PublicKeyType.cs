﻿using Ditch.Core;
using Ditch.Core.Attributes;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    public class PublicKeyType : ICustomJson
    {
        public string Prefix { get; set; } = Config.KeyPrefix;

        [MessageOrder(1)]
        public byte[] Data { get; set; }


        public PublicKeyType() { }

        public PublicKeyType(string value)
        {
            Data = Base58.DecodePublicWif(value, Prefix);
        }

        public PublicKeyType(byte[] data)
        {
            Data = data;
        }
        
        public override string ToString()
        {
            return Base58.EncodePublicWif(Data, Prefix);
        }

        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            Data = Base58.DecodePublicWif(value, Prefix);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            var wif = Base58.EncodePublicWif(Data, Prefix);
            writer.WriteValue(wif);
        }

        #endregion
    }
}
