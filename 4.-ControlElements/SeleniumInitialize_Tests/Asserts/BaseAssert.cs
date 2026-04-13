using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.Asserts
{
    /// <summary>
    /// Базовые ассерты
    /// </summary>
    public class BaseAssert
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public BaseAssert(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Проверка ожидаемого URL с фактическим
        /// </summary>
        /// <param name="expectedUrl"></param>
        /// <returns></returns>
        public bool UrlAssert(string expectedUrl)
        {
            _wait.Until(ExpectedConditions.UrlContains(expectedUrl));
            return true;
        }

    }
}
