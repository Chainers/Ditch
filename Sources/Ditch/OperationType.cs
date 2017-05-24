namespace Ditch
{
    /// <summary>
    /// https://github.com/steemit/steem/blob/master/libraries/protocol/include/steemit/protocol/operations.hpp
    ///  NOTE:  do not change the order of any operations
    /// </summary>
    public enum OperationType : byte
    {
        Vote = 0,
        Comment,
        Transfer,
        TransferToVesting,
        WithdrawVesting,
        LimitOrderCreate,
        LimitOrderCancel,
        FeedPublish,
        Convert,
        AccountCreate,
        AccountUpdate,
        WitnessUpdate,
        AccountWitnessVote,
        AccountWitnessProxy,
        Pow,
        Custom,
        ReportOverProduction,
        DeleteComment,
        CustomJson,
        CommentOptions,
        SetWithdrawVestingRoute,
        LimitOrderCreate2,
        ChallengeAuthority,
        ProveAuthority,
        RequestAccountRecovery,
        RecoverAccount,
        ChangeRecoveryAccount,
        EscrowTransfer,
        EscrowDispute,
        EscrowRelease,
        Pow2,
        EscrowApprove,
        TransferToSavings,
        TransferFromSavings,
        CancelTransferFromSavings,
        CustomBinaryOperation,
        DeclineVotingRightsOperation,
        ResetAccountOperation,
        SetResetAccountOperation,
        AccountCreateWithDelegation,
    }
}