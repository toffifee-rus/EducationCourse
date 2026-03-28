using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.Pages
{
    public class InvestmentsPage : BasePage
    {
        public InvestmentsPage(IWebDriver driver) : base(driver) { }

        public string Url = "https://ib.psbank.ru/store/products/investmentsbrokerage";
        private readonly By _unique = By.XPath("//span[text() = 'Инвестиции в акции, облигации и валюту']");

        public void Open() => _driver.Navigate().GoToUrl(Url);

        public bool IsUniqueDisplayed() => IsDisplayed(_unique);
    }
}
