using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.Elements
{
    /// <summary>
    /// Элемент комбобокс
    /// </summary>
    public class ComboBox
    {
        private readonly By _locator;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ComboBox(IWebDriver driver, By locator)
        {
            _locator = locator;
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// Вспомогательная функция
        /// Раскрытие комбобокса через ввод символов
        /// </summary>
        /// <param name="keys"></param>
        public void Open(string keys)
        {
            var element = _wait.Until(ExpectedConditions.ElementToBeClickable(_locator));

            element.Click();

            TypeInput(keys);
        }

        /// <summary>
        /// Вспомогательная функция
        /// Выбор выпадающего элемента комбобокса
        /// </summary>
        /// <param name="expectedText"></param>
        public void ClickElement(string expectedText)
        {
            By controlLocator = By.XPath($"//div[text() = ' {expectedText} ']");
            var control = _wait.Until(ExpectedConditions.ElementToBeClickable(controlLocator));

            control.Click();

            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(controlLocator));
        }
        
        /// <summary>
        /// Вспомогательная функция
        /// Ввод символов в input
        /// </summary>
        /// <param name="keys"></param>
        public void TypeInput(string keys)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_locator)).SendKeys(keys);
        }

        /// <summary>
        /// Выбор элемента и клик на него
        /// </summary>
        /// <param name="text"></param>
        /// <param name="keys"></param>
        public void SelectElementAndClick(string text, string keys)
        {
            Open(keys);
            ClickElement(text);
        }
    }
}


