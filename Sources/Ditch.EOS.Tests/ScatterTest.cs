using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ditch.EOS.Contracts.Eosio.Actions;
using Ditch.EOS.Contracts.Eosio.Structs;
using Ditch.EOS.Models;
using Ditch.EOS.Tests.Apis;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Ditch.EOS.Tests
{
    [TestFixture]
    public class ScatterTest : BaseTest
    {
        [Test]
        public async Task BroadcastWithScatterTest()
        {
            var op = new BuyramAction
            {
                Account = User.Login,

                Args = new Buyram
                {
                    Payer = User.Login,
                    Receiver = User.Login,
                    Quant = new Asset("0.001 EOS")

                },
                Authorization = new[]
                {
                    new PermissionLevel
                    {
                        Actor = User.Login,
                        Permission = "active"
                    }
                }
            };

            var resp = await Api.BroadcastActionsAsync(new[] { op }, new[] { new PublicKey(User.PublicActiveWif) }, SigningWithEosWallet, CancellationToken).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

            resp = await Api.BroadcastActionsAsync(new[] { op }, new[] { new PublicKey(User.PublicActiveWif) }, SigningWithScatter, CancellationToken).ConfigureAwait(false);
            WriteLine(resp);
            Assert.IsFalse(resp.IsError);

        }

        private async Task<OperationResult<SignedTransaction>> SigningWithEosWallet(SignedTransaction trx, PublicKey[] keys, string chainId, CancellationToken token)
        {
            await Api.WalletOpenAsync(User.Login, token).ConfigureAwait(false);
            await Api.WalletUnlockAsync(User.Login, User.Password, token).ConfigureAwait(false);
            var result = await Api.WalletSignTransactionAsync(trx, keys, chainId, token).ConfigureAwait(false);
            await Api.WalletLockAsync(User.Login, CancellationToken).ConfigureAwait(false);
            return result;
        }

        private Task<OperationResult<SignedTransaction>> SigningWithScatter(SignedTransaction trx, PublicKey[] keys, string chainId, CancellationToken token)
        {
            var args = new object[] { trx, keys, chainId };
            var endpoint = ConfigurationManager.AppSettings["ScatterUrl"];
            return CustomPostRequest<SignedTransaction>(endpoint, args, token);
        }

        public async Task<OperationResult<T>> CustomPostRequest<T>(string url, object data, CancellationToken token)
        {
            HttpContent content = null;
            var param = string.Empty;
            if (data != null)
            {
                param = JsonConvert.SerializeObject(data, Api.JsonSerializerSettings);
                content = new StringContent(param, Encoding.UTF8, "application/json");
            }

            var _client = new HttpClient();
            var response = await _client.PostAsync(url, content, token).ConfigureAwait(false);
            var result = await Api.CreateResultAsync<T>(response, token).ConfigureAwait(false);

            result.RawRequest = $"POST: {url} {param}";

            return result;
        }
    }
}
