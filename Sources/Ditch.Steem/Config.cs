using System;

namespace Ditch.Steem
{
    public static class Config
    {
        public const int SteemAssetSymbolPrecisionBits = 4;
        public const UInt32 SmtMaxNai = 99999999;
        public const byte SteemPrecisionSbd = 3;
        public const byte SteemPrecisionSteem = 3;
        public const byte SteemPrecisionVests = 6;
        
        public const byte SteemNaiSbd = 1;
        public const byte SteemNaiSteem = 2;
        public const byte SteemNaiVests = 3;
        
        public const UInt32 SteemAssetNumSbd = ((SmtMaxNai + SteemNaiSbd) << SteemAssetSymbolPrecisionBits) | SteemPrecisionSbd;
        public const UInt32 SteemAssetNumSteem = ((SmtMaxNai + SteemNaiSteem) << SteemAssetSymbolPrecisionBits) | SteemPrecisionSteem;
        public const UInt32 SteemAssetNumVests = ((SmtMaxNai + SteemNaiVests) << SteemAssetSymbolPrecisionBits) | SteemPrecisionVests;
    }
}
