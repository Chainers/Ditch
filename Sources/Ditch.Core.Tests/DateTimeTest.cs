using System;
using System.Text.RegularExpressions;
using Ditch.Core.Models;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Ditch.Core.Tests
{
    [TestFixture]
    public class DateTimeTest
    {
        [Test]
        public void TimePointSecTest()
        {
            var dt = DateTime.Now.ToUniversalTime();
            var utf = dt.ToString("s");
            var jo = JsonConvert.DeserializeObject<Tuple<TimePointSec>>($"{{\"Item1\":\"{utf}\"}}");
            var jws = new TimePointSecJsonWriterStub(new Regex(dt.ToString("yyyy-MM-ddTHH:mm:ss")));
            jo.Item1.WriteJson(jws, null);
        }


        [Test]
        public void TimePointSecFormatTest()
        {
            var jws = new TimePointSecJsonWriterStub(new Regex("[0-9]{4}-[0-1][0-9]-[0-3][0-9]T[0-2][0-9]:[0-6][0-9]:[0-6][0-9]"));
            var dt = DateTime.Today;
            var tps = new TimePointSec(dt);

            for (var i = 0; i < 100; i++)
            {
                tps.Value = tps.Value.AddMilliseconds(10);
                tps.WriteJson(jws, null);
            }
            for (var i = 0; i < 60; i++)
            {
                tps.Value = tps.Value.AddSeconds(1);
                tps.WriteJson(jws, null);
            }
            for (var i = 0; i < 60; i++)
            {
                tps.Value = tps.Value.AddMinutes(1);
                tps.WriteJson(jws, null);
            }
            for (var i = 0; i < 24; i++)
            {
                tps.Value = tps.Value.AddDays(1);
                tps.WriteJson(jws, null);
            }
            for (var i = 0; i < 12; i++)
            {
                tps.Value = tps.Value.AddMonths(1);
                tps.WriteJson(jws, null);
            }
        }

        public class TimePointSecJsonWriterStub : JsonWriter
        {
            private readonly Regex _testRegex;

            public TimePointSecJsonWriterStub(Regex testRegex)
            {
                _testRegex = testRegex;
            }

            public override void WriteValue(string value)
            {
                Assert.IsTrue(_testRegex.IsMatch(value));
            }

            public override void Flush()
            {
                throw new NotImplementedException();
            }
        }
    }
}
