using System;
using Ditch.Responses;
using NUnit.Framework;

namespace Ditch.Tests
{
    [TestFixture]
    public class OperationManagerTest : BaseTest
    {
        private readonly OperationManager _operationManager;
        private const string Name = "joseph.kalu";
        private const string PostingKey = "5JXCxj6YyyGUTJo9434ZrQ5gfxk59rE3yukN42WBA6t58yTPRTG";

        public OperationManagerTest()
        {
            GlobalSettings.Init(Name, PostingKey, ChainManager.KnownChains.Steem);
            _operationManager = new OperationManager();
        }


        [Test]
        public void GetDynamicGlobalPropertiesTest()
        {
            var prop = _operationManager.GetDynamicGlobalProperties();
            Assert.IsTrue(prop != null);
            Assert.IsTrue(prop.Result != null);
            Assert.IsFalse(prop.IsError);
        }

        [Test]
        public void GetContentTest()
        {
            var prop = _operationManager.GetContent("steepshot", "c-lib-ditch-1-0-for-graphene-from-steepshot-team-under-the-mit-license");
            Assert.IsTrue(prop != null);
            Assert.IsTrue(prop.Result != null);
            Assert.IsFalse(prop.IsError);
            Assert.IsTrue(prop.Result.TotalPayoutValue.Value > 0);
        }

        [Test]
        [TestCase("277.126 SBD")]
        public void ParseTestTest(string test)
        {
            var money = new Money(test);
            Assert.IsTrue(Math.Abs(money.Value - 277.126) < 0.00001);
            Assert.IsTrue(money.Currency == "SBD");
        }

        [Test]
        public void GetHelp()
        {
            var ws = new WebSocketManager();
            var rez = ws.GetRequest<object>("help");
            Console.WriteLine(rez.Error);
        }

        [Test]
        [Ignore("make transaction")]
        public void FollowTest()
        {
            var prop = _operationManager.Follow("korzunav");
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }

        [Test]
        [Ignore("make transaction")]
        public void UnFollowTest()
        {
            var prop = _operationManager.UnFollow("korzunav");
            Assert.IsFalse(prop.IsError, prop.GetErrorMessage());
        }
    }
}
