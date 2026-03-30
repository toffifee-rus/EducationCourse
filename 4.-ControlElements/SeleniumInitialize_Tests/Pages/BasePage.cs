using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        private readonly By _license = By.XPath("//rtl-copyrights");

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        public bool IsDisplayed(By element)
        {
            try
            {
                return _driver.FindElement(element).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void SwitchTab(int tab)
        {
            var tabs = _driver.WindowHandles;
            _driver.SwitchTo().Window(tabs[tab]);
        }

        public string GetLicenseInfo()
        {
            var element = _wait.Until(ExpectedConditions.ElementIsVisible(_license));
            return element.GetAttribute("textContent");
        }
        public string GetCurrentUrl()
        {
            return _driver.Url;
        }
        public void CloseAndSwitchTab(int tab)
        {
            _driver.Close();
            var tabs = _driver.WindowHandles;
            _driver.SwitchTo().Window(tabs[tab]);
        }
    }
}
