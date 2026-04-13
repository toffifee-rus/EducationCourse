using System;
using OpenQA.Selenium;


namespace SeleniumInitialize_Tests.Elements

public class CheckBox
{
    private readonly IWebElement _element;
    private readonly IWebDriver _driver;

    public Checkbox(IWebDriver driver, By locator)
    {
        _element = driver.FindElement(locator);
        _driver = driver;
    }

    public void Check()
    {
        if (!IsSelected()) _element.Click();
    }

    public void Uncheck()
    {
        if (IsSelected()) _element.Click();
    }

    public bool IsSelected()
    {
        return _element.GetAttribute("class").Contains("checked");
    }
}


