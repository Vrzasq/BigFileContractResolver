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
                string someobj = JsonConvert.SerializeObject(new MyClass(), Formatting.Indented);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds.ToString());
            sw.Reset();
        }

        private static JsonSerializerSettings SerializationSettings =
            new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new BigFileContractResolver()
            };
    }
}