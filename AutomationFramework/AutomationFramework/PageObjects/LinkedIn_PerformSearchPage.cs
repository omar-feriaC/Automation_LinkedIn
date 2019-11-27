using AutomationFramework.BaseFiles;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.PageObjects
{
    class LinkedIn_PerformSearchPage : BaseTest
    {
        /*DRIVER REFERENCE FOR THIS PARTICULAR POM*/
        private static IWebDriver _driver;

        /*LOCATORS FRO EACH AND EVERY ELEMENT IN PAGE*/
        //readonly static string SEARCH_TXT = "//input[@class='search-global-typeahead__input always-show-placeholder']";
        readonly static string SEARCH_TXT = "//input[@class='search-global-typeahead__input']";
        readonly static string SEARCH_ICON_BTN = "//button[@class='search-typeahead-v2__button search-global-typeahead__button']";
        readonly static string PEOPLE_FILTER_BTN = "//button[span[text()='Gente' or text()='People']]";
        readonly static string HOME_BTN = "//*[@id='feed-nav-item']";
        readonly static string ALL_FILTER_BTN = "//button[@data-control-name='all_filters']";
        readonly static string LOCATION_TXT = "(//input[contains(@placeholder, 'Add a country/region') or contains(@placeholder, 'Añadir un país o región')])[1]";
        readonly static string APPLY_BTN = "//button[@data-control-name='all_filters_apply']";
        readonly static string PAG_BUTTON = "//li[@class='artdeco-pagination__indicator artdeco-pagination__indicator--number active selected']";
        private static string CANDIDATE_NAME;
        private static string CANDIDATE_ROLE;
        private static string CANDIDATE_PROFILE_LINK;

        /*POM FILE CONSTRUCTOR BY TAKING AS PARAMETER "DRIVER" FROM BASETEST CLASS*/
        public LinkedIn_PerformSearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /*LOCATORS VALUES STORED AS IWebElement OBJECTS TO BE USED IN FRAMEWORK THROUGH METHODS FROM THIS POM CLASS*/
        /*SET*/
        private static IWebElement SearchTextboxField => FindElements(_driver, By.XPath(SEARCH_TXT), 20);
        private static IWebElement SearchIconField => FindElements(_driver, By.XPath(SEARCH_ICON_BTN), 20);
        private static IWebElement PeopleFilterField => FindElements(_driver, By.XPath(PEOPLE_FILTER_BTN), 20);
        private static IWebElement HomeButtonFiled => FindElements(_driver, By.XPath(HOME_BTN), 10);
        private static IWebElement AllFilterButtonField => FindElements(_driver, By.XPath(ALL_FILTER_BTN), 10);
        private static IWebElement LocationTxtField => FindElements(_driver, By.XPath(LOCATION_TXT), 10);
        private static IWebElement ApplyButtonField => FindElements(_driver, By.XPath(APPLY_BTN), 10);
        private static IWebElement CandidateNameField => FindElements(_driver, By.XPath(CANDIDATE_NAME), 10);
        private static IWebElement CandidateRoleField => FindElements(_driver, By.XPath(CANDIDATE_ROLE), 10);
        private static IWebElement CandidateProfileField => FindElements(_driver, By.XPath(CANDIDATE_PROFILE_LINK), 10);
        private static IWebElement PaginationBtn  => FindElements(_driver, By.XPath(PAG_BUTTON), 10);

        /*METHODS FOR ACCESING TO WEBELEMENTS FROM THIS PARTICULAR POM CLASS*/

        /*Search Textbox*/
        private static IWebElement GetSearchTextBoxField()
        {
            return SearchTextboxField;
        }
        public void EnterSearchTextBoxField(string pstrKeyword)
        {
            SearchTextboxField.Click();
            SearchTextboxField.Clear();
            SearchTextboxField.SendKeys(pstrKeyword);
        }

        /*Search Icon*/
        private static IWebElement GetSearchIconField()
        {
            return SearchIconField;
        }
        public void ClickSearchIconField()
        {
            SearchIconField.Click();
        }

        /*Vertical Serach Filter (People, contacts, Location)*/
        private static IWebElement GetSearchVerticalField()
        {
            return PeopleFilterField;
        }
        public void PeopleFilterButton()
        {
            PeopleFilterField.Click();
        }

        /*Home Button*/
        private static IWebElement GetHomeButton()
        {
            return HomeButtonFiled;
        }
        public void ClickHomeButton()
        {
            HomeButtonFiled.Click();
        }

        /*All Filters Button*/
        private static IWebElement GetAllFiltersButton()
        {
            return AllFilterButtonField;
        }
        public void ClickAllFiltersButton()
        {
            AllFilterButtonField.Click();
        }

        /*Location Textbox*/
        private static IWebElement GetLocationTextbox()
        {
            return LocationTxtField;
        }
        public void EnterLocationTextbox(string pstrLocation)
        {
            LocationTxtField.Clear();
            LocationTxtField.SendKeys(pstrLocation);
        }

        /*Apply Button*/
        private static IWebElement GetApplyButton()
        {
            return ApplyButtonField;
        }
        public void ClickApplyButton()
        {
            ApplyButtonField.Click();
            WaitToContinue(2);
        }

        /*Candidate Name*/
        private static IWebElement GetCandidateName()
        {
            return CandidateNameField;
        }

        /*Candidate Role*/
        private static IWebElement GetCandidateRole()
        {
            return CandidateRoleField;
        }

        /*Candidate Profile*/
        private static IWebElement GetCandidateProfile()
        {
            return CandidateProfileField;
        }

        /*Pagination Button*/
        private static IWebElement GetPaginationBtn()
        {
            return PaginationBtn;
        }
        public void ClickPaginationBtn()
        {
            PaginationBtn.Click();
        }

        /*METHODS AND FUNCTIONS*/
        public void FnSearchKeyword(string pstrCriteria)
        {
            EnterSearchTextBoxField(pstrCriteria);
            WaitToContinue(4);
            WaitElementToBeClickable(_driver, By.XPath(SEARCH_ICON_BTN), 10);
            ClickSearchIconField();
            WaitToContinue(3);
        }

        public void FnEnterCriteriaAndFilterByPeople(string pstrCriteria)
        {
            FnSearchKeyword(pstrCriteria);
            PeopleFilterButton();
            WaitToContinue(3);
        }

        public void FnEnterAllFilters(string pstrLocations, string pstrLanguajes)
        {
            //Declare Arrays
            string[] arrLocation = pstrLocations.Split(';');
            string[] arrLanguajes = pstrLanguajes.Split(';');
            //Select All Filters
            ClickAllFiltersButton();
            //Select Locations
            foreach (string loc in arrLocation)
            {
                //Set Location
                EnterLocationTextbox(loc);
                WaitToContinue(3);
                //Select Dropdown
                _driver.FindElement(By.XPath("(//div[@role='option']//span[starts-with(text(), '" + loc.Substring(0, 1) + "')])[1]")).Click();
                WaitToContinue(2);
            }
            //Select Languajes
            foreach (string lan in arrLanguajes)
            {
                _driver.FindElement(By.XPath("//label[@for='sf-profileLanguage-"+ lan +"']")).Click();
            }
            //Click Apply Button
            ClickApplyButton();
        }

        public void FnGetResults(string pstrKeyword)
        {
            DateTime time = DateTime.Now;
            string FilePath = @"C:\LinkedIn\Reports\" + pstrKeyword + "_ExportedResults_" + time.ToString("h_mm_ss") + ".csv";
            string strValue;
            int intCount = 1;

            using (StreamWriter outputFile = new StreamWriter(FilePath, true, UTF32Encoding.UTF8))
            {

                outputFile.WriteLine("\"Name\",\"Role\",\"Profile\"");
                //Write File
                //IList<IWebElement> optionCount = driver.FindElements(By.XPath("//span[@class='name actor-name']"));
                //CANDIDATE_ROLE = "(//p[@class='subline-level-1 t-14 t-black t-normal search-result__truncate']//span)[" + (optionCount.Count).ToString() + "]";
                //CandidateRoleField.Click();
                WaitToContinue(3);
                //Scroll down to page
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                WaitToContinue(3);
                js.ExecuteScript("window.scrollTo(0, 0)");
                driver.FindElement(By.XPath("//h2[@class='t-16 t-black t-normal truncate inline ml3 mb2']")).Click();
                WaitToContinue(3);
                IList<IWebElement> optionCount = driver.FindElements(By.XPath("//span[@class='name actor-name']"));



                foreach (IWebElement element in optionCount)
                {
                    //Clean strValue
                    
                    strValue = "";
                    //Set Expression 
                    CANDIDATE_NAME = "(//span[@class='name actor-name'])[" + intCount.ToString() + "]";
                    CANDIDATE_ROLE = "(//p[@class='subline-level-1 t-14 t-black t-normal search-result__truncate']//span)[" + intCount.ToString() + "]";
                    CANDIDATE_PROFILE_LINK = "(//div[starts-with(@class,'search-result__info')]/a)[" + intCount.ToString() + "]";
                    //Get Resutls
                    strValue = "\"" + CandidateNameField.Text + "\"" + "," + "\"" + CandidateRoleField.Text + "\""+"," + "\"" + CandidateProfileField.GetAttribute("href") + "\"";
                    outputFile.WriteLine(strValue);
                    //Increment Counter
                    intCount++;
                }
            }
        }



    }
}
