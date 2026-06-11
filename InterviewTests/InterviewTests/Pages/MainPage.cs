using OpenQA.Selenium;

namespace InterviewTests.Pages
{
    /// <summary>
    /// Класс главной страницы
    /// </summary>
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver) { }

        public By OrderCardLocator = By.XPath(@"//span[text() = ' Заказать карту ']");
        public By TransferButtonLocator = By.XPath("//div[contains(text(), 'Перевести')]");
        public By WriteOffBillLocator = By.XPath("//label[text() = ' Счёт списания ']/ancestor::tui-primitive-textfield//input[@type = 'text']");
        public By AddresseeBillLocator = By.XPath("//label[text() = ' Счёт получателя ']/ancestor::tui-primitive-textfield//input[@type = 'undefined']");
        public By TransactionSumLocator = By.XPath("//label[text() = ' Сумма перевода ']/ancestor::tui-primitive-textfield//input[@type = 'undefined']");
        public By ContinueButtonLocator = By.XPath("//button[@type = 'submit']");
        public By SubmitButtonLocator = By.XPath("//footer//button[@type = 'submit']");
        public By CloseButtonLocator = By.XPath("//span[text() = ' Закрыть ']/ancestor::button");
        public By MainPageButtonLocator = By.XPath($"//button[text() = ' Мой банк ']");
        
        /// <summary>
        /// Метод получения текущего баланса счета
        /// </summary>
        /// <param name="addresseeBill">Счет отправителя</param>
        /// <returns></returns>
        public string GetBalance(string addresseeBill)
        {
            By BillLocator = _driver.FindBill(addresseeBill);
            string shortBillNumber = addresseeBill.Remove(0, addresseeBill.Length - 4);

            var element = _wait.Until(d => 
                d.FindElement(By.XPath($"//div[contains(text(), '{shortBillNumber}') ]" +
                                       $"/ancestor::div[./tui-money]" +
                                       $"//span[@automation-id = 'tui-money__integer-part']")));

            return element.Text;
        }

        /// <summary>
        /// Метод для получения последней карты в списке
        /// </summary>
        /// <returns></returns>
        public IWebElement GetLastCard()
        {
            var element = By.XPath("(//label[contains(@class, 'cardOrder') " +
                                    "and not(.//tui-badge[normalize-space()='Отказ'])])[last()]");

            return _driver.FindElement(element);
        }

        /// <summary>
        /// Метод перевода денег
        /// </summary>
        /// <param name="sum">Сумма перевода</param>
        /// <param name="senderCardNumber">Номер карты отправителя</param>
        /// <param name="addresseeBill">Счет получателя</param>
        public void MoneyTransfer(string sum, string senderCardNumber, string addresseeBill)
        {
            string shortCardNumber = senderCardNumber.Remove(0, senderCardNumber.Length - 4);

            By SenderLocator = _driver.FindCard(senderCardNumber);
            _driver.ClickElement(SenderLocator);

            _driver.ClickElement(TransferButtonLocator);
            _driver.ClickElement(WriteOffBillLocator);

            _driver.ClickElement(By.XPath($"//span[contains(text(), '{shortCardNumber}')]" +
                                          $"/ancestor::tui-select-option"));

            _driver.InputElement(AddresseeBillLocator, addresseeBill);
            _driver.InputElement(TransactionSumLocator, sum);

            _driver.ClickElement(ContinueButtonLocator);
            _driver.ClickElement(SubmitButtonLocator);
            _driver.ClickElement(CloseButtonLocator);

            _driver.ClickElement(MainPageButtonLocator);
        }
    }
}