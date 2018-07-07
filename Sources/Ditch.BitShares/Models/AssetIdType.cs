namespace Ditch.BitShares.Models
{
    /// <inheritdoc />
    /// <summary>
    /// libraries\chain\include\graphene\chain\protocol\types.hpp
    ///  typedef object_id&lt;protocol_ids, asset_object_type,asset_object&gt; asset_id_type;
    /// </summary>
    public class AssetIdType : ObjectId
    {

        public AssetIdType()
        {
        }

        public AssetIdType(byte spaceId, byte typeId, uint instance)
            : base(spaceId, typeId, instance)
        {
        }
    }
}