using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Ditch.EOS.Errors
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class HttpError : ErrorBase
    {
        private static readonly Regex ErrorHtml = new Regex(@"<[^>]+>");
        private static readonly Regex ErrorJson = new Regex("(?<=^{\"[a-z_0-9]*\":\\[\").*(?=\"]}$)");
        private static readonly Regex ErrorJson2 = new Regex("(?<=^{\"[a-z_0-9]*\":\").*(?=\"}$)");

        public HttpError(string content)
            : base(ToMessage(content)) { }


        private static string ToMessage(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return nameof(LocalizationKeys.EmptyResponseContent);

            if (ErrorHtml.IsMatch(content))
                return content;

            var match = ErrorJson.Match(content);
            if (match.Success)
                return match.Value.Replace("\",\"", Environment.NewLine);

            match = ErrorJson2.Match(content);

            if (match.Success)
                return match.Value;

            return nameof(LocalizationKeys.UnexpectedError);
        }
    }
}