
namespace Ditch.EOS.Models
{
    public class AccountName : BaseName
    {
        public AccountName() { }

        public AccountName(string value)
            : base(value)
        {
        }

        public static implicit operator string(AccountName d)
        {
            return d.Value;
        }

        public static implicit operator AccountName(string d)
        {
            return new AccountName(d);
        }
    }
}