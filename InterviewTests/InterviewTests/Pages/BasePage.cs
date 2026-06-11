using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InterviewTests.Pages
{
    /// <summary>
    /// Класс базовой страницы
    /// </summary>
    public class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// Метод перехода на страницу
        /// </summary>
        /// <param name="url">Ссылка страницы</param>
        public void Open(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Метод перезагрузки страницы
        /// </summary>
        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }
    }
}