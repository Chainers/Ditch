using System;
using System.Text.RegularExpressions;
using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Other
{
    /// <summary>
    /// asset_symbol_type
    /// libraries\protocol\include\steem\protocol\asset_symbol.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AssetSymbolType
    {
        private static readonly Regex ValidateRegex = new Regex("(?<=^@@)[0-9]{9}$");

        /// <summary>
        /// API name: asset_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [MessageOrder(10)]
        public UInt32 AssetNum { get; set; }


        public AssetSymbolType(UInt32 assetNum)
        {
            AssetNum = assetNum;
        }

        public AssetSymbolType(string value, byte decimalPlaces)
        {
            var m = ValidateRegex.Match(value);
            if (!m.Success)
                throw new InvalidCastException();

            UInt32 assetNum = UInt32.Parse(m.Value);
            AssetNum = AssetNumFromNai(assetNum, decimalPlaces);
        }

        private UInt32 AssetNumFromNai(UInt32 nai, byte decimalPlaces)
        {
            var naiDataDigits = nai / 10;

            switch (naiDataDigits)
            {
                case Config.SteemNaiSteem:
                    return Config.SteemAssetNumSteem;
                case Config.SteemNaiSbd:
                    return Config.SteemAssetNumSbd;
                case Config.SteemNaiVests:
                    return Config.SteemAssetNumVests;
                default:
                    return (naiDataDigits << 5) | 0x10 | decimalPlaces;
            }
        }

        public byte Decimals()
        {
            return (byte)(AssetNum & 0x0F);
        }

        public string ToNaiString()
        {
            var x = ToNai();
            return x.ToString("@@000000000");
        }

        private UInt32 ToNai()
        {
            UInt32 naiDataDigits;

            // Can be replaced with some clever bitshifting
            switch (AssetNum)
            {
                case Config.SteemAssetNumSteem:
                    naiDataDigits = Config.SteemNaiSteem;
                    break;
                case Config.SteemAssetNumSbd:
                    naiDataDigits = Config.SteemNaiSbd;
                    break;
                case Config.SteemAssetNumVests:
                    naiDataDigits = Config.SteemNaiVests;
                    break;
                default:
                    naiDataDigits = AssetNum >> 5;
                    break;
            }

            var naiCheckDigit = DammChecksum_8Digit(naiDataDigits);
            return naiDataDigits * 10 + naiCheckDigit;
        }

        private byte DammChecksum_8Digit(UInt32 value)
        {
            byte[] t =
            {
                0, 30, 10, 70, 50, 90, 80, 60, 40, 20,
                70, 0, 90, 20, 10, 50, 40, 80, 60, 30,
                40, 20, 0, 60, 80, 70, 10, 30, 50, 90,
                10, 70, 50, 0, 90, 80, 30, 40, 20, 60,
                60, 10, 20, 30, 0, 40, 50, 90, 70, 80,
                30, 60, 70, 40, 20, 0, 90, 50, 80, 10,
                50, 80, 60, 90, 70, 20, 0, 10, 30, 40,
                80, 90, 40, 50, 30, 60, 20, 0, 10, 70,
                90, 40, 30, 80, 60, 10, 70, 20, 0, 50,
                20, 50, 80, 10, 40, 30, 60, 70, 90, 0
            };

            UInt32 q0 = value / 10;
            UInt32 d0 = value % 10;
            UInt32 q1 = q0 / 10;
            UInt32 d1 = q0 % 10;
            UInt32 q2 = q1 / 10;
            UInt32 d2 = q1 % 10;
            UInt32 q3 = q2 / 10;
            UInt32 d3 = q2 % 10;
            UInt32 q4 = q3 / 10;
            UInt32 d4 = q3 % 10;
            UInt32 q5 = q4 / 10;
            UInt32 d5 = q4 % 10;
            UInt32 d6 = q5 % 10;
            UInt32 d7 = q5 / 10;

            byte x = t[d7];
            x = t[x + d6];
            x = t[x + d5];
            x = t[x + d4];
            x = t[x + d3];
            x = t[x + d2];
            x = t[x + d1];
            x = t[x + d0];
            return (byte)(x / 10);
        }
    }
}
