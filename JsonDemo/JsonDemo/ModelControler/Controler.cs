using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using JsonDemo.ModelBuilder;

namespace JsonDemo
{
    class Controler
    {
        private Controler() { }

        public static Controler Instance { get { return new Controler(); } }

        public string CheckWizadFields(DctModel dctModel)
        {
            dctModel.operation = "CheckField";
            return OperateOnFields(dctModel);
        }

        public string CompleteWizadValue(DctModel dctModel)
        {
            dctModel.operation = "CompleteFiled";
            return OperateOnFields(dctModel);
        }

        private string OperateOnFields(DctModel dctModel)
        {
            if (dctModel.MenuOperation != null || !dctModel.MenuOperation.Equals(""))
                Console.WriteLine(dctModel.MenuOperation);

            if (dctModel.SelectPart != null || !dctModel.SelectPart.Equals(""))
                Console.WriteLine(dctModel.SelectPart);
            int pageCounter = 0;
            foreach (var page in dctModel.Page.Keys)
            {
                foreach (var prop in dctModel.Page[page].Keys)
                {
                    var Section = dctModel.Page[page];


                    if (Section[prop].ToString().Equals("HookMethod"))
                        Console.WriteLine("Call HookMethod");
                    else if (Section[prop].ToString().Equals("SpecialCase"))
                        Console.WriteLine("Call SpecialCase");
                    else
                    {
                        try
                        {
                            string propName = String.Empty;
                            string propType = GetPropertyType(prop, out propName);
                            string propValue = Section[prop];

                            Type methodType = this.GetType();
                            MethodInfo theMethod = methodType.GetMethod(dctModel.operation + propType);
                            theMethod.Invoke(this, new object[] { propName, propValue });
                        }
                        catch(Exception e)   
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }

                // Implement Next button click function
            }

            while (pageCounter!=0)
            {
                //implement Back button function
            }

            // Implement geting Item Name function 

            return "";
        }

        public string CompleteFiledButton(string propName, string propValue)
        {
            Console.WriteLine("{0}, {1}",propName,propValue);
            return "";
        }

        public string CompleteFiledTextField(string propName, string propValue)
        {
            Console.WriteLine("{0}, {1}", propName, propValue);
            return "";
        }

        public string CheckFieldButton(string propName, string propValue)
        {
            Console.WriteLine("{0}, {1}", propName, propValue);
            return "";
        }

        public string CheckFieldTextField(string propName, string propValue)
        {
            Console.WriteLine("{0}, {1}", propName, propValue);
            return "";
        }

        public string GetPropertyType(string prop, out string propName)
        {
            if (prop == null || prop.Equals(""))
            {
                propName = "";
                return "";
            }
            else
            {
                var proprties = prop.Split('|');
                propName = proprties[0];
                return proprties[1];
            }
        }
    }
}
