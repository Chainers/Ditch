using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ditch.EOS.Models;

namespace Ditch.EOS
{
    public class ContractCodeGenerator
    {

        public Task Generate(OperationManager api, string contractName, string @namespace, string outDir, CancellationToken token)
        {
            return Generate(api, contractName, @namespace, outDir, null, token);
        }

        public async Task Generate(OperationManager api, string contractName, string @namespace, string outDir, HashSet<string> actionFilter, CancellationToken token)
        {
            var args = new GetCodeParams
            {
                AccountName = contractName
            };

            var resp = await api.GetCode(args, token);
            if (resp.IsError)
                throw resp.Error;

            var abi = resp.Result.Abi;

            var contractPath = InitDirs(outDir, contractName);

            var structNamespace = $"{@namespace}.{contractName.ToTitleCase()}.Structs";
            var actionsNamespace = $"{@namespace}.{contractName.ToTitleCase()}.Actions";

            var generator = new ContractCodeGenerator();

            HashSet<string> stuctFilter = new HashSet<string>();
            foreach (var action in abi.Actions)
            {
                if (actionFilter != null && !actionFilter.Contains(action.Name))
                    continue;

                generator.ActionToClass($@"{contractPath}\Actions\", actionsNamespace, structNamespace, contractName, action, abi);

                AddAllRef(abi, stuctFilter, action.Type);
            }

            foreach (var itm in abi.Structs)
            {
                if (!stuctFilter.Contains(itm.Name))
                    continue;
                generator.StructToClass($@"{contractPath}\Structs\", structNamespace, itm, abi);
            }
        }

        private void AddAllRef(AbiDef abiDef, HashSet<string> stuctFilter, string typeName)
        {
            var s = abiDef.Structs.FirstOrDefault(i => i.Name.Equals(typeName));
            if (s != null)
            {
                if (!stuctFilter.Contains(typeName))
                {
                    stuctFilter.Add(typeName);

                    foreach (var f in s.Fields)
                    {
                        AddAllRef(abiDef, stuctFilter, f.Type);
                    }
                }
            }
        }


        public void StructToClass(string outDirPath, string structNamespace, StructDef str, AbiDef abi)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream($"{outDirPath}{str.Name.ToTitleCase()}.cs", FileMode.OpenOrCreate);
                sw = new StreamWriter(fs);
                StructToClass(sw, structNamespace, str, abi);
            }
            finally
            {
                sw?.Dispose();
                fs?.Dispose();
            }
        }

