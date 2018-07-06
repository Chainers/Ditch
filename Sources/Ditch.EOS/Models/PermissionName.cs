
namespace Ditch.EOS.Models
{
    public class PermissionName : BaseName
    {
        public PermissionName() { }

        public PermissionName(string value)
            : base(value)
        {
        }

        public static implicit operator string(PermissionName d)
        {
            return d.Value;
        }

        public static implicit operator PermissionName(string d)
        {
            return new PermissionName(d);
        }
    }
}