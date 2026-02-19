using OpenQA.Selenium;
using System.IO;

namespace DemoQA.Automation.Pages
{
    public class FileUploadPage : BasePage
    {
        public FileUploadPage(IWebDriver driver) : base(driver)
        {
        }

        private By UploadInput => By.Id("uploadFile");
        private By UploadedFilePath => By.Id("uploadedFilePath");

        public void UploadFile()
        {
            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "TestData",
                "testfile.txt"
            );

            _driver.FindElement(UploadInput).SendKeys(filePath);
        }


        public bool IsFileUploaded()
        {
            return _driver.FindElement(UploadedFilePath)
                          .Text.Contains("testfile.txt");
        }
    }
}

