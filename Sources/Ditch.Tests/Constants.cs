using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ditch.Tests {
   static class Constants {
      internal const string GolosUser = "karusel2";
      internal static string GolosPostingKey { get { return Environment.GetEnvironmentVariable("GOLOS_TEST_POSTING_KEY", EnvironmentVariableTarget.User) ?? "123465"; } }
      internal static string SteemPostingKey { get { return Environment.GetEnvironmentVariable("STEEM_TEST_POSTING_KEY", EnvironmentVariableTarget.User) ?? "1234567"; } }
   }
}