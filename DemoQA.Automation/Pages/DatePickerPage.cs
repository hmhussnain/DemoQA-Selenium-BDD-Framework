using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQA.Automation.Pages
{
    public class DatePickerPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // ✅ Constructor with WebDriverWait
        public DatePickerPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(120));
        }

        // 1️⃣ Navigate to the Date Picker page
        public void NavigateToDatePickerPage()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com");

            // Click Widgets card
            _driver.FindElement(By.XPath("//h5[text()='Widgets']")).Click();

            // Click Date Picker from left menu
            _driver.FindElement(By.XPath("//span[text()='Date Picker']")).Click();

            // Wait until the Date Picker input is visible
            _wait.Until(d => d.FindElement(By.Id("datePickerMonthYearInput")).Displayed);
        }

        // 2️⃣ Select a day dynamically
        public void SelectDate(int day)
        {
            // Open the date picker input
            _driver.FindElement(By.Id("datePickerMonthYearInput")).Click();

            // Format the day correctly (01-31)
            string dayFormatted = day < 10 ? $"0{day}" : day.ToString();

            // Locate the day element
            var dayLocator = By.CssSelector($".react-datepicker__day--{dayFormatted}");

            // Wait until the day is visible and click
            _wait.Until(d => d.FindElement(dayLocator).Displayed);
            _driver.FindElement(dayLocator).Click();
        }

        // 3️⃣ Get the selected date
        public string GetSelectedDate()
        {
            return _driver.FindElement(By.Id("datePickerMonthYearInput")).GetAttribute("value") ?? string.Empty;
        }
    }
}
