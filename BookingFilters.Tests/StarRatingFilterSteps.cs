using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace BookingFilters.Tests
{
    public class StarRatingFilterSteps
    {
        private IWebDriver _driver;

    
        [Given(@"I am on the booking.com website")]
        public void GivenIAmOnTheBookingWebsiteHomePage()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.booking.com/");
        }


        [Given(@"I select a destination")]
        public void GivenISelectDestination()
        {
            _driver.FindElement(By.Id("ss")).SendKeys("Limerick");
        }
        

        [Given(@"I select a check in date")]
        public void GivenISelectCheckInDate()
        {            
            var selectCheckinMonth = new SelectElement(_driver.FindElement(By.XPath("//select[@aria-label=\"Check -in month\"]")));
            var selectCheckinDay = new SelectElement(_driver.FindElement(By.XPath("//select[@name=\"checkin_monthday\"]")));

            selectCheckinMonth.SelectByText("November 2020");
            selectCheckinDay.SelectByText("10, Tuesday");   
        }

        [Given(@"I select a check out date")]
        public void GivenISelectCheckOutDate()
        {
            var selectCheckoutMonth = new SelectElement(_driver.FindElement(By.XPath("//select[@aria-label=\"Check-out month\"]")));
            var selectCheckoutDay = new SelectElement(_driver.FindElement(By.XPath("//select[@name=\"checkout_monthday\"]")));

            selectCheckoutMonth.SelectByText("November 2020");
            selectCheckoutDay.SelectByText("15, Sunday");
        }

        [Given(@"I submit my booking details")]
        public void GivenISubmitBookingDetails()
        {
            _driver.FindElement(By.XPath("//button[@data-sb-id=\"main\"]")).Click();
        }

        [When(@"I filter the results by a star rating of 3 stars")]
        public void WhenIFilterResultsByStarRating()
        {
            _driver.FindElement(By.XPath("//a[@data-id=\"class-3\"]//label//input")).Click();
        }
        
        [Then(@"My results contain only 3 star hotels ")]
        public void ThenMyResultsContainOnly3StarHotels()
        {
            var results = _driver.FindElements(By.Id("hotellist_inner"));
            
            
        }
    }
}
