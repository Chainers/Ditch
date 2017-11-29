using System;

namespace Ditch.Golos.Helpers
{
    /// <summary>
    /// Serialization is sensitive to the order of the properties!
    /// Instead of [StructLayout (LayoutKind.Sequential)], uses MessageOrderAttribute. 
    /// That allows not only to specify the order, but also, to add in the class additional properties
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class MessageOrderAttribute : Attribute
    {
        public readonly int Value;

        public MessageOrderAttribute(int value)
        {
            Value = value;
        }
    }
}
