using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_currency_stats_result
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public class GetCurrencyStatsResult : ICustomJson
    {
        public string Symbol { get; set; }


        /// <summary>
        /// API name: supply
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("supply")]
        public string Supply { get; set; }

        /// <summary>
        /// API name: max_supply
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("max_supply")]
        public string MaxSupply { get; set; }

        /// <summary>
        /// API name: issuer
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("issuer")]
        public AccountName Issuer { get; set; }


        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            reader.Read();
            Symbol = (string)reader.Value;
            reader.Read();
            reader.Read();
            reader.Read();
            Supply = (string)reader.Value;
            reader.Read();
            reader.Read();
            MaxSupply = (string)reader.Value;
            reader.Read();
            reader.Read();
            Issuer = (string)reader.Value;
            reader.Read();
            reader.Read();
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(Symbol);
            writer.WriteStartObject();
            writer.WritePropertyName("supply");
            writer.WriteValue(Supply);
            writer.WritePropertyName("max_supply");
            writer.WriteValue(MaxSupply);
            writer.WritePropertyName("issuer");
            writer.WriteValue(Issuer);
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}