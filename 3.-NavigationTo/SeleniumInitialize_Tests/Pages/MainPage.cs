using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.Pages
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver) { }

        private readonly By _uniqueElement = By.XPath("//div[@class= 'main']");
        private readonly By _banner = By.XPath("(//h1[@class = 'title' and contains(text(), 'преимущества')])[1]");
        private readonly By _investmentsCombobox = By.XPath("//a[span[text()='Инвестиции']]");
        private readonly By _brokerageElement = By.XPath("//a[text()=' Брокерский договор ']");
        public string Url = "https://ib.psbank.ru/";

        public void Open() => _driver.Navigate().GoToUrl(Url);
        public bool IsUniqueDisplayed() => IsDisplayed(_uniqueElement);
        public bool IsBannerDisplayed() => IsDisplayed(_banner);
        public void InvestmentsClick()
        { 
            _wait.Until(ExpectedConditions.ElementToBeClickable(_investmentsCombobox)).Click();
        }

        public void BrokerageClick()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_brokerageElement)).Click();
        }

        public string GetBrokerageHref()
        {
            var element = _wait.Until(ExpectedConditions.ElementToBeClickable(_brokerageElement));
            return element.GetAttribute("href");
        }

        public string GetCurrentUrl()
        {
            return _driver.Url;
        }
    }
}
