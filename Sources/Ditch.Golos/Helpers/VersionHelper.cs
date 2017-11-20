using Ditch.Golos.Operations;

namespace Ditch.Golos.Helpers
{
    public static class VersionHelper
    {
        public static int ToInteger(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
                return -1;

            var mhr = version.Split('.');

            int major, hardfork, release;
            if (mhr.Length != 3 || !int.TryParse(mhr[0], out major) || !int.TryParse(mhr[1], out hardfork) || !int.TryParse(mhr[2], out release))
                return -1;

            var ver = 0;
            ver = (0 | major) << 8;
            ver = (ver | hardfork) << 16;
            ver = ver | release;
            return ver;
        }

        public static int GetMajor(int version)
        {
            return (version >> 24) & 0x000000FF;
        }

        public static int GetHardfork(int version)
        {
            return (version >> 16) & 0x000000FF;
        }

        public static int GetRelease(int version)
        {
            return version & 0x0000FFFF;
        }


        public static OperationType GetOperationType(int version, OperationType operationType)
        {
            if (GetHardfork(version) == 16)
            {
                switch (operationType)
                {
                    case OperationType.Vote:
                        return OperationType.Vote16;
                    case OperationType.Comment:
                        return OperationType.Comment16;
                    case OperationType.Transfer:
                        return OperationType.Transfer16;
                    case OperationType.TransferToVesting:
                        return OperationType.TransferToVesting16;
                    case OperationType.WithdrawVesting:
                        return OperationType.WithdrawVesting16;
                    case OperationType.LimitOrderCreate:
                        return OperationType.LimitOrderCreate16;
                    case OperationType.LimitOrderCancel:
                        return OperationType.LimitOrderCancel16;
                    case OperationType.FeedPublish:
                        return OperationType.FeedPublish16;
                    case OperationType.Convert:
                        return OperationType.Convert16;
                    case OperationType.AccountCreate:
                        return OperationType.AccountCreate16;
                    case OperationType.AccountUpdate:
                        return OperationType.AccountUpdate16;
                    case OperationType.WitnessUpdate:
                        return OperationType.WitnessUpdate16;
                    case OperationType.AccountWitnessVote:
                        return OperationType.AccountWitnessVote16;
                    case OperationType.AccountWitnessProxy:
                        return OperationType.AccountWitnessProxy16;
                    case OperationType.Pow:
                        return OperationType.Pow16;
                    //Custom
                    case OperationType.ReportOverProduction:
                        return OperationType.ReportOverProduction16;
                    case OperationType.DeleteComment:
                        return OperationType.DeleteComment16;
                    //CustomJson
                    case OperationType.CommentOptions:
                        return OperationType.CommentOptions16;
                    case OperationType.SetWithdrawVestingRoute:
                        return OperationType.SetWithdrawVestingRoute16;
                    case OperationType.LimitOrderCreate2:
                        return OperationType.LimitOrderCreate216;
                    case OperationType.ChallengeAuthority:
                        return OperationType.ChallengeAuthority16;
                    case OperationType.ProveAuthority:
                        return OperationType.ProveAuthority16;
                    case OperationType.RequestAccountRecovery:
                        return OperationType.RequestAccountRecovery16;
                    case OperationType.RecoverAccount:
                        return OperationType.RecoverAccount16;
                    case OperationType.ChangeRecoveryAccount:
                        return OperationType.ChangeRecoveryAccount16;
                    case OperationType.EscrowTransfer:
                        return OperationType.EscrowTransfer16;
                    case OperationType.EscrowDispute:
                        return OperationType.EscrowDispute16;
                    case OperationType.EscrowRelease:
                        return OperationType.EscrowRelease16;
                    case OperationType.Pow2:
                        return OperationType.Pow216;
                    case OperationType.EscrowApprove:
                        return OperationType.EscrowApprove16;
                    case OperationType.TransferToSavings:
                        return OperationType.TransferToSavings16;
                    case OperationType.TransferFromSavings:
                        return OperationType.TransferFromSavings16;
                    case OperationType.CancelTransferFromSavings:
                        return OperationType.CancelTransferFromSavings16;
                    //CustomBinary
                    case OperationType.DeclineVotingRights:
                        return OperationType.DeclineVotingRights16;
                    case OperationType.ResetAccount:
                        return OperationType.ResetAccount16;
                    case OperationType.SetResetAccount:
                        return OperationType.SetResetAccount16;
                    case OperationType.CommentBenefactorReward:
                        return OperationType.CommentBenefactorReward16;
                }
            }
            return operationType;
        }
    }
}
