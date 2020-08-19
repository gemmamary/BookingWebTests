using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace BookingFilters.Tests
{
    [Binding]
    public class StarRatingFilterSteps
    {

        private IWebDriver _driver;

        [Given(@"I am on the booking\.com website")]
        public void GivenIAmOnTheBooking_ComWebsite()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl("https://www.booking.com/");
            _driver.FindElement(By.XPath("//button[@data-gdpr-consent=\"accept\"]")).Click();
        }
        
        [Given(@"I select the destination (.*)")]
        public void GivenISelectTheDestination(string destination)
        {
            _driver.FindElement(By.Id("ss")).SendKeys(destination);
        }
        
        [Given(@"I select a check in date")]
        public void GivenISelectACheckInDate()
        {
            var selectCheckinMonth = new SelectElement(_driver.FindElement(By.XPath("(//div[@class=\"sb-date-field__select -month-year js-date-field__part\"])[1]//select")));
            var selectCheckinDay = new SelectElement(_driver.FindElement(By.XPath("//select[@name=\"checkin_monthday\"]")));

            selectCheckinMonth.SelectByValue("10-2020");
            selectCheckinDay.SelectByValue("5");
        }
        
        [Given(@"I select a check out date")]
        public void GivenISelectACheckOutDate()
        {
            var selectCheckoutMonth = new SelectElement(_driver.FindElement(By.XPath("(//div[@class=\"sb-date-field__select -month-year js-date-field__part\"])[2]//select")));
            var selectCheckoutDay = new SelectElement(_driver.FindElement(By.XPath("//select[@name=\"checkout_monthday\"]")));

            selectCheckoutMonth.SelectByValue("10-2020");
            selectCheckoutDay.SelectByValue("8");
        }
        
        [Given(@"I submit my booking details")]
        public void GivenISubmitMyBookingDetails()
        {
            _driver.FindElement(By.XPath("//button[@data-sb-id=\"main\"]")).Click();
        }
        
        [When(@"I filter the results by a star rating of (.*) stars")]
        public void WhenIFilterTheResultsByAStarRatingOf(string starRating)
        {
            _driver.FindElement(By.XPath($"//a[@data-id=\"class-{starRating}\"]//label")).Click();
        }
        
        [Then(@"My results contain only (.*) star hotels")]
        public void ThenResultsContainOnlyHotelsWithAStarRatingOf(string starRating)
        {
            var results = _driver.FindElements(By.ClassName("sr-hotel__name"));
            bool limerickThreeStarPresent = false;

            foreach(IWebElement result in results)
            {
                if (result.Text.Contains("Limerick City Hotel"))
                {
                    limerickThreeStarPresent = true;
                    break;
                }
            }

            Assert.True(limerickThreeStarPresent);
        }
        
        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
        
    }
}
