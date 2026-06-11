using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace InterviewTests.Tests
{
    /// <summary>
    /// Базовый класс тестов
    /// </summary>
    public class BaseTest
    {
        protected IWebDriver driver = null!;
        protected WebDriverBuilder builder = null!;
        protected WebDriverWait wait = null!;

        /// <summary>
        /// Метод подготовки начального состояния
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            builder = new WebDriverBuilder();
            driver = builder.Build();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Метод завершения процесса
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}