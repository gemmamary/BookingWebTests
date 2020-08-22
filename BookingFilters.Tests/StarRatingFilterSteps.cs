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
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.booking.com/");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var excOne = By.Id("onetrust-accept-btn-handler");
            var excTwo = By.XPath("//button[@data-gdpr-consent=\"accept\"]");

            if (IsElementPresent(excOne))
            {
                _driver.FindElement(excOne).Click();
            }
            else
            {
                _driver.FindElement(excTwo).Click();
            }

        }

        private bool IsElementPresent(By by)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
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

        [When(@"I filter the results by unrated accommodation")]
        public void WhenIFilterTheResultsByUnratedAccommodation()
        {
            _driver.FindElement(By.XPath($"//a[@data-id=\"class-0\"]//label")).Click();
        }

        [Then(@"My results contain only (.*) star hotels")]
        public void ThenResultsContainOnlyHotelsWithAStarRatingOf(string starRating)
        {
            
            var firstResult = _driver.FindElement(By.XPath($"//div[@id=\"hotellist_inner\"]//div[@data-class=\"{starRating}\"]"));

            Assert.NotNull(firstResult);
        }

        [Then(@"My results contain only unrated hotels")]
        public void ThenMyResultsContainOnlyUnratedHotels()
        {
            var firstResult = _driver.FindElement(By.XPath($"//div[@id=\"hotellist_inner\"]//div[@data-class=\"0\"]"));

            Assert.NotNull(firstResult);
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
        
    }
}
