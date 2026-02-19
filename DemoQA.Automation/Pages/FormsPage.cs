using OpenQA.Selenium;

namespace DemoQA.Automation.Pages
{
    public class FormsPage : BasePage
    {
        public FormsPage(IWebDriver driver) : base(driver) { }

        public void OpenPracticeForm()
        {
            FindByText("Practice Form").Click();
        }

        public void FillForm(string first, string last, string email)
        {
            FindInputByLabel("First Name").SendKeys(first);
            FindInputByLabel("Last Name").SendKeys(last);
            FindInputByLabel("Email").SendKeys(email);
        }

        public void Submit()
        {
            FindByText("Submit").Click();
        }

        public bool IsSuccessModalDisplayed()
        {
            return _driver.FindElement(By.Id("example-modal-sizes-title-lg")).Displayed;
        }

        public bool IsEmailInvalid()
        {
            return _driver.FindElement(By.Id("userEmail")).GetAttribute("class")!.Contains("field-error");
        }
    }
}
