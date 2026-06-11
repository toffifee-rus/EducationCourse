using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InterviewTests
{
    /// <summary>
    /// Класс расширений
    /// </summary>
    public static class WebDriverExtension
    {
        /// <summary>
        /// Метод клика по элементу
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator">Локатор элемента</param>
        public static void ClickElement(this IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(d => d.FindElement(locator));
            element.Click();
        }

        /// <summary>
        /// Метод ввода данных в элемент
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator">Локатор элемента</param>
        /// <param name="value">Значение</param>
        public static void InputElement(this IWebDriver driver, By locator, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(d => d.FindElement(locator));
            element.Clear();
            element.SendKeys(value);
        }

        /// <summary>
        /// Метод получения значения элемента
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator">ДЛокатор элемента</param>
        /// <returns></returns>
        public static string GetValue(this IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var elementValue = wait.Until(d => d.FindElement(locator)).GetAttribute("value");
            if (elementValue != null)
            {
                return elementValue;
            }
            else
            {
                return "Значение элемента value равно null";
            }
        }

        /// <summary>
        /// Метод поиска локатора счета по номеру счета
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="billNumber">Номер счета</param>
        /// <returns></returns>
        public static By FindBill(this IWebDriver driver, string billNumber)
        {
            string shortBillNumber = billNumber.Remove(0, billNumber.Length - 4);

            return By.XPath($"//div[contains(text(), '{shortBillNumber}') ]");
        }

        /// <summary>
        /// Метод поиска локатора карты по номеру карты
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="cardNumber">Номер карты</param>
        /// <returns></returns>
        public static By FindCard(this IWebDriver driver, string cardNumber)
        {
            string shortCardNumber = cardNumber.Remove(0, cardNumber.Length - 4);

            return By.XPath($"//span[contains(text(), '{shortCardNumber}') ]/ancestor::label");
        }
    }
}
