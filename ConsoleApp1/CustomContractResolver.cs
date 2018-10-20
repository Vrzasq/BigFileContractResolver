using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp1
{
    public class BigFileContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty jsonProperty = base.CreateProperty(member, memberSerialization);

            var bigFile = member.GetCustomAttribute<BigFileAttribute>();

            if (bigFile != null)
            {
                PropertyInfo propertyInfo = jsonProperty.PropertyType.GetProperty(bigFile.SizeCheckProperty);

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

            return jsonProperty;
        }
    }

    public class BigFileValueProvided : IValueProvider
    {
        private readonly IValueProvider valueProvider;
        private readonly PropertyInfo propertyInfo;

        public BigFileValueProvided(IValueProvider valueProvider, PropertyInfo propertyInfo)
        {
            this.valueProvider = valueProvider;
            this.propertyInfo = propertyInfo;
        }

        public object GetValue(object target)
        {
            var value = valueProvider.GetValue(target);
            var propertyValue = propertyInfo.GetValue(value);
            return propertyValue;
        }

        public void SetValue(object target, object value) =>
            valueProvider.SetValue(target, value);
    }
}
