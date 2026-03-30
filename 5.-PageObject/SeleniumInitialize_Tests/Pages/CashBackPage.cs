using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.Pages
{
    public class CashBackPage : BasePage
    {
        public CashBackPage(IWebDriver driver) : base(driver) { }

        private readonly By _choiseCategoryButton = By.XPath("//button[*/span[text()] = ' Выбрать другие категории ']");
        private readonly By _publicTransportCheckbox = By.XPath("//rui-checkbox[following-sibling::span[text() = ' 5% — Общественный транспорт ']]");
        private readonly By _cinemaCheckbox = By.XPath("//rui-checkbox[following-sibling::span[text() = ' 5% — Кино и развлечения ']]");
        private readonly By _selectButton = By.XPath("//button[*/span[text()] = ' Выбрать ']");
        private readonly By _lastNameInput = By.XPath("//input[@name = 'CardHolderLastName']");
        private readonly By _itemPushkin = By.XPath("//div[text() = ' Пушкин ']");
        private readonly By _yourCashBack = By.XPath("//h4[contains(text(), 'Твой кешбэк')]");




        public string Url = "https://ib.psbank.ru/store/products/your-cashback-new";

        public void Open() => _driver.Navigate().GoToUrl(Url);
        public void CategoryClick()
        { 
            _wait.Until(ExpectedConditions.ElementToBeClickable(_choiseCategoryButton)).Click();
        }

        public void CashBackClick()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_yourCashBack)).Click();
        }

        public void PublicTransportClick()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_publicTransportCheckbox)).Click();
        }
            
        public void CinemaClick()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_cinemaCheckbox)).Click();
        }

        public void SelectClick()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_selectButton)).Click();
        }

        public void InputClick()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_lastNameInput)).Click();
        }

        public void PushkinClick()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_itemPushkin)).Click();
        }

        public void TypeInput()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_lastNameInput)).SendKeys("Пу");
        }

        public string GetInputValue()
        {
            return _driver.FindElement(_lastNameInput).GetAttribute("value");
        }

        public string GetCurrentUrl()
        {
            return _driver.Url;
        }
    }
}
