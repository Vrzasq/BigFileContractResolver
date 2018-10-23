using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class MyClass2
    {
        public MyClass2()
        {
            //MyProperty = new byte[1024];
        }

        [BigFile]
        public byte[] MyProperty { get; set; }
    }
}
