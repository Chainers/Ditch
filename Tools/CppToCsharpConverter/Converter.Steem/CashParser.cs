namespace Converter.Steem
{
    public class CashParser : Core.CashParser
    {
        public CashParser()
            : base(new Grabber(), "Steem") { }
    }
}