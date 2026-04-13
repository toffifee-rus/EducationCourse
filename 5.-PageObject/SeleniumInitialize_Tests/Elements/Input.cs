using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

/// <summary>
/// Элемент Input
/// </summary>
public class Input
{
    private readonly IWebDriver _driver;
    private readonly By _locator;
    private readonly WebDriverWait _wait;

    public Input(IWebDriver driver, By locator)
    {
        _driver = driver;
        _locator = locator;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
    }

    /// <summary>
    /// Ввод данных в элемент
    /// </summary>
    /// <param name="text"></param>
    public void Fill(string text)
    {
        var element = _wait.Until(ExpectedConditions.ElementIsVisible(_locator));
        element.Clear();
        element.SendKeys(text);
    }
}