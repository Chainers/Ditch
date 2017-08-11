using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CppToCsharpConverter.Converters
{
    public class StructConverter : IConverter
    {
        private readonly Regex _nameRules = new Regex("[^a-z_0-9]*");
        private readonly Regex _normalizeType = new Regex(@"((?<=<)\s*)|(\s*((?=>)))|((?<=[<][0-9_a-z\s]*[,])\s*)|(\b[a-z]*::\b)|");
        private readonly Regex _fieldRules = new Regex(@"^\s?[a-z0-9<,>_]*[ \t]{1,}[a-z0-9_]*\s*(=[a-z_0-9<,>\s]*)?;");

        private readonly Dictionary<string, string> _knownTypes = new Dictionary<string, string>
        {
            {"account_id_type", "object"},
            {"comment_id_type", "object"},
            {"id_type", "object"},
            {"feed_history_id_type", "object"},

            {"string", "string"},
            {"time_point_sec", "DateTime"},
            {"bool", "bool"},
            {"uint8_t", "byte"},
            {"uint16_t", "UInt16"},
            {"uint32_t", "UInt32"},
            {"uint64_t", "UInt64"},
            {"uint128_t", "string"},
            {"int16_t", "Int16"},
            {"int32_t", "Int32"},
            {"int64_t", "Int64"},
            {"asset", "Money"},
            {"share_type", "object"},

            {"comment_mode", "CommentMode"},
            {"follow_type", "FollowType"},

            {"account_api_obj", "AccountApiObj"},
            {"extended_account", "ExtendedAccount"},
            {"discussion", "Discussion"},
            {"comment_api_obj", "CommentApiObj"},
            {"chain_properties", "ChainProperties"},
            {"price", "Price"},
            {"version", "string"},
            {"hardfork_version", "string"},
            {"convert_request_api_obj", "ConvertRequest"},
            {"account_bandwidth_api_obj", "AccountBandwidthApiObj"},
            {"bandwidth_type", "BandwidthType"},
            {"account_name_type", "string"},
            {"authority", "Authority"},

            {"account_authority_map", "object"},
            {"key_authority_map", "object"},
            {"public_key_type", "string"},
            {"vote_state", "VoteState"},
            {"dynamic_global_property_api_obj", "DynamicGlobalPropertiesApiObj"},
            {"category_index", "object"},
            {"tag_index", "TagIdx"},
            {"discussion_index", "object"},
            {"witness_schedule_api_obj", "WitnessScheduleApiObj"},
        };

        private class ParsedPropertyInfo
        {
            public string Type { get; set; }

            public string CppType { get; set; }

            public string Name { get; set; }

            public string Comment { get; set; }
        }


        public string Execute(string text, string pathToFile = null)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return text;

            var lines = text.Split(new[] { Environment.NewLine, "\r\n", "\n\r", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            var name = ReadObjectName(lines[0]);
            AddClassName(sb, name, pathToFile);

            for (int i = 0; i < lines.Length; i++)
            {
                ParsedPropertyInfo propertyInfo;
                if (TryParseField(lines[i], out propertyInfo))
                {
                    AddProperty(sb, propertyInfo);
                }
            }

            CloseClass(sb);
            return sb.ToString();
        }

        private string ReadObjectName(string line)
        {
            if (line.Contains("struct") || line.Contains("class"))
            {
                var kv = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < kv.Length - 1; i++)
                {
                    if (kv[i].Equals("struct") || kv[i].Equals("class"))
                    {
                        return kv[i + 1];
                    }
                }
            }
            throw new InvalidCastException();
        }

        private void AddClassName(StringBuilder sb, string name, string pathToFile)
        {
            sb.AppendLine("    /// <summary>");
            sb.AppendLine($"    /// {name}");
            if (!string.IsNullOrEmpty(pathToFile))
                sb.AppendLine($@"    /// {pathToFile}");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    [JsonObject(MemberSerialization.OptIn)]");
            sb.AppendLine($"    public class {ToTitleCase(name)}");
            sb.AppendLine("    {");
        }

        private void CloseClass(StringBuilder sb)
        {
            sb.AppendLine("    }");
        }

        private bool TryParseField(string line, out ParsedPropertyInfo propertyInfo)
        {
            propertyInfo = null;
            var ts = line.ToLower();
            var test = _normalizeType.Replace(ts, string.Empty);
           
            if (!_fieldRules.IsMatch(test))
                return false;

            var parts = test.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var name = string.Empty;
            if (parts.Length > 1)
                name = parts[1].Trim(' ', ';');

            var cmnt = string.Empty;
            if (parts.Length > 2)
                cmnt = string.Join(" ", parts.Skip(2)).Trim();

            if (parts.Length > 1 && name.IndexOf('(') == -1 && (parts.Length < 3 || cmnt.StartsWith("\\") || cmnt.StartsWith("=")))
            {
                var cppType = parts[0];
                var isComposit = IsCompositType(cppType);

                if (_knownTypes.ContainsKey(cppType) || isComposit)
                {
                    var sType = isComposit
                        ? GetKnownCompositType(cppType)
                        : GetKnownTypeOrDefault(cppType);

                    propertyInfo = new ParsedPropertyInfo
                    {
                        Type = sType,
                        CppType = cppType,
                        Name = name,
                        Comment = cmnt
                    };
                    return true;
                }
            }
            return false;
        }

        private void AddProperty(StringBuilder sb, ParsedPropertyInfo propertyInfo)
        {
            sb.AppendLine();
            sb.Append($@"        // bdType : {propertyInfo.CppType}");
            if (!string.IsNullOrEmpty(propertyInfo.Comment))
            {
                var info = propertyInfo.Comment;
                var startComment = info.IndexOf("//", StringComparison.Ordinal);
                if (startComment > 0 || startComment < 0)
                {
                    var addInfo = startComment > 0 ? info.Remove(startComment) : info;
                    sb.Append($" | {addInfo}");
                }
                sb.AppendLine();
                if (startComment >= 0 && startComment < info.Length)
                {
                    info = info.Remove(0, startComment);
                    info = info.Trim('/');
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine($"        /// {info}");
                    sb.AppendLine("        /// </summary>");
                }
            }
            else
            {
                sb.AppendLine();
            }
            sb.AppendLine($"        [JsonProperty(\"{propertyInfo.Name}\")]");
            sb.AppendLine($"        public {propertyInfo.Type} {ToTitleCase(propertyInfo.Name)} {{get; set;}}");
        }

        private string ToTitleCase(string name)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower()).Replace("_", string.Empty);
        }

        private bool IsCompositType(string line)
        {
            return line.StartsWith("map<")
                | line.StartsWith("set<")
                | line.StartsWith("vector<")
                | line.StartsWith("deque<")
                | line.StartsWith("optional<");
        }

        private string GetKnownCompositType(string line)
        {
            if (line.StartsWith("optional<"))
            {
                line = line.Replace("optional<", string.Empty);
                line = line.Remove(line.Length - 1);
            }

            if (line.Equals("vector<string>") || line.Equals("deque<string>") || line.Equals("set<string>"))
                return "string[]";

            if (line.StartsWith("vector<pair<") || line.StartsWith("deque<pair<") || line.StartsWith("set<pair<"))
            {
                var kvp = ToKeyValuePair(line, 2);
                return $"{kvp}[]";
            }


            if (line.StartsWith("set<") || line.StartsWith("vector<") || line.StartsWith("deque<"))
            {
                var buf = Unpack(line, 1);
                return $"{GetKnownTypeOrDefault(buf)}[]";
            }

            return "object";
        }

        private string Unpack(string line, int zIndex)
        {
            int startPos = 0;

            for (int i = 0; i < zIndex; i++)
            {
                startPos = line.IndexOf("<", startPos, StringComparison.Ordinal) + 1;
            }

            var buf = line.Remove(0, startPos);
            buf = buf.Remove(buf.Length - zIndex);
            return buf;
        }

        private string ToKeyValuePair(string line, int zIndex)
        {
            var buf = Unpack(line, zIndex);
            var kv = buf.Split(',');
            if (kv.Length != 2)
                return "KeyValuePair<object,object>";

            return $"KeyValuePair<{GetKnownTypeOrDefault(kv[0])},{GetKnownTypeOrDefault(kv[1])}>";
        }

        private string GetKnownTypeOrDefault(string cppType)
        {
            cppType = cppType.Trim();
            if (_knownTypes.ContainsKey(cppType))
                return _knownTypes[cppType];

            if (!_nameRules.IsMatch(cppType))
                return ToTitleCase(cppType);

            return "object";
        }
    }
}