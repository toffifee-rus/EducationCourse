using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumInitialize_Builder;

namespace SeleniumInitialize_Tests.Tests
{
    public class BaseTest
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        protected SeleniumBuilder _builder;

        [SetUp]
        public void Setup()
        {
            _builder = new SeleniumBuilder();
            _driver = _builder.SetArgument("--start-maximized").WithTimeout(TimeSpan.FromSeconds(10)).Build();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void Teardown()
        {
            _builder.Dispose();
        }
    }
}
