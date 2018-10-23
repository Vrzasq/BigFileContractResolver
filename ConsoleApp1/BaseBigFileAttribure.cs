using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp1
{
    public abstract class BaseBigFileAttribure : BaseAttrib
    {
        public abstract IBigFileDecorator BigFileDecorator { get; }
    }
}
