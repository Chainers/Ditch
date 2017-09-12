﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ditch.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Tests
{
    public class BaseTest
    {
        protected readonly Dictionary<string, string> Login;
        protected readonly Dictionary<string, ChainInfo> Chain;
        protected readonly OperationManager Steem;
        protected readonly OperationManager Golos;
        protected readonly Dictionary<string, List<byte[]>> UserPrivateKeys;

        public BaseTest()
        {
            Login = new Dictionary<string, string>()
            {
                {"Steem", "UserLogin"},
                {"Golos", "UserLogin"}
            };

            UserPrivateKeys = new Dictionary<string, List<byte[]>>()
            {
                {"Steem", new List<byte[]> {Base58.TryGetBytes("5**************************************************")}},
                {"Golos", new List<byte[]> {Base58.TryGetBytes("5**************************************************")}}
            };

            Chain = new Dictionary<string, ChainInfo>();

            var steemChainInfo = ChainManager.GetChainInfo(KnownChains.Steem);
            Chain.Add("Steem", steemChainInfo);
            Steem = new OperationManager(steemChainInfo.Url, steemChainInfo.ChainId);

            var golosChainInfo = ChainManager.GetChainInfo(KnownChains.Golos);
            Chain.Add("Golos", golosChainInfo);
            Golos = new OperationManager(golosChainInfo.Url, golosChainInfo.ChainId);
        }

        protected OperationManager Manager(string name)
        {
            switch (name)
            {
                case "Steem":
                    return Steem;
                case "Golos":
                    return Golos;
                default:
                    return null;
            }
        }

        protected void TestPropetries(Type type, JObject jObject)
        {
            var propNames = GetPropertyNames(type);

            var chSet = jObject.Children();

            List<string> msg = new List<string>();
            foreach (var jtoken in chSet)
            {
                if (!propNames.Contains(jtoken.Path))
                {
                    msg.Add($"Missing {jtoken}");
                }
            }

            if (msg.Any())
            {
                Assert.Fail($"Some properties ({msg.Count}) was missed! {Environment.NewLine} {string.Join(Environment.NewLine, msg)}");
            }
        }

        protected void TestPropetries(Type type, JObject[] jObject)
        {
            if (jObject == null)
                throw new NullReferenceException("jObject");

            if (type.IsArray)
            {
                if (jObject.Length > 0)
                    TestPropetries(type.GetElementType(), jObject[0]);
                else
                    throw new NullReferenceException("Impossible to do test for this input data!");
            }
            else
                throw new InvalidCastException();
        }

        protected HashSet<string> GetPropertyNames(Type type)
        {
            var props = type.GetRuntimeProperties();
            var resp = new HashSet<string>();
            foreach (var prop in props)
            {
                var order = prop.GetCustomAttribute<JsonPropertyAttribute>();
                if (order != null)
                {
                    resp.Add(order.PropertyName);
                }
            }
            return resp;
        }
    }
}