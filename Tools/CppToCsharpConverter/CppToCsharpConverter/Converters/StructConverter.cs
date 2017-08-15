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
        private readonly Regex _notTypeChar = new Regex("[^[a-z0-9_:<,>]]*", RegexOptions.Compiled | RegexOptions.ExplicitCapture);
        private readonly Regex _notNameChar = new Regex("[^[a-z0-9_]]*");
        private readonly Regex _pairType = new Regex("(?<=^([a-z0-90_:]*){1,}),(?=([a-z0-90_:]*){1,}$)|(?<=^([a-z0-90_:]*[<][a-z0-90_,:]*[>]){1,}),(?=([a-z0-90_:]*[<][a-z0-90_,:]*[>]){1,}$)");
        private readonly Regex _normalizeType = new Regex(@"((?<=<)\s*)|(\s*((?=>)))|((?<=[<][0-9_a-z\s]*[,])\s*)|(\b[a-z]*::\b)|");
        private readonly Regex _fieldRules = new Regex(@"^\s?[a-z0-9<,>_]*[ \t]{1,}[a-z0-9_]*\s*(=[a-z_0-9<,>\s]*)?;");

        private readonly Dictionary<string, string> _knownTypes = new Dictionary<string, string>
        {
            //id
            {"account_id_type", "object"},
            {"comment_id_type", "object"},
            {"id_type", "object"},
            {"feed_history_id_type", "object"},
            {"transaction_id_type", "object"},
            {"block_id_type", "object"}, //ripemd160
            {"checksum_type", "object"}, //ripemd160
            {"category_id_type", "object"},
            {"owner_authority_history_id_type", "object"},
            {"account_recovery_request_id_type", "object"},
            //system
            {"string", "string"},
            {"time_point_sec", "DateTime"},
            {"bool", "bool"},
            {"uint8_t", "byte"},
            {"uint16_t", "UInt16"},
            {"uint32_t", "UInt32"},
            {"uint64_t", "UInt64"},
            {"uint128_t", "string"},//<<<
            {"int16_t", "Int16"},
            {"int32_t", "Int32"},
            {"int64_t", "Int64"},
            {"uint8", "byte"},
            {"uint16", "UInt16"},
            {"uint32", "UInt32"},
            {"uint64", "UInt64"},
            {"uint128", "string"},//<<<
            {"int16", "Int16"},
            {"int32", "Int32"},
            {"int64", "Int64"},
            {"asset", "Money"},
            {"share_type", "object"},
            //enums
            {"comment_mode", "CommentMode"},
            {"follow_type", "FollowType"},
            //founded
            {"account_api_obj", "AccountApiObj"},
            {"extended_account", "ExtendedAccount"},
            {"discussion", "Discussion"},
            {"comment_api_obj", "CommentApiObj"},
            {"chain_properties", "ChainProperties"},
            {"price", "Price"},
            {"convert_request_object", "ConvertRequestObject"},
            {"convert_request_api_obj", "ConvertRequestApiObj"},
            {"account_bandwidth_object", "AccountBandwidthObject"},
            {"account_bandwidth_api_obj", "AccountBandwidthApiObj"},
            {"bandwidth_type", "BandwidthType"},
            {"authority", "Authority"},
            {"applied_operation", "AppliedOperation"},
            {"dynamic_global_property_object", "DynamicGlobalPropertyObject"},
            {"dynamic_global_property_api_obj", "DynamicGlobalPropertiesApiObj"},
            {"witness_schedule_object", "WitnessScheduleObject"},
            {"witness_schedule_api_obj", "WitnessScheduleApiObj"},
            {"vote_state", "VoteState"},
            {"tag_api_obj", "TagApiObj"},
            {"signed_block_api_obj", "SignedBlockApiObj"},
            {"signed_block", "SignedBlock"},
            {"signed_block_header", "SignedBlockHeader"},
            {"block_header", "BlockHeader"},
            {"owner_authority_history_api_obj", "OwnerAuthorityHistoryApiObj"},
            {"account_recovery_request_api_obj", "AccountRecoveryRequestApiObj"},
            {"escrow_object", "EscrowObject"},
            {"escrow_api_obj", "EscrowApiObj"},
            //other
            {"account_name_type", "string"},
            {"version", "string"},
            {"hardfork_version", "string"},
            //other
            {"account_authority_map", "object"},
            {"key_authority_map", "object"},
            {"public_key_type", "string"},
            {"category_index", "object"},
            {"tag_index", "object"},
            {"discussion_index", "object"},
            {"block_header_extensions_type", "object"},
            {"signed_transaction", "object"},
            {"signature_type", "object"},
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

        #region Print

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

        private void CloseClass(StringBuilder sb)
        {
            sb.AppendLine("    }");
        }

        private string ToTitleCase(string name)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower()).Replace("_", string.Empty);
        }

        #endregion


        #region Read

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

        private bool TryParseField(string line, out ParsedPropertyInfo propertyInfo)
        {
            propertyInfo = null;
            var ts = line.ToLower();
            var test = _normalizeType.Replace(ts, string.Empty);

            if (!_fieldRules.IsMatch(test))
                return false;

            var parts = test.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
                return false;

            var cppType = parts[0];
            if (_notTypeChar.IsMatch(cppType))
                return false;

            var name = parts[1].Trim(' ', ';');
            if (_notNameChar.IsMatch(name))
                return false;

            var coment = string.Empty;
            if (parts.Length > 2)
                coment = string.Join(" ", parts.Skip(2)).TrimStart(' ', '/', '<');

            var netType = cppType;
            if (netType.StartsWith("optional<"))
                netType = Unpack(netType, 1);

            netType = GetKnownTypeOrDefault(netType);

            propertyInfo = new ParsedPropertyInfo
            {
                Type = netType,
                CppType = cppType,
                Name = name,
                Comment = coment
            };
            return true;
        }

        private string GetKnownTypeOrDefault(string type)
        {
            if (type.IndexOf('<') > -1)
            {
                return GetKnownCompositType(type);
            }

            if (_knownTypes.ContainsKey(type))
                return _knownTypes[type];

            if (!_notNameChar.IsMatch(type))
                return ToTitleCase(type);

            return "object";
        }


        private string GetKnownCompositType(string line)
        {
            if (line.StartsWith("map<") || line.StartsWith("array<"))
                return "object";

            if (IsArray(line))
            {
                line = Unpack(line, 1);
                return $"{GetKnownTypeOrDefault(line)}[]";
            }
            if (line.StartsWith("pair<"))
            {
                var buf = Unpack(line, 1);

                var m = _pairType.Matches(buf);
                if (m.Count != 1)
                    return "KeyValuePair<object,object>";

                var index = m[0].Index;
                return $"KeyValuePair<{GetKnownTypeOrDefault(buf.Substring(0, index))},{GetKnownTypeOrDefault(buf.Substring(index + 1))}>";
            }

            return "object";
        }

        private bool IsArray(string line)
        {
            return line.StartsWith("set<")
                   | line.StartsWith("vector<")
                   | line.StartsWith("deque<");
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

        #endregion Read
    }
}