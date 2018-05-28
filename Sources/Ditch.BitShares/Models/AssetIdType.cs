using System;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// libraries\chain\include\graphene\chain\protocol\types.hpp
    ///  typedef object_id<protocol_ids, asset_object_type,asset_object> asset_id_type;
    /// </summary>
    public class AssetIdType : ObjectId
    {

        public AssetIdType()
        {
        }

        public AssetIdType(byte spaceId, byte typeId, UInt32 instance)
            : base(spaceId, typeId, instance)
        {
        }
    }
}