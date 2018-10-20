using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class MyClass
    {
        public MyClass()
        {
            Name = "dupa";
            Surname = "aoisdua";
            File = new byte[1024];
            Lista = new List<int>();
            LoL = new MyClass2();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 1001; i++)
            {
                sb.Append(i.ToString());
                Lista.Add(i);
            }

            Data = sb.ToString();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        [BigFile]
        public string Data { get; set; }
        [BigFile]
        public byte[] File { get; set; }
        [BigFile("Count")]
        public List<int> Lista { get; set; }
        [BigFile("MyProperty")]
        public MyClass2 LoL { get; set; }
    }
}
