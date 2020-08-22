using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BookingFilters.Tests
{
    public class BookingPage
    {
        private static IWebDriver _driver;
        private const string PageUri = @"https://www.booking.com/";

        public BookingPage(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public string Destination
        {
            set
            {
                _driver.FindElement(By.Id("ss")).SendKeys(value);
            }
        }

        public string CheckInMonth
        {
            set
            {
                var selectCheckinMonth = new SelectElement(_driver.FindElement(By.XPath("(//div[@class=\"sb-date-field__select -month-year js-date-field__part\"])[1]//select")));
                selectCheckinMonth.SelectByValue(value);             
            }
        }

        public string CheckInDay
        {
            set
            {
                var selectCheckinDay = new SelectElement(_driver.FindElement(By.XPath("//select[@name=\"checkin_monthday\"]")));
                selectCheckinDay.SelectByValue(value);
            }
        }

        public string CheckOutMonth
        {
            set
            {
                var selectCheckoutMonth = new SelectElement(_driver.FindElement(By.XPath("(//div[@class=\"sb-date-field__select -month-year js-date-field__part\"])[2]//select")));
                selectCheckoutMonth.SelectByValue("10-2020");
            }
        }

        public string CheckOutDay
        {
            set
            {
                var selectCheckoutDay = new SelectElement(_driver.FindElement(By.XPath("//select[@name=\"checkout_monthday\"]")));
                selectCheckoutDay.SelectByValue("8");
            }
        }

        public static BookingPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new BookingPage(driver);
        }

        public static bool IsElementPresent(By by)
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

        public void AcceptCookies()
        {
            // var cookiesBanner = By.Id("onetrust-banner-sdk");
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

        public BookingResultsPage SubmitDetails()
        {
            _driver.FindElement(By.XPath("//button[@data-sb-id=\"main\"]")).Click();

            return new BookingResultsPage(_driver);
        }
    }   
}
