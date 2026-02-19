using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoQA.Automation.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]

        public void BeforeScenario()
        {
            // Automatically downloads correct driver for installed Chrome
            new DriverManager().SetUpDriver(new ChromeConfig());

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            IWebDriver driver = new ChromeDriver(options);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);

            _scenarioContext["driver"] = driver;
        }





        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.ContainsKey("driver"))
            {
                var driver = _scenarioContext.Get<IWebDriver>("driver");
                driver.Quit();
            }
        }
    }
}
