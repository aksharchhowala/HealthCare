using System;
using System.Collections.Generic;
using System.Text;
using JsonDemo.ModelBuilder;

namespace JsonDemo
{
    class SHPartBuilder
    {
        //Declaring the Model class
        DctModel SHPartModel;
        
        //Construtor should containg default function
        public SHPartBuilder()
        {
            SHPartModel = new DctModel();
        }

        public DctModel ShPartDefault()
        {
            SHPartModel.SelectPart = "Home~AutometedTest";
            SHPartModel.MenuOperation = "Menu";

            AddPage("Page1");
            SHPartModel.Page["Page1"].Add(SHPart.IDdefault, "assign");
            SHPartModel.Page["Page1"].Add(SHPart.Name, "TestAutometed");
            SHPartModel.Page["Page1"].Add(SHPart.Revisiondefault, "assign");


            return SHPartModel;
        }

        public DctModel SHPartWithSAPId()
        {
            SHPartModel.Page.Add("Page2", new Dictionary<string, string>() {
                {SHPart.SAPId, "assign"},
                {SHPart.SAPName, "assign"},
                {SHPart.SAPRevision, "assign"}
            });

            return SHPartModel;
        }

        //Addes New page in the DctModel
        public void AddPage(string Page)
        {
            if (!SHPartModel.Page.ContainsKey(Page))
               SHPartModel.Page.Add(Page, new Dictionary<string, string>());
        }

    }
}
