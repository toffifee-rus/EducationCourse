using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.Pages
{
    /// <summary>
    /// Базовая страница
    /// </summary>
    public class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        /// <summary>
        /// Локатор лицензии в футере
        /// </summary>
        private readonly By _license = By.XPath("//rtl-copyrights");

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Проверка отображения элемента
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool IsDisplayed(By element)
        {
            try
            {
                return _driver.FindElement(element).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Переключение между окнами
        /// </summary>
        /// <param name="tab"></param>
        public void SwitchTab(int tab)
        {
            var tabs = _driver.WindowHandles;
            _driver.SwitchTo().Window(tabs[tab]);
        }

        /// <summary>
        /// Получение лицензии
        /// </summary>
        /// <returns></returns>
        public string GetLicenseInfo()
        {
            var element = _wait.Until(ExpectedConditions.ElementIsVisible(_license));
            return element.GetAttribute("textContent");
        }

        /// <summary>
        /// Получение текущего URL
        /// </summary>
        /// <returns></returns>
        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        /// <summary>
        /// Завершение работы вкладки и переход на другую
        /// </summary>
        /// <param name="tab"></param>
        public void CloseAndSwitchTab(int tab)
        {
            _driver.Close();
            var tabs = _driver.WindowHandles;
            _driver.SwitchTo().Window(tabs[tab]);
        }
    }
}
