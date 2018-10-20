using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class BigFileAttribute : Attribute
    {
        public BigFileAttribute()
        {
            SizeCheckProperty = nameof(string.Length);
        }

        public BigFileAttribute(string sizeCheckProperty)
        {
            SizeCheckProperty = sizeCheckProperty;
        }

        public string SizeCheckProperty { get; set; }
    }
}
