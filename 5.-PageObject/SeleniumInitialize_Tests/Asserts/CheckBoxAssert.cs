using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.Asserts
{
    /// <summary>
    /// Ассерты для элемента CheckBox
    /// </summary>
    public class CheckBoxAssert
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By _locator;

        public CheckBoxAssert(IWebDriver driver, By locator)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _locator = locator;
        }

        /// <summary>
        /// Проверка того, что чекбокс выбран
        /// </summary>
        public void IsCheckedAssert()
        {
            var element = _wait.Until(ExpectedConditions.ElementExists(_locator));

            bool isChecked = _wait.Until(d => IsSelected());

            Assert.IsTrue(isChecked, $"чекбокс {_locator} не выбран");
        }

        /// <summary>
        /// Проверка того, что чекбокс не выбран
        /// </summary>
        public void IsNotCheckedAssert()
        {
            var element = _wait.Until(ExpectedConditions.ElementExists(_locator));

            bool isNotChecked = _wait.Until(d => !IsSelected());

            Assert.IsTrue(isNotChecked,$"чекбокс {_locator} выбран");
        }

        /// <summary>
        /// Проверка аттрибута "checked"
        /// </summary>
        public bool IsSelected()
        {
            var element = _wait.Until(ExpectedConditions.ElementExists(_locator));

            return element.GetAttribute("class").Contains("checked");
        }
    }
}
