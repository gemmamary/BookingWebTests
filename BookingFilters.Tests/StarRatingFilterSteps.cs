using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        }

        [Given(@"I select the destination (.*)")]
        public void GivenISelectTheDestination(string destination)
        {
            _bookingPage.Destination = "Dublin";
        }
        
        [Given(@"I select a check in date")]
        public void GivenISelectACheckInDate()
        {
            _bookingPage.CheckInMonth = "10-2020";
            _bookingPage.CheckInDay = "5";
        }
        
        [Given(@"I select a check out date")]
        public void GivenISelectACheckOutDate()
        {
            _bookingPage.CheckOutMonth = "10-2020";
            _bookingPage.CheckOutDay = "8";
        }
        
        [Given(@"I submit my booking details")]
        public void GivenISubmitMyBookingDetails()
        {
            _bookingResultsPage = _bookingPage.SubmitDetails();
        }
        
        [When(@"I filter the results by a star rating of (.*) stars")]
        public void WhenIFilterTheResultsByAStarRatingOf(string starRating)
        {
            _bookingResultsPage.FilterResultsByStarRating(starRating);
        }

        [When(@"I filter the results by unrated accommodation")]
        public void WhenIFilterTheResultsByUnratedAccommodation()
        {
            _bookingResultsPage.FilterResultsByUnratedAccommodation();
        }

        [Then(@"My results contain only (.*) star accommodation")]
        public void ThenResultsContainOnlyAccommodationWithAStarRatingOf(string starRating)
        {
            _bookingResultsPage.ResultHasCorrectStarRating(starRating);
        }

        [Then(@"My results contain only unrated accommodation")]
        public void ThenMyResultsContainOnlyUnratedAccommodation()
        {
            _bookingResultsPage.ResultHasCorrectStarRating("0");
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }      
    }
}
