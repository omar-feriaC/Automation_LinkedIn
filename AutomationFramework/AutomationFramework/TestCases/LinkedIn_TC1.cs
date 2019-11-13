using AutomationFramework.BaseFiles;
using AutomationFramework.PageObjects;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.TestCases
{
    class LinkedIn_TC1 : BaseTest
    {
        LinkedIn_LoginPage objLogin;
        LinkedIn_PerformSearchPage objSearch;

        [Test]
        public void LinkedIn_Login()
        {            
            //Init objects/variables
            objLogin = new LinkedIn_LoginPage(driver);
            objSearch = new LinkedIn_PerformSearchPage(driver);
            //Variables
            string strLocation =  "México";
            string strLanguajes =  "en;es";
            int counter = 0;
            string line;

            //Step 0: Set Test Case Name
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            //Step 1: Login to LinkedIn Portal
            test.Log(Status.Info, "Login Starts");
            if (objLogin.fnLogin())
            {
                //Step 2: Setup Intial Filter
                test.Log(Status.Info, "Set Initial Criteria/Filters");
                objSearch.FnEnterCriteriaAndFilterByPeople("Test");
                objSearch.FnEnterAllFilters(strLocation, strLanguajes);
                WaitToContinue(3);
                //objSearch.ClickHomeButton();

                //Step 3: Open/Read Text File
                test.Log(Status.Info, "Read Input File");
                System.IO.StreamReader file = new System.IO.StreamReader(ConfigurationManager.AppSettings.Get("dataPath"));
                while ((line = file.ReadLine()) != null)
                {
                    /*Step 3: Perform first search*/
                    if (!line.Contains("*"))
                    {
                        objSearch.FnSearchKeyword(line);
                        objSearch.FnGetResults(line.ToString());

                        //objSearch.ClickHomeButton();
                    }
                    counter++;
                }
                //Step: Close input file
                file.Close();
            }
            else
            {
                Assert.Fail();
                Console.WriteLine("An error has occurred with the login.");
            }

        }
    }
}
