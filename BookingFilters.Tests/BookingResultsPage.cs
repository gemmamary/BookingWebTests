using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BookingFilters.Tests
{
    public class BookingResultsPage
    {
        private static IWebDriver _driver;

        public BookingResultsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void FilterResultsByStarRating(string starRating)
        {
            _driver.FindElement(By.XPath($"//a[@data-id=\"class-{starRating}\"]//label")).Click();
        }

        public void FilterResultsByUnratedAccommodation()
        {
            _driver.FindElement(By.XPath($"//a[@data-id=\"class-0\"]//label")).Click();
        }

        public bool ResultHasCorrectStarRating(string starRating)
        {

            var result = By.XPath($"//div[@id=\"hotellist_inner\"]//div[@data-class=\"{starRating}\"]");
            if (BookingPage.IsElementPresent(result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
