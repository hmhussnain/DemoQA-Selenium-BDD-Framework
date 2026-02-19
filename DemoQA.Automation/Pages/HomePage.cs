using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQA.Automation.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        // ===============================
        // Navigation to main card sections
        // ===============================

        public void NavigateToFormsSection()
        {
            FindByText("Forms").Click();
        }

        public void NavigateToElementsSection()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Elements']")));
            element.Click();
        }

        public void NavigateToWidgetsSection()
        {
            FindByText("Widgets").Click();
        }

        // ===============================
        // Sub-menu navigation methods
        // ===============================

        public void NavigateToPracticeForm()
        {
            FindByText("Practice Form").Click();
        }

        public void NavigateToWebTables()
        {
            FindByText("Web Tables").Click();
        }

        public void NavigateToDatePicker()
        {
            FindByText("Date Picker").Click();
        }

        public void NavigateToUploadDownload()
        {
            FindByText("Upload and Download").Click();
        }
    }
}
