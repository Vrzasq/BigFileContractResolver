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
            var bigFile = member.GetCustomAttribute<BaseBigFileAttribure>();

            if (bigFile != null)
                bigFile.BigFileDecorator.ModifyJsonProperty(jsonProperty);

            return jsonProperty;
        }
    }


}
