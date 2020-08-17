using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

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
        /*

        [Given(@"I select a check in date")]
        public void GivenISelectCheckInDate()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I select a check out date")]
        public void GivenISelectCheckOutDate()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I submit my booking details")]
        public void GivenISubmitBookingDetails()
        {
            ScenarioContext.Current.Pending();
        }

        */
    }
}
