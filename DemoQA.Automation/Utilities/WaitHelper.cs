using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQA.Automation.Utilities
{
    public class WaitHelper
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement WaitForElement(By by)
        {
            return _wait.Until(d => d.FindElement(by));
        }

        public void WaitForClickable(By by)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
