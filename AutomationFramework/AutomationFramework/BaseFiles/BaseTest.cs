﻿using AutomationFramework.Reporting;
using AutomationFramework.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationFramework.BaseFiles
{
    class BaseTest
    {
        /*Variables*/
        private static readonly string BrowserName = ConfigurationManager.AppSettings.Get("LinkedIn_LoginSite");
        public static ReportManager rm = new ReportManager();
        public static LibExcel objxls = new LibExcel();
        public static ExtentV3HtmlReporter htmlReporter;
        public static ExtentReports extent;
        public static ExtentTest test;
        public static IWebDriver driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            if (htmlReporter == null)
            {
                htmlReporter = new ExtentV3HtmlReporter(rm.ReportPath());
            }

            if (extent == null)
            {
                extent = new ExtentReports();
                rm.ReportSetUp(htmlReporter, extent);
            }
        }

        [SetUp]
        public void BeforeTest()
        {
            SetUpDriver();
            objxls.FilePath = @"C:\Tools\DataDriven.xlsx";
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            extent.Flush();
        }

        [TearDown]
        public void AfterTest()
        {
            rm.TestCaseResult(test, extent, driver);
            ExitDriver();
        }
        
        public void SetUpDriver()
        {
            driver = new ChromeDriver();
            driver.Url = BrowserName;
            driver.Manage().Window.Maximize();
        }

        public void ExitDriver()
        {
            driver.Quit();
        }

        public static IWebElement FindElements(IWebDriver driver, By by, int timeOutSeconds)
        {
            if (timeOutSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutSeconds));
                return wait.Until(dvr => dvr.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static void WaitElementToBeClickable(IWebDriver driver, By by, int timeOutSeconds)
        {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutSeconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static void WaitToContinue()
        {
            Thread.Sleep(3000);
        }

        public static void WaitToContinue(int pMiliseconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(pMiliseconds));
        }
    }
}
