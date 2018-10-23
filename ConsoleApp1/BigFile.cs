using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp1
{
    public sealed class BigFileAttribute : BaseBigFileAttribure
    {
        public BigFileAttribute() =>
            BigFileDecorator = new BigFileDecorator();

        public BigFileAttribute(string bigFileProperty) =>
            BigFileDecorator = new BigFileDecorator(bigFileProperty);

        public BigFileAttribute(Type type) =>
            BigFileDecorator = (IBigFileDecorator)Activator.CreateInstance(type);

        public BigFileAttribute(Type type, params object[] args) =>
            BigFileDecorator = (IBigFileDecorator)Activator.CreateInstance(type, args);

        public override IBigFileDecorator BigFileDecorator { get; }
    }
}
