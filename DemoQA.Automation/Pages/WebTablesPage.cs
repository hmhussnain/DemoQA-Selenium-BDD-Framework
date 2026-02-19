using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace DemoQA.Automation.Pages
{
    public class WebTablesPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public WebTablesPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
        }

        // Navigate via homepage → Elements → Web Tables
        public void NavigateToWebTablesPage()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/");

            // Remove bottom banner if present
            var banners = _driver.FindElements(By.Id("fixedban"));
            if (banners.Count > 0)
            {
                ((IJavaScriptExecutor)_driver)
                    .ExecuteScript("arguments[0].remove();", banners[0]);
            }
            var elementsCard = _wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath("//div[contains(@class,'top-card')][.//h5[text()='Elements']]")
                )
            );

            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].scrollIntoView({block:'center'});", elementsCard);

            Thread.Sleep(500);

            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].click();", elementsCard);

            // Click Web Tables from sidebar
            var webTablesMenu = _wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath("//span[text()='Web Tables']")
                )
            );

            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].click();", webTablesMenu);

            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("addNewRecordButton")));
        }



        public void AddNewRecord(string firstName = "John", string lastName = "Doe",
                         string email = "john.doe@example.com",
                         string age = "30", string salary = "50000",
                         string department = "QA")
        {
            var addButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("addNewRecordButton")));

            // Scroll into center
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].scrollIntoView({block:'center'});", addButton);

            // Click using JS (more stable on DemoQA)
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].click();", addButton);

            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("firstName")));

            _driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            _driver.FindElement(By.Id("lastName")).SendKeys(lastName);
            _driver.FindElement(By.Id("userEmail")).SendKeys(email);
            _driver.FindElement(By.Id("age")).SendKeys(age);
            _driver.FindElement(By.Id("salary")).SendKeys(salary);
            _driver.FindElement(By.Id("department")).SendKeys(department);

            var submitButton = _driver.FindElement(By.Id("submit"));

            // Scroll before submit
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].scrollIntoView({block:'center'});", submitButton);

            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].click();", submitButton);

            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("firstName")));
        }


        public void EditFirstRecord(string newFirstName = "Jane")
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".action-buttons span[title='Edit']")));
            _driver.FindElement(By.CssSelector(".action-buttons span[title='Edit']")).Click();

            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("firstName")));
            var firstNameInput = _driver.FindElement(By.Id("firstName"));
            firstNameInput.Clear();
            firstNameInput.SendKeys(newFirstName);

            _driver.FindElement(By.Id("submit")).Click();
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("firstName")));
        }

        public void DeleteFirstRecord()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".action-buttons span[title='Delete']")));
            _driver.FindElement(By.CssSelector(".action-buttons span[title='Delete']")).Click();
        }

        public bool IsRecordUpdated(string expectedFirstName = "Jane")
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath($"//div[text()='{expectedFirstName}']")));

                return _driver.FindElement(
                    By.XPath($"//div[text()='{expectedFirstName}']")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public bool IsRecordPresent(string email = "john.doe@example.com")
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath($"//div[text()='{email}']")));

                return _driver.FindElement(
                    By.XPath($"//div[text()='{email}']")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public bool IsRecordDeleted()
        {
            var rows = _driver.FindElements(By.CssSelector(".rt-tr-group"));
            return rows.Count == 0;
        }
    }
}
