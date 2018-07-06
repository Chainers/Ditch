
namespace Ditch.EOS.Models
{
    public class ActionName : BaseName
    {
        public ActionName() { }

        public ActionName(string value)
            : base(value)
        {
        }

        public static implicit operator string(ActionName d)
        {
            return d.Value;
        }

        public static implicit operator ActionName(string d)
        {
            return new ActionName(d);
        }
    }
}