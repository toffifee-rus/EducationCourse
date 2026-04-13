using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumInitialize_Tests.Asserts;
using SeleniumInitialize_Tests.Elements;

namespace SeleniumInitialize_Tests.Pages
{
    /// <summary>
    /// Страница кешбэк
    /// </summary>
    public class CashBackPage : BasePage
    {
        public CashBackPage(IWebDriver driver) : base(driver) { }

        private readonly By _choiseCategoryButton = By.XPath("//button[text() = ' Выбрать другие категории ']");
        private readonly By _selectButton = By.XPath("//button[text() = ' Выбрать ']");
        private readonly By _lastNameInput = By.XPath("//label[text() = 'Фамилия']/following-sibling::input");
        private readonly By _expectedDocument = By.XPath("//span[contains(text(), 'Твой кешбэк') and @class = 'document-name']");

        public string Url = "https://ib.psbank.ru/store/products/your-cashback-new";
        public CheckBox Cinema => new CheckBox(_driver, By.XPath("//li[.//span[contains(text(), 'Кино')]]//input"));
        public CheckBox Transport => new CheckBox(_driver, By.XPath("//li[.//span[contains(text(), 'транспорт')]]//input"));
        public ComboBox LastName => new ComboBox(_driver, _lastNameInput);
        public Button DocumentButton => new Button(_driver, _expectedDocument);
        public Button SelectButton => new Button(_driver, _selectButton);
        public Button CategoryButton => new Button(_driver, _choiseCategoryButton);

        public BaseAssert Assert => new BaseAssert(_driver);

        /// <summary>
        /// Переход на страницу
        /// </summary>
        public void Open() => _driver.Navigate().GoToUrl(Url);

        /// <summary>
        /// Переход на последнюю вкладку
        /// </summary>
        public void OpenInNewTab()
        {
            int initialWindowCount = _driver.WindowHandles.Count;
            DocumentButton.Click();

            _wait.Until(d => d.WindowHandles.Count > initialWindowCount);

            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }

        /// <summary>
        /// Клик на чекбокс категории
        /// </summary>
        /// <param name="checkboxName"></param>
        public void CLickCheckBox(string checkboxName)
        {
            _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//rui-modal-container//li")))
                .SelectElement(checkboxName);
        }

        /// <summary>
        /// Выбор значение из инпута
        /// </summary>
        /// <returns></returns>
        public string GetInputValue()
        {
            return _driver.FindElement(_lastNameInput).GetValue();
        }
    }
}
