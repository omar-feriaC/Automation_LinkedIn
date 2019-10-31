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

        [Test]
        public void LinkedIn_Login()
        {
            objLogin = new LinkedIn_LoginPage(driver);
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            objLogin.EnterUserNameTxtField(ConfigurationManager.AppSettings.Get("username"));
            objLogin.EnterPasswordTxtField(ConfigurationManager.AppSettings.Get("password"));
            objLogin.ClickSignInButton();
        }
    }
}
