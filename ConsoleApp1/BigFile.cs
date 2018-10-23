using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp1
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class BigFileAttribute : BaseBigFileAttribure
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

        public override void Modify(ref JsonProperty jsonProperty)
        {
            PropertyInfo propertyInfo = jsonProperty.PropertyType.GetProperty(SizeCheckProperty);
            if (propertyInfo != null && propertyInfo.PropertyType.IsPrimitive)
            {
                jsonProperty = new JsonProperty
                {
                    PropertyName = jsonProperty.PropertyName,
                    PropertyType = propertyInfo.PropertyType,
                    Readable = true,
                    ValueProvider = new BigFileValueProvided(jsonProperty.ValueProvider, propertyInfo)
                };
            }
        }
    }
}
