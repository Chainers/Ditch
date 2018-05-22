using Xunit.Abstractions;

namespace Ditch.Core.Tests
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

    }
}