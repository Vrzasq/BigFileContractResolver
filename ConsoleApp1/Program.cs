using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sw = new Stopwatch();

            Console.WriteLine(JsonConvert.SerializeObject(new MyClass(), SerializationSettings));
            Console.WriteLine(JsonConvert.SerializeObject(new Class1(), SerializationSettings));

            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                string someobj = JsonConvert.SerializeObject(new MyClass(), SerializationSettings);
            }
            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds.ToString());

            sw.Restart();
            for (int i = 0; i < 100000; i++)
            {
                string someobj = JsonConvert.SerializeObject(new MyClass());
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds.ToString());
        }

        private static JsonSerializerSettings SerializationSettings =
            new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new BigFileContractResolver()
            };
    }
}