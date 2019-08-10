using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace JsonDemo.ModelBuilder
{
    /// <summary>
    /// Custamized Model Object for Automation
    /// </summary>
    public class DctModel
    {
        public DctModel()
        {
            HookMethod = new Dictionary<string, string[]>();
            SpecialCase = new Dictionary<string, Dictionary<string, DctModel>>();
            Page = new Dictionary<string, Dictionary<string, string>>();
            operation = string.Empty;
            MenuOperation = string.Empty;
            SelectPart = string.Empty;
        }

        //Type of operation to be performed
        public string operation { get; set; }

        //Menu operation to be performed before method
        public string MenuOperation { get; set; }

        //To select folder where 
        public string SelectPart { get; set; }

        //Page on which the fields are present and there property name and value
        public Dictionary<string, Dictionary<string,string>> Page { get; set; }

        //Hook method to call any method and paramenters of the method
        // eg : DctModel.HookMethod.Add("MethodName",new string[]{Parameter1, Parameter2, Parameter3});
        //      DctModel.Page[Page1].Add("HookMethod","MethodName");
        public Dictionary<string, string[]> HookMethod { get; set; }

        //Used only in special case where we have nested View 
        // eg : DctModel.SpecialCase.Add("NestedModel", DctModel);
        //      DctModel.Page[Page1].Add("SpecialCase", "NestedModel");
        public Dictionary<string, Dictionary<string,DctModel>> SpecialCase { get; set; }

        //...If More need for properties requried add code for that...\\
    }
}