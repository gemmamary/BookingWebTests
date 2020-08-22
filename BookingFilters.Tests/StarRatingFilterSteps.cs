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
        private BookingPage _bookingPage;
        private BookingResultsPage _bookingResultsPage;

        [Given(@"I am on the booking\.com website")]
        public void GivenIAmOnTheBooking_ComWebsite()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _bookingPage = BookingPage.NavigateTo(_driver);
            _bookingPage.AcceptCookies();
            // _driver.Navigate().GoToUrl("");

        }

        [Given(@"I select the destination (.*)")]
        public void GivenISelectTheDestination(string destination)
        {
            _bookingPage.Destination = "Dublin";
            // _driver.FindElement(By.Id("ss")).SendKeys(destination);
        }
        
        [Given(@"I select a check in date")]
        public void GivenISelectACheckInDate()
        {
            _bookingPage.CheckInMonth = "10-2020";
            _bookingPage.CheckInDay = "5";
            /*
            var selectCheckinMonth = new SelectElement(_driver.FindElement(By.XPath("(//div[@class=\"sb-date-field__select -month-year js-date-field__part\"])[1]//select")));
            var selectCheckinDay = new SelectElement(_driver.FindElement(By.XPath("//select[@name=\"checkin_monthday\"]")));
            selectCheckinMonth.SelectByValue("10-2020");
            selectCheckinDay.SelectByValue("5");
            */
        }
        
        [Given(@"I select a check out date")]
        public void GivenISelectACheckOutDate()
        {
            _bookingPage.CheckOutMonth = "10-2020";
            _bookingPage.CheckOutDay = "8";
            /*
            var selectCheckoutMonth = new SelectElement(_driver.FindElement(By.XPath("(//div[@class=\"sb-date-field__select -month-year js-date-field__part\"])[2]//select")));
            var selectCheckoutDay = new SelectElement(_driver.FindElement(By.XPath("//select[@name=\"checkout_monthday\"]")));
            selectCheckoutMonth.SelectByValue("10-2020");
            selectCheckoutDay.SelectByValue("8");
            */
        }
        
        [Given(@"I submit my booking details")]
        public void GivenISubmitMyBookingDetails()
        {
            _bookingResultsPage = _bookingPage.SubmitDetails();
            // _driver.FindElement(By.XPath("//button[@data-sb-id=\"main\"]")).Click();
        }
        
        [When(@"I filter the results by a star rating of (.*) stars")]
        public void WhenIFilterTheResultsByAStarRatingOf(string starRating)
        {
            _bookingResultsPage.FilterResultsByStarRating(starRating);
            // _driver.FindElement(By.XPath($"//a[@data-id=\"class-{starRating}\"]//label")).Click();
        }

        [When(@"I filter the results by unrated accommodation")]
        public void WhenIFilterTheResultsByUnratedAccommodation()
        {
            _bookingResultsPage.FilterResultsByUnratedAccommodation();
            // _driver.FindElement(By.XPath($"//a[@data-id=\"class-0\"]//label")).Click();
        }

        [Then(@"My results contain only (.*) star accommodation")]
        public void ThenResultsContainOnlyAccommodationWithAStarRatingOf(string starRating)
        {
            _bookingResultsPage.ResultHasCorrectStarRating(starRating);
            /*
            var firstResult = _driver.FindElement(By.XPath($"//div[@id=\"hotellist_inner\"]//div[@data-class=\"{starRating}\"]"));
            Assert.NotNull(firstResult);
            */
        }

        [Then(@"My results contain only unrated accommodation")]
        public void ThenMyResultsContainOnlyUnratedAccommodation()
        {
            _bookingResultsPage.ResultHasCorrectStarRating("0");
            /*
            var firstResult = _driver.FindElement(By.XPath($"//div[@id=\"hotellist_inner\"]//div[@data-class=\"0\"]"));
            Assert.NotNull(firstResult);
            */
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
        
    }
}
