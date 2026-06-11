using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace InterviewTests.Asserts
{
    /// <summary>
    /// Базовый ассерт
    /// </summary>
    public class BaseAssert
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        public BaseAssert(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
    }
}