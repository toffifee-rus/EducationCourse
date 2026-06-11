using InterviewTests.Models;
using OpenQA.Selenium;

namespace InterviewTests.Pages
{
    /// <summary>
    /// Класс страницы выпуска новой карты
    /// </summary>
    public class ReleaseCardPage : BasePage
    {
        public ReleaseCardPage(IWebDriver driver) : base(driver) { }

        public By PaymentCardLocator = By.XPath(@"//div[text() = ' Дебетовая карта ']/following-sibling::button[text() = ' Заказать ']");
        public By CreditCardLocator = By.XPath("//div[text() = ' Кредитная карта ']/following-sibling::button[text() = ' Заказать ']");
        public By ReleaseProgramMIR = By.XPath("//input[@value = 'МИР']");
        public By ReleaseProgramVisa = By.XPath("//input[@value = 'Visa']");
        public By ReleaseProgramMastercard = By.XPath("//input[@value = 'Mastercard']");
        public By ReleaseProgramMaestro = By.XPath("//input[@value = 'Maestro']");
        public By ContinueButtonLocator = By.XPath("//button[@type = 'submit']");
        public By SubmitButtonLocator = By.XPath("//footer//button[@type = 'submit']");
        public By CardNumberLocator = By.XPath("//span[text() = 'Номер карточного счета']/following-sibling::span[@class = 'operation-card__value']");
        public By CloseButtonLocator = By.XPath("//span[text() = ' Закрыть ']/ancestor::button");
        public By MainPageButtonLocator = By.XPath($"//button[text() = ' Мой банк ']");

        /// <summary>
        /// Метод выпуска карты
        /// </summary>
        /// <param name="cardType">Тип выпускаемой карты</param>
        /// <param name="releaseProgram">Тип программы выпуска карты</param>
        public void ReleaseCard(CardType cardType, ReleaseProgram releaseProgram)
        {
            switch (cardType)
            {
                case CardType.Дебетовая:
                    _driver.ClickElement(PaymentCardLocator);
                    break;
                case CardType.Кредитная:
                    _driver.ClickElement(CreditCardLocator);
                    break;
            }

            switch (releaseProgram)
            {
                case ReleaseProgram.МИР:
                    _driver.ClickElement(ReleaseProgramMIR);
                    break;
                case ReleaseProgram.Visa:
                    _driver.ClickElement(ReleaseProgramVisa);
                    break;
                case ReleaseProgram.Mastercard:
                    _driver.ClickElement(ReleaseProgramMastercard);
                    break;
                case ReleaseProgram.Maestro:
                    _driver.ClickElement(ReleaseProgramMaestro);
                    break;
            }

            _driver.ClickElement(ContinueButtonLocator);
            _driver.ClickElement(SubmitButtonLocator);
            _driver.ClickElement(CloseButtonLocator);

            _driver.ClickElement(MainPageButtonLocator);
        }
    }
}