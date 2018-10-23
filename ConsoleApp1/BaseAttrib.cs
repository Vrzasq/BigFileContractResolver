using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class BaseAttrib : Attribute
    {
    }
}
