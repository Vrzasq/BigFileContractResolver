using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp1
{
    public class BigFileDecorator : IBigFileDecorator
    {
        public BigFileDecorator()
        {
            SizeCheckProperty = nameof(string.Length);
        }

        public BigFileDecorator(string sizeCheckProperty)
        {
            SizeCheckProperty = sizeCheckProperty;
        }

        public string SizeCheckProperty { get; set; }

        public virtual void ModifyJsonProperty(JsonProperty jsonProperty)
        {
            PropertyInfo propertyInfo = jsonProperty.PropertyType.GetProperty(SizeCheckProperty);
            if (propertyInfo != null)
            {
                jsonProperty.PropertyType = typeof(string);
                jsonProperty.Readable = true;
                jsonProperty.ValueProvider = GetValueProvider(jsonProperty.ValueProvider, propertyInfo);
            }
        }

        protected virtual IValueProvider GetValueProvider(IValueProvider valueProvider, PropertyInfo propertyInfo) =>
            new BigFileValueProvided(valueProvider, propertyInfo);
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
            string serializedMessage = GetSerializedMessage(value, propertyInfo);
            return serializedMessage;
        }

        public void SetValue(object target, object value) =>
            valueProvider.SetValue(target, value);

        private string GetSerializedMessage(object value, PropertyInfo propertyInfo)
        {
            if (value == null)
                return null;

            var propertyValue = propertyInfo.GetValue(value);
            return $"{propertyInfo.Name} {propertyValue.ToString()}";
        }
    }
}
