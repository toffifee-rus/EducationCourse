using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumInitialize_Tests.Asserts;

namespace SeleniumInitialize_Tests.Elements
{
    /// <summary>
    /// Элемент Чекбокс
    /// </summary>
    public class CheckBox
    {
        private readonly By _locator;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CheckBox(IWebDriver driver, By locator)
        {
            _locator = locator;
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// Выбор элемента
        /// </summary>
        public void Check()
        {
            var element = _wait.Until(ExpectedConditions.ElementExists(_locator));

            CheckBoxAssert assert = new CheckBoxAssert(_driver, _locator);
            if (!assert.IsSelected())
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
            }
        }

        /// <summary>
        /// Снятие выбора с элемента
        /// </summary>
        public void Uncheck()
        {
            var element = _wait.Until(ExpectedConditions.ElementExists(_locator));

            CheckBoxAssert assert = new CheckBoxAssert(_driver, _locator);
            if (!assert.IsSelected())
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
            }
        }
    }
}


