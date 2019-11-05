using AutomationFramework.BaseFiles;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.PageObjects
{
    class LinkedIn_LoginPage : BaseTest
    {
        /*DRIVER REFERENCE FOR THIS PARTICULAR POM*/
        private IWebDriver _driver;


        /*LOCATORS FRO EACH AND EVERY ELEMENT IN PAGE*/
        readonly string USERNAME_TXT = "username";
        readonly string PASSWORD_TXT = "password";
        readonly string SINGIN_BTN = "//button[text()='Sign in']";


        /*POM FILE CONSTRUCTOR BY TAKING AS PARAMETER "DRIVER" FROM BASETEST CLASS*/
        public LinkedIn_LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /*LOCATORS VALUES STORED AS IWebElement OBJECTS TO BE USED IN FRAMEWORK THROUGH METHODS FROM THIS POM CLASS*/
        /*SET*/
        private IWebElement UserNameTxtField => _driver.FindElement(By.Id(USERNAME_TXT));
        private IWebElement PasswordTxtField => _driver.FindElement(By.Id(PASSWORD_TXT));
        private IWebElement SignIngBtn => _driver.FindElement(By.XPath(SINGIN_BTN));



        /*METHODS FOR ACCESING TO WEBELEMENTS FROM THIS PARTICULAR POM CLASS*/
        
        /*User Name*/
        private IWebElement GetUserNameTxtField()
        {
            return UserNameTxtField;
        }

        public void EnterUserNameTxtField(string strUserName)
        {
            UserNameTxtField.Clear();
            UserNameTxtField.SendKeys(strUserName);
        }

        /*Password*/
        private IWebElement GetPasswordTxtField()
        {
            return PasswordTxtField;
        }

        public void EnterPasswordTxtField(string strPassword)
        {
            PasswordTxtField.Clear();
            PasswordTxtField.SendKeys(strPassword);
        }

        //SignIn BUTTTON
        private IWebElement GetSignInButton()
        {
            return SignIngBtn;
        }

        public void ClickSignInButton()
        {
            SignIngBtn.Click();
        }



    }
}
