﻿using OpenQA.Selenium;

namespace BookingFilters.Tests
{
    public class BookingResultsPage
    {
        private static IWebDriver _driver;

        public BookingResultsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        By unrated = By.XPath($"//a[@data-id=\"class-0\"]//label");

        public void FilterResultsByStarRating(string starRating)
        {
            _driver.FindElement(By.XPath($"//a[@data-id=\"class-{starRating}\"]/label")).Click();
        }

        public void FilterResultsByUnratedAccommodation()
        {
            _driver.FindElement(unrated).Click();
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
