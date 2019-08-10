using System;
using System.Collections.Generic;
using System.Data;
using JsonDemo.ModelBuilder; 

namespace JsonDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SHPartBuilder shBuilder = new SHPartBuilder();
            Controler.Instance.CompleteWizadValue(shBuilder.ShPartDefault());
            SHPartBuilder shPartBuilder2 = new SHPartBuilder();
            Controler.Instance.CheckWizadFields(shPartBuilder2.SHPartWithSAPId());

        }
    }

}
