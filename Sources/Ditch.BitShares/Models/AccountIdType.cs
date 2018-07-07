namespace Ditch.BitShares.Models
{
    /// <inheritdoc />
    /// <summary>
    /// libraries\chain\include\graphene\chain\protocol\types.hpp
    /// typedef object_id&lt;protocol_ids, account_object_type, account_object&gt; account_id_type;
    /// </summary>
    public class AccountIdType : ObjectId
    {
        public AccountIdType()
        {
        }

        public AccountIdType(byte spaceId, byte typeId, uint instance)
            : base(spaceId, typeId, instance)
        {
        }
    }
}