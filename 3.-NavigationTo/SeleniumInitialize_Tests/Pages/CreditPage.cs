using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.Pages
{
    public class CreditPage : BasePage
    {
        public CreditPage(IWebDriver driver) : base(driver) {}

        public string Url = "https://ib.psbank.ru/store/products/credit-limit/";
        private readonly By _unique = By.XPath("//div[@class='col']");

        public void Open() => _driver.Navigate().GoToUrl(Url);
        public bool IsUniqueDisplayed() => IsDisplayed(_unique);
        
        public void OpenInvestmentsInNewTab()
        {
            _driver.SwitchTo().NewWindow(WindowType.Tab);
            _driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/investmentsbrokerage");
        }
    }
}
