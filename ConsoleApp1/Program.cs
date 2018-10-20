using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string someobj = JsonConvert.SerializeObject(new MyClass(), SerializationSettings);
            Console.WriteLine(someobj);
        }

        private static JsonSerializerSettings SerializationSettings =>
            new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new BigFileContractResolver()
            };
    }
}