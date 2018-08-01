using System.Text;

namespace Converter.Core.Helpers
{
    public static class StringHelper
    {
        public static string ToTitleCase(this string name, bool firstUpper = true)
        {
            var sb = new StringBuilder(name);
            for (var i = 0; i < sb.Length; i++)
            {
                if (i == 0 && firstUpper)
                    sb[i] = char.ToUpper(sb[i]);

                if (sb[i] == '_' && i + 1 < sb.Length)
                    sb[i + 1] = char.ToUpper(sb[i + 1]);
            }
            sb.Replace("_", string.Empty);
            var rez = sb.ToString();
            if (rez.Equals("params"))
                rez = "parameters";

            return rez;
        }
    }
}
