using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SeleniumInitialize_Tests.Elements
{
   /// <summary>
   /// Элемент комбобокс
   /// </summary>
    public class ComboBox
    {
        private readonly By _locator;
        private readonly IWebDriver _driver;

        public ComboBox(IWebDriver driver, By locator)
        {
            _locator = locator;
            _driver = driver;
        }
    }
}


