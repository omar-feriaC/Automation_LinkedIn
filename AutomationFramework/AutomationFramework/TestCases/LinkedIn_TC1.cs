using AutomationFramework.BaseFiles;
using AutomationFramework.PageObjects;
using NUnit.Framework;
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
            /*Step 1: Login to LinkedIn Portal*/
            objLogin = new LinkedIn_LoginPage(driver);
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            objLogin.EnterUserNameTxtField(ConfigurationManager.AppSettings.Get("username"));
            objLogin.EnterPasswordTxtField(ConfigurationManager.AppSettings.Get("password"));
            objLogin.ClickSignInButton();

            /*Step 2: Perform first search*/
            objSearch = new LinkedIn_PerformSearchPage(driver);
            objSearch.EnterSearchTextBoxField("Pega");
            objSearch.ClickSearchIconField();
            objSearch.PeopleFilterButton();
            



        }
    }
}
