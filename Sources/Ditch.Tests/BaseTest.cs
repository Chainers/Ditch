using Ditch.Operations;

namespace Ditch.Tests
{
    public class BaseTest
    {
        protected const string JosephName = "joseph.kalu";
        protected const string JosephWif = "***REMOVED***";

        #region xeroc\piston-lib\tests\test_transactions.py

        protected const string TestWif = "5KQwrPbwdL6PhXujxW37FSSQZ1JiwsST4cqQzDeyXtP79zkvFD3";
        protected const ushort TestRefBlockNum = 34294;
        protected const uint TestRefBlockPrefix = 3707022213;
        protected const string TestExpiration = "2016-04-06T08:29:27";

        #endregion xeroc\piston-lib\tests\test_transactions.py

        protected readonly VoteOperation VoteOperation = new VoteOperation
        {
            Voter = "xeroc",
            Author = "xeroc",
            Permlink = "piston",
            Weight = 10000
        };
    }
}