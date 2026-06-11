using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InterviewTests
{
    /// <summary>
    /// Класс WebDriver билдера
    /// </summary>
    public class WebDriverBuilder : IDisposable
    {
        IWebDriver driver { get; set; } = null!;

        /// <summary>
        /// Метод запуска драйвера
        /// </summary>
        /// <returns></returns>
        public IWebDriver Build()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        /// <summary>
        /// Метод завершения работы драйвера
        /// </summary>
        public void Dispose()
        {
            driver.Quit();
        }
    }
}