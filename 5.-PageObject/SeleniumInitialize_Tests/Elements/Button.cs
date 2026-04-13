using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.Elements
{
    /// <summary>
    /// Элемент кнопка
    /// </summary>
    public class Button
    {
        private readonly IWebDriver _driver;
        private readonly By _locator;
        private readonly WebDriverWait _wait;

        public Button(IWebDriver driver, By locator)
        {
            _driver = driver;
            _locator = locator;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Клик
        /// </summary>
        public void Click()
        {
            var element = _wait.Until(ExpectedConditions.ElementToBeClickable(_locator));
            element.Click();
        }
    }
}