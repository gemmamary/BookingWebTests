using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
            _driver.Navigate().GoToUrl("https://www.booking.com/");
        }
        
        [Given(@"I select a destination")]
        public void GivenISelectADestination()
        {
            _driver.FindElement(By.Id("ss")).SendKeys("Limerick");
        }
        
        [Given(@"I select a check in date")]
        public void GivenISelectACheckInDate()
        {
            var selectCheckinMonth = new SelectElement(_driver.FindElement(By.XPath("//div[@class=\"sb-date-field__select -month-year js-date-field__part\"]//select")));
            var selectCheckinDay = new SelectElement(_driver.FindElement(By.XPath("//select[@name=\"checkin_monthday\"]")));

            selectCheckinMonth.SelectByText("November 2020");
            selectCheckinDay.SelectByText("10, Tuesday");
        }
        
        [Given(@"I select a check out date")]
        public void GivenISelectACheckOutDate()
        {
            var selectCheckoutMonth = new SelectElement(_driver.FindElement(By.XPath("//select[@aria-label=\"Check-out month\"]")));
            var selectCheckoutDay = new SelectElement(_driver.FindElement(By.XPath("//select[@name=\"checkout_monthday\"]")));

            selectCheckoutMonth.SelectByText("November 2020");
            selectCheckoutDay.SelectByText("15, Sunday");
        }
        
        [Given(@"I submit my booking details")]
        public void GivenISubmitMyBookingDetails()
        {
            _driver.FindElement(By.XPath("//button[@data-sb-id=\"main\"]")).Click();
        }
        
        [When(@"I filter the results by a star rating of (.*) stars")]
        public void WhenIFilterTheResultsByAStarRatingOfStars(int p0)
        {
            _driver.FindElement(By.XPath("//a[@data-id=\"class-3\"]//label//input")).Click();
        }
        
        [Then(@"My results contain only (.*) star hotels")]
        public void ThenMyResultsContainOnlyStarHotels(int p0)
        {
            var results = _driver.FindElements(By.Id("hotellist_inner"));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
