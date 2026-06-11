using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InterviewTests.Asserts
{
    /// <summary>
    /// Класс ассерта добавления новой карты
    /// </summary>
    public class NewCardAssert : BaseAssert
    {
        public NewCardAssert(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Метод проверки добавления новой карты
        /// </summary>
        /// <param name="timeoutSeconds">Время ожидания</param>
        public void WaitForCardToFinish(int timeoutSeconds = 150)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.PollingInterval = TimeSpan.FromSeconds(5);

            string cardXpath = "(//label[contains(@class, 'cardOrder') and " +
                                "not(.//tui-badge[normalize-space()='Отказ'])])[last()]";

            wait.Until(d => d.FindElements(By.XPath(cardXpath)).Count > 0);

            wait.Until(d =>
            {
                try
                {
                    var elements = d.FindElements(By.XPath(cardXpath));

                    if (elements.Count > 0)
                    {
                        _driver.Navigate().Refresh();
                        return false;
                    }

                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });
        }
    }
}