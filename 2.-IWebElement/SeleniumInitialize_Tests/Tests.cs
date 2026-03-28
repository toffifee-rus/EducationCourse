using OpenQA.Selenium;
using SeleniumInitialize_Builder;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests
{
    public class Tests
    {
        private readonly By _inputCreditSum = By.XPath("//div[contains(@class, 'sng-content') and .//label[contains(text(), 'Сумма кредита')]]//input[1]");
        private readonly By _inputSliderCreditSum = By.XPath("//div[contains(@class, 'sng-content') and .//label[contains(text(), 'Сумма кредита')]]//input[2]");
        private readonly By _inputCreditMonths = By.XPath("//div[contains(@class, 'sng-content') and .//label[contains(text(), 'Срок кредита')]]//input[1]");
        private readonly By _inputSliderCreditMonths = By.XPath("//div[contains(@class, 'sng-content') and .//label[contains(text(), 'Срок кредита')]]//input[2]");
        private readonly By _gosuslugiButton = By.XPath("//button[contains(text(), 'Перейти на Госуслуги')]");
        private readonly By _switcherRefinance = By.XPath("//span[@class='slider _not-standalone']");
        private readonly By _divPayment = By.XPath("//div[@class='col']");
        private SeleniumBuilder _builder;

        [SetUp]
        public void Setup()
        {
            _builder = new SeleniumBuilder();
            _builder.WithURL("https://ib.psbank.ru/store/products/credit-limit");
        }

        [Test(Description = "Задание 1. Поиск элементов на странице")]
        public void XPathFindTest()
        {
            IWebDriver driver = _builder.WithTimeout(TimeSpan.FromSeconds(10)).Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var inputCreditSum = wait.Until(ExpectedConditions.ElementExists(_inputCreditSum));
            var inputSliderCreditSum = wait.Until(ExpectedConditions.ElementExists(_inputSliderCreditSum));
            var inputCreditMonths = wait.Until(ExpectedConditions.ElementExists(_inputCreditMonths));
            var inputSliderCreditMonths = wait.Until(ExpectedConditions.ElementExists(_inputSliderCreditMonths));
            var gosuslugiButton = wait.Until(ExpectedConditions.ElementExists(_gosuslugiButton));
            var switcherRefinance = wait.Until(ExpectedConditions.ElementExists(_switcherRefinance));
            var divPayment = wait.Until(ExpectedConditions.ElementExists(_divPayment));
            
            //Если использовать Until вместо Assert, то как проводить отладку и информировать
        }

        [Test(Description = "Задание 1. Заранее провальный тест")]
        public void XPathFaultTest()
        {
            IWebDriver driver = _builder.WithTimeout(TimeSpan.FromSeconds(3)).Build();
            Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.XPath("//div[@data='testid']")));
        }


        [Test(Description = "Задание 2. Получить значения элементов")]
        public void ElementValuesTest()
        {
            IWebDriver driver = _builder.WithTimeout(TimeSpan.FromSeconds(10)).Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var inputCreditSum = wait.Until(ExpectedConditions.ElementToBeClickable(_inputCreditSum));
            var inputCreditMonths = wait.Until(ExpectedConditions.ElementToBeClickable(_inputCreditMonths));
            var gosuslugiButton = wait.Until(ExpectedConditions.ElementToBeClickable(_gosuslugiButton));
            var switcherRefinance = wait.Until(ExpectedConditions.ElementToBeClickable(_switcherRefinance));
            var switcherValue = driver.FindElement(By.XPath("//input[@type='checkbox' and @class='input']"));

            bool hasValue = wait.Until(d => !string.IsNullOrEmpty(inputCreditSum.GetAttribute("value")));
            Assert.IsTrue(hasValue, "Значение суммы кредита не прогрузилось");

            bool isUnselected = wait.Until(ExpectedConditions.ElementSelectionStateToBe(switcherRefinance, false));
            Assert.IsTrue(isUnselected, "Свитчер должен быть выключен по умолчанию");

            TestContext.WriteLine($"Текущее состояние свитчера: {switcherValue.GetAttribute("value")}");
            TestContext.WriteLine($"Текущий срок: {inputCreditMonths.GetAttribute("value")}");
            TestContext.WriteLine($"Текущая сумма: {inputCreditSum.GetAttribute("value")}");

        }

        [Test(Description = "Задание 4. Проверка работы кнопки 'продолжить'")]
        public void NextButtonActivityTest()
        {
            IWebDriver driver = _builder.WithTimeout(TimeSpan.FromSeconds(10)).Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var inputLastName = driver.FindElement(By.XPath("//input[@name='CardHolderLastName']"));
            var inputFirstName = driver.FindElement(By.XPath("//input[@name='CardHolderFirstName']"));
            var inputMiddleName = driver.FindElement(By.XPath("//input[@name='CardHolderMiddleName']"));
            var radioMaleSex = driver.FindElement(By.XPath("//input[@title='Мужской']"));
            var inputBirthday = driver.FindElement(By.XPath("//input[@snginput and @autocomplete='off']"));
            var inputPhone = driver.FindElement(By.XPath("//input[@name='Phone']"));
            var comboboxCitizenship = driver.FindElement(By.XPath("//label[contains(text(), 'Гражданство')]/ancestor::div[contains(@class, 'sng-content')]"));
            var comboboxEmployment = driver.FindElement(By.XPath("//label[contains(text(), 'Официальное трудоустройство')]/ancestor::div[contains(@class, 'sng-content')]"));
            var checkboxAllow = driver.FindElement(By.XPath("//span[@class='psb-checkbox__box']"));
            var submitButton = driver.FindElement(By.XPath("//button[@type='submit']"));

            Assert.IsFalse(submitButton.Enabled);

            inputLastName.SendKeys("Филимонов");
            inputLastName.SendKeys(Keys.Escape);
            inputFirstName.SendKeys("Михаил");
            inputLastName.SendKeys(Keys.Escape);
            inputMiddleName.SendKeys("Сергеевич");
            inputLastName.SendKeys(Keys.Escape);
            radioMaleSex.Click();
            inputBirthday.SendKeys("11.12.2004");
            inputLastName.SendKeys(Keys.Escape);
            inputPhone.SendKeys("9511279525");
            comboboxCitizenship.Click();
            var citizenshipListItemRUS = driver.FindElement(By.XPath("//sng-select-option[text()=' РФ ']"));
            citizenshipListItemRUS.Click();
            comboboxEmployment.Click();
            var employmentListItemTrue = driver.FindElement(By.XPath("//sng-select-option[text()=' Есть ']"));
            employmentListItemTrue.Click();
            checkboxAllow.Click();

            submitButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@type='submit']")));
        }

        [Test(Description = "Задание 5. Проверка стиля элемента")]
        public void CheckCssTest()
        {
            IWebDriver driver = _builder.WithTimeout(TimeSpan.FromSeconds(10)).Build();
            Actions action = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            var fillRequestButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()=' Заполнить заявку ']")));

            var actualColor = wait.Until(i => fillRequestButton.GetCssValue("background-color") == "rgba(242, 97, 38, 1)");

            Assert.AreEqual("rgba(242, 97, 38, 1)", fillRequestButton.GetCssValue("background-color"));

            action.MoveToElement(fillRequestButton).Perform();
            var hoverColor = wait.Until(i => fillRequestButton.GetCssValue("background-color") == "rgba(212, 73, 33, 1)");

            Assert.AreEqual("rgba(212, 73, 33, 1)", fillRequestButton.GetCssValue("background-color"));
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                if (_builder.WebDriver is ITakesScreenshot sDriver)
                {
                    Screenshot screenshot = sDriver.GetScreenshot();
                    string fileName = TestContext.CurrentContext.Test.Name + "_fail.png";
                    screenshot.SaveAsFile(fileName);
                }
            }
            _builder.Dispose();
        }
    }
}