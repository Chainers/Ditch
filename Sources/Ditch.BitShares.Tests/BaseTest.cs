using Newtonsoft.Json;
using System.Globalization;
using Xunit.Abstractions;

namespace Ditch.BitShares.Tests
{
    public class BaseTest
    {
        protected readonly ITestOutputHelper Output;

        public BaseTest(ITestOutputHelper output)
        {
            Output = output;
        }

        protected void WriteLine(string s)
        {
            Output.WriteLine(s);
        }

        public static JsonSerializerSettings GetJsonSerializerSettings()
        {
            var rez = new JsonSerializerSettings
            {
                DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",
                Culture = CultureInfo.InvariantCulture
            };
            return rez;
        }
    }
}