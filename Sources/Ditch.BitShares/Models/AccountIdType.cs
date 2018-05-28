using System;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// libraries\chain\include\graphene\chain\protocol\types.hpp
    /// typedef object_id<protocol_ids, account_object_type, account_object> account_id_type;
    /// </summary>
    public class AccountIdType : ObjectId
    {
        public AccountIdType()
        {
        }

        public AccountIdType(byte spaceId, byte typeId, UInt32 instance)
            : base(spaceId, typeId, instance)
        {
        }
    }
}