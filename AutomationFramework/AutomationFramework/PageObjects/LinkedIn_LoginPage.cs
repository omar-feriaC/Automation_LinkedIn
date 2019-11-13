using AutomationFramework.BaseFiles;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.PageObjects
{
    class LinkedIn_LoginPage : BaseTest
    {
        /*DRIVER REFERENCE FOR THIS PARTICULAR POM*/
        private static IWebDriver _driver;


        /*LOCATORS FRO EACH AND EVERY ELEMENT IN PAGE*/
        readonly static string USERNAME_TXT = "username";
        readonly static string PASSWORD_TXT = "password";
        readonly static string SINGIN_BTN = "//button[text()='Sign in']";


        /*POM FILE CONSTRUCTOR BY TAKING AS PARAMETER "DRIVER" FROM BASETEST CLASS*/
        public LinkedIn_LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /*LOCATORS VALUES STORED AS IWebElement OBJECTS TO BE USED IN FRAMEWORK THROUGH METHODS FROM THIS POM CLASS*/
        /*SET*/
        private static IWebElement UserNameTxtField => _driver.FindElement(By.Id(USERNAME_TXT));
        private static IWebElement PasswordTxtField => _driver.FindElement(By.Id(PASSWORD_TXT));
        private static IWebElement SignIngBtn => _driver.FindElement(By.XPath(SINGIN_BTN));



        /*METHODS FOR ACCESING TO WEBELEMENTS FROM THIS PARTICULAR POM CLASS*/
        
        /*User Name*/
        private static IWebElement GetUserNameTxtField()
        {
            return UserNameTxtField;
        }

        public static void EnterUserNameTxtField(string strUserName)
        {
            UserNameTxtField.Clear();
            UserNameTxtField.SendKeys(strUserName);
        }

        /*Password*/
        private static IWebElement GetPasswordTxtField()
        {
            return PasswordTxtField;
        }

        public static void EnterPasswordTxtField(string strPassword)
        {
            PasswordTxtField.Clear();
            PasswordTxtField.SendKeys(strPassword);
        }

        //SignIn BUTTTON
        private static IWebElement GetSignInButton()
        {
            return SignIngBtn;
        }

        public static void ClickSignInButton()
        {
            SignIngBtn.Click();
        }

        /*METHODS AND FUNCTIONS*/
        public bool fnLogin()
        {
            try
            {
                bool bStatus = false;
                EnterUserNameTxtField(ConfigurationManager.AppSettings.Get("username"));
                EnterPasswordTxtField(ConfigurationManager.AppSettings.Get("password"));
                ClickSignInButton();
                if (!_driver.Title.StartsWith("LinkedIn: Log In or Sign Up"))
                {
                    bStatus = true;
                }
                else
                {
                    bStatus = false;
                }
                return bStatus;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            
        }

    }
}
