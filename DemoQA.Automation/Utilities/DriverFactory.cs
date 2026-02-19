using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQA.Automation.Utilities
{
    public class DriverFactory
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
            }

            return _driver;
        }

        public static void QuitDriver()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
