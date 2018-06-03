using System;

namespace Ditch.EOS.Errors
{
    [Serializable]
    public abstract class ErrorBase : Exception
    {
        protected ErrorBase()
        {
        }

        protected ErrorBase(string key)
            : base(key) { }

        protected ErrorBase(LocalizationKeys key)
            : base(key.ToString()) { }
    }
}