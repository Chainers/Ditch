namespace Ditch.BitShares.Operations
{
    /// <summary>
    /// https://github.com/bitshares/bitshares-core/blob/master/libraries/chain/include/graphene/chain/protocol/operations.hpp
    ///  NOTE:  do not change the order of any operations
    /// </summary>
    public enum OperationType : byte
    {
        Transfer,
        LimitOrderCreate,
        LimitOrderCancel,
        CallOrderUpdate,
        FillOrder,           // VIRTUAL
        AccountCreate,
        AccountUpdate,
        AccountWhitelist,
        AccountUpgrade,
        AccountTransfer,
        AssetCreate,
        AssetUpdate,
        AssetUpdateBitasset,
        AssetUpdateFeedProducers,
        AssetIssue,
        AssetReserve,
        AssetFundFeePool,
        AssetSettle,
        AssetGlobalSettle,
        AssetPublishFeed,
        WitnessCreate,
        WitnessUpdate,
        ProposalCreate,
        ProposalUpdate,
        ProposalDelete,
        WithdrawPermissionCreate,
        WithdrawPermissionUpdate,
        WithdrawPermissionClaim,
        WithdrawPermissionDelete,
        CommitteeMemberCreate,
        CommitteeMemberUpdate,
        CommitteeMemberUpdateGlobalParameters,
        VestingBalanceCreate,
        VestingBalanceWithdraw,
        WorkerCreate,
        Custom,
        Assert,
        BalanceClaim,
        OverrideTransfer,
        TransferToBlind,
        BlindTransfer,
        TransferFromBlind,
        AssetSettleCancel,  // VIRTUAL
        AssetClaimFees,
        FbaDistribute,       // VIRTUAL
        BidCollateral,
        ExecuteBid           // VIRTUAL
    }
}
