using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V119.Security;

namespace SeleniumInitialize_Tests
{
     public static class IWebElementExtension
    {
        public static string GetValue(this IWebElement element)
        {
            return element.GetAttribute("value");
        }
        public static void CheckBoxClick(this IWebElement element)
        {
            element.FindElement(By.XPath(".//rui-icon")).Click();
        }

        public static void SelectElement(this IEnumerable<IWebElement> element, string checkBox)
        {
            element.Single(e => e.Text.Contains(checkBox)).CheckBoxClick();
        }
    }
}
