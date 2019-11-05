using AutomationFramework.BaseFiles;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.PageObjects
{
    class LinkedIn_PerformSearchPage : BaseTest
    {
        /*DRIVER REFERENCE FOR THIS PARTICULAR POM*/
        private IWebDriver _driver;


        /*LOCATORS FRO EACH AND EVERY ELEMENT IN PAGE*/
        readonly string SEARCH_TXT = "//input[@class='search-global-typeahead__input always-show-placeholder']";
        readonly string SEARCH_ICON_BTN = "//div[@class='search-global-typeahead__controls']/button";
        readonly string PEOPLE_FILTER_BTN = "//button[span[text()='Gente' or text()='People']]";


        /*POM FILE CONSTRUCTOR BY TAKING AS PARAMETER "DRIVER" FROM BASETEST CLASS*/
        public LinkedIn_PerformSearchPage(IWebDriver driver)
        {
            _driver = driver;
        }


        /*LOCATORS VALUES STORED AS IWebElement OBJECTS TO BE USED IN FRAMEWORK THROUGH METHODS FROM THIS POM CLASS*/
        /*SET*/
        private IWebElement SearchTextboxField =>   FindElements(_driver, By.XPath(SEARCH_TXT), 5);
        private IWebElement SearchIconField =>      FindElements(_driver, By.XPath(SEARCH_ICON_BTN), 10);
        private IWebElement PeopleFilterField =>    FindElements(_driver, By.XPath(PEOPLE_FILTER_BTN), 10);


        /*METHODS FOR ACCESING TO WEBELEMENTS FROM THIS PARTICULAR POM CLASS*/

        /*Search Textbox*/
        private IWebElement GetSearchTextBoxField()
        {
            return SearchTextboxField;
        }

        public void EnterSearchTextBoxField(string pstrKeyword)
        {
            SearchTextboxField.Clear();
            SearchTextboxField.SendKeys(pstrKeyword);
        }

        /*Search Icon*/
        private IWebElement GetSearchIconField()
        {
            return SearchIconField;
        }

        public void ClickSearchIconField()
        {
            SearchIconField.Click();
        }

        /*Vertical Serach Filter (People, contacts, Location)*/
        private IWebElement GetSearchVerticalField()
        {
            return PeopleFilterField;
        }

        public void PeopleFilterButton()
        {
            PeopleFilterField.Click();
        }


    }
}
