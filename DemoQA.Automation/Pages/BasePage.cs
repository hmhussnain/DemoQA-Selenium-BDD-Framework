using OpenQA.Selenium;
using DemoQA.Automation.Utilities;

namespace DemoQA.Automation.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver;
        protected WaitHelper _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WaitHelper(driver);
        }

        protected IWebElement FindByText(string text)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{text}']"));
        }

        protected IWebElement FindInputByLabel(string label)
        {
            return _driver.FindElement(By.XPath($"//label[text()='{label}']/following::input[1]"));
        }

        protected void Click(By by)
        {
            _wait.WaitForClickable(by);
            _driver.FindElement(by).Click();
        }
    }
}
