using System;

namespace Ditch.Steem
{
    public class Config
    {
        public const int STEEM_ASSET_SYMBOL_PRECISION_BITS = 4;
        public const UInt32 SMT_MAX_NAI = 99999999;
        public const int SMT_MIN_NAI = 1;
        public const int SMT_MIN_NON_RESERVED_NAI = 10000000;
        public const int STEEM_ASSET_SYMBOL_NAI_LENGTH = 10;
        public const int STEEM_ASSET_SYMBOL_NAI_STRING_LENGTH = STEEM_ASSET_SYMBOL_NAI_LENGTH + 2;
        public const byte STEEM_PRECISION_SBD = 3;
        public const byte STEEM_PRECISION_STEEM = 3;
        public const byte STEEM_PRECISION_VESTS = 6;


        public const byte STEEM_NAI_SBD = 1;
        public const byte STEEM_NAI_STEEM = 2;
        public const byte STEEM_NAI_VESTS = 3;

        public const UInt64 SteemSymbol = (UInt64)3 | ((UInt64)'T' << 8) | ((UInt64)'E' << 16) | ((UInt64)'S' << 24) | ((UInt64)'T' << 32) | ((UInt64)'S' << 40); //< STEEM with 3 digits of precision


        public const UInt32 STEEM_ASSET_NUM_SBD = (((SMT_MAX_NAI + STEEM_NAI_SBD) << STEEM_ASSET_SYMBOL_PRECISION_BITS) | STEEM_PRECISION_SBD);
        public const UInt32 STEEM_ASSET_NUM_STEEM = (((SMT_MAX_NAI + STEEM_NAI_STEEM) << STEEM_ASSET_SYMBOL_PRECISION_BITS) | STEEM_PRECISION_STEEM);
        public const UInt32 STEEM_ASSET_NUM_VESTS = (((SMT_MAX_NAI + STEEM_NAI_VESTS) << STEEM_ASSET_SYMBOL_PRECISION_BITS) | STEEM_PRECISION_VESTS);


    }
}
