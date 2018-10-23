using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp1
{
    public interface IBigFileDecorator
    {
        void ModifyJsonProperty(JsonProperty jsonProperty);
    }
}