        public void ActionToClass(string outDirPath, string actionsNamespace, string structNamespace, string contractName, ActionDef action, AbiDef abi)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream($"{outDirPath}{action.Name.ToTitleCase()}Action.cs", FileMode.OpenOrCreate);
                sw = new StreamWriter(fs);
                ActionToClass(sw, actionsNamespace, structNamespace, contractName, action, abi);
            }
            finally
            {
                sw?.Dispose();
                fs?.Dispose();
            }
        }

        public void StructToClass(StreamWriter sw, string structNamespace, StructDef str, AbiDef abi)
        {
            sw.WriteLine("using Newtonsoft.Json;");
            sw.WriteLine("using Ditch.EOS;");
            sw.WriteLine("using Ditch.Core.Models;");
            sw.WriteLine("using Ditch.EOS.Models;");
            sw.WriteLine();
            sw.WriteLine($"namespace {structNamespace}");
            sw.WriteLine("{");

            var inden = new string(' ', 4);
            sw.WriteLine($"{inden}[JsonObject(MemberSerialization.OptIn)]");
            sw.WriteLine($"{inden}public class {str.Name.ToTitleCase()}");
            sw.WriteLine($"{inden}{{");

            foreach (var field in str.Fields)
            {
                sw.WriteLine($"{inden}{inden}[JsonProperty(\"{field.Name}\")]");
                sw.WriteLine($"{inden}{inden}public {GetType(field.Type, abi)} {field.Name.ToTitleCase()} {{get; set;}}");
                sw.WriteLine();
            }

            sw.WriteLine($"{inden}}}");
            sw.WriteLine("}");
        }

        public void ActionToClass(StreamWriter sw, string actionsNamespace, string structNamespace, string contractName, ActionDef action, AbiDef abi)
        {
            sw.WriteLine("using Newtonsoft.Json;");
            sw.WriteLine("using Ditch.EOS;");
            sw.WriteLine($"using {structNamespace};");
            sw.WriteLine("using Ditch.EOS.Models;");
            sw.WriteLine();
            sw.WriteLine($"namespace {actionsNamespace}");
            sw.WriteLine("{");

            var inden = new string(' ', 4);
            sw.WriteLine($"{inden}[JsonObject(MemberSerialization.OptIn)]");
            sw.WriteLine($"{inden}public class {action.Name.ToTitleCase()}Action : BaseAction");
            sw.WriteLine($"{inden}{{");
            sw.WriteLine($"{inden}{inden}public const string ContractName = \"{contractName}\";");
            sw.WriteLine($"{inden}{inden}public const string ActionName = \"{action.Name}\";");
            sw.WriteLine();
            sw.WriteLine($"{inden}{inden}public {action.Name.ToTitleCase()}Action() : base(ContractName, ActionName) {{ }}");
            sw.WriteLine();

            var str = abi.Structs.FirstOrDefault(i => i.Name.Equals(action.Type));
            if (str != null && str.Fields.Any())
            {
                sw.WriteLine($"{inden}{inden}public {action.Name.ToTitleCase()}Action(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels, {action.Type.ToTitleCase()} args)");
                sw.WriteLine($"{inden}{inden}    : base(ContractName, accountName, ActionName, permissionLevels, args) {{ }}");
            }
            else
            {
                sw.WriteLine($"{inden}{inden}public {action.Name.ToTitleCase()}Action(string accountName, Ditch.EOS.Models.PermissionLevel[] permissionLevels)");
                sw.WriteLine($"{inden}{inden}    : base(ContractName, accountName, ActionName, permissionLevels, null) {{ }}");
            }
            sw.WriteLine($"{inden}}}");
            sw.WriteLine("}");
        }

        public virtual string GetType(string type, AbiDef contract)
        {
            switch (type)
            {
                case "string":
                case "shared_string":
                case "fixed_string":
                    return "string";
                case "int":
                case "int32":
                case "int32_t":
                    return "int";
                case "uint8_t":
                case "uint8":
                case "int8":
                    return "byte";
                case "uint16_t":
                case "uint16":
                    return "ushort";
                case "uint32_t":
                case "uint32":
                    return "uint";
                case "uint64_t":
                case "uint64":
                    return "ulong";
                case "uint128_t":
                case "uint128":
                    return "UInt128";
                case "int16_t":
                case "int16":
                    return "short";
                case "int64_t":
                case "int64":
                    return "long";
                case "bool":
                    return "bool";
                case "char":
                    return "char";
                case "double":
                case "float64":
                    return "double";
                case "float32":
                    return "float";
                case "variant_object":
                    return "object";
                case "share_type":
                    return "object";
                case "name":
                    return "BaseName";
                case "checksum256":
                    return "string";
                default:
                    {
                        var t = contract.Types.FirstOrDefault(i => i.NewTypeName.EndsWith(type));

                        if (t != null)
                            return GetType(t.Type, contract);

                        return type.ToTitleCase();
                    }
            }
        }

        private string InitDirs(string outDir, string contractName)
        {
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            var contractPath = outDir + contractName.ToTitleCase();

            if (!Directory.Exists(contractPath))
                Directory.CreateDirectory(contractPath);

            var structPath = contractPath + @"\Structs";

            if (!Directory.Exists(structPath))
                Directory.CreateDirectory(structPath);

            var actionsPath = contractPath + @"\Actions";

            if (!Directory.Exists(actionsPath))
                Directory.CreateDirectory(actionsPath);

            return contractPath;
        }
    }

    public static class StringHelper
    {
        public static string ToTitleCase(this string name, bool firstUpper = true)
        {
            var sb = new StringBuilder(name);
            for (var i = 0; i < sb.Length; i++)
            {
                if (i == 0 && firstUpper)
                    sb[i] = char.ToUpper(sb[i]);

                if ((sb[i] == '_' || sb[i] == '.') && i + 1 < sb.Length)
                    sb[i + 1] = char.ToUpper(sb[i + 1]);
            }
            sb.Replace("_", string.Empty);
            sb.Replace(".", string.Empty);
            var rez = sb.ToString();
            if (rez.Equals("params"))
                rez = "parameters";

            return rez;
        }
    }
}
