using System.IO;
using Ditch.Core.Interfaces;
using Ditch.Steem.Operations;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Operation : ICustomSerializer
    {
        private BaseOperation _baseOperation;


        public Operation() { }

        public Operation(BaseOperation baseOperation)
        {
            _baseOperation = baseOperation;
        }



        public static implicit operator BaseOperation(Operation d)
        {
            return d._baseOperation;
        }

        public static implicit operator Operation(BaseOperation baseOperation)
        {
            return new Operation(baseOperation);
        }

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            serializeHelper.AddToMessageStream(stream, _baseOperation.GetType(), _baseOperation);
        }

        #endregion
    }
}