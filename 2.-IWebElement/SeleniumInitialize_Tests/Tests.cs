using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V119.DOM;
using OpenQA.Selenium.DevTools.V120.SystemInfo;
using OpenQA.Selenium.Support.UI;
using SeleniumInitialize_Builder;
using System.Diagnostics;
using System.Drawing;
using OpenQA.Selenium.Interactions;
using System;

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

            var inputCreditSum = driver.FindElement(_inputCreditSum);

            var inputSliderCreditSum = driver.FindElement(_inputSliderCreditSum);

            var inputCreditMonths = driver.FindElement(_inputCreditMonths);

            var inputSliderCreditMonths = driver.FindElement(_inputSliderCreditMonths);

            var gosuslugiButton = driver.FindElement(_gosuslugiButton);

            var switcherRefinance = driver.FindElement(_switcherRefinance);

            var divPayment = driver.FindElement(_divPayment);




            Assert.IsNotNull(inputCreditSum);
            Assert.IsNotNull(inputSliderCreditSum);
            Assert.IsNotNull(inputCreditMonths);
            Assert.IsNotNull(inputSliderCreditMonths);
            Assert.IsNotNull(gosuslugiButton);
            Assert.IsNotNull(switcherRefinance);
            Assert.IsNotNull(divPayment);
        }

        [Test(Description = "Задание 1. Заранее провальный тест")]
        public void XPathFaultTest()
        {
            IWebDriver driver = _builder.WithTimeout(TimeSpan.FromSeconds(10)).Build();
            var testString = driver.FindElement(By.XPath("/*[@data-testid])"));
        }


        [Test(Description = "Задание 2. Получить значения элементов")]
        public void ElementValuesTest()
        {
            IWebDriver driver = _builder.WithTimeout(TimeSpan.FromSeconds(10)).Build();
            var inputCreditSum = driver.FindElement(_inputCreditSum);

            var inputSliderCreditSum = driver.FindElement(_inputSliderCreditSum);

            var inputCreditMonths = driver.FindElement(_inputCreditMonths);

            var inputSliderCreditMonths = driver.FindElement(_inputSliderCreditMonths);

            var gosuslugiButton = driver.FindElement(_gosuslugiButton);

            var switcherRefinance = driver.FindElement(_switcherRefinance);

            var divPayment = driver.FindElement(_divPayment);

            Assert.IsTrue(inputCreditMonths.Displayed);
            Assert.IsTrue(inputCreditMonths.Enabled);

            string creditValue = inputCreditMonths.GetAttribute("value");
            TestContext.WriteLine($"Текущий срок: {creditValue}");

            Assert.IsTrue(gosuslugiButton.Displayed);
            Assert.IsTrue(gosuslugiButton.Enabled);

            Assert.IsTrue(switcherRefinance.Displayed);
            Assert.IsTrue(switcherRefinance.Enabled);

            bool isInsuranceActive = switcherRefinance.Selected;
            TestContext.WriteLine($"Страхование включено: {isInsuranceActive}");

            Assert.IsTrue(divPayment.Displayed);
            Assert.IsTrue(divPayment.Enabled);


        }

        [Test(Description = "Задание 4. Проверка работы кнопки 'продолжить'")]
        public void NextButtonActivityTest()
        {
            IWebDriver driver = _builder.WithTimeout(TimeSpan.FromSeconds(10)).Build();
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
            inputFirstName.SendKeys("Михаил");
            inputMiddleName.SendKeys("Сергеевич");
            radioMaleSex.Click();
            inputBirthday.SendKeys("11.12.2004");
            inputPhone.SendKeys("9511279525");
            comboboxCitizenship.Click();
            var citizenshipListItemRUS = driver.FindElement(By.XPath("//sng-select-option[text()=' РФ ']"));
            citizenshipListItemRUS.Click();
            comboboxEmployment.Click();
            var employmentListItemTrue = driver.FindElement(By.XPath("//sng-select-option[text()=' Есть ']"));
            employmentListItemTrue.Click();
            checkboxAllow.Click();

            Assert.IsTrue(submitButton.Enabled);

        }

        [Test(Description = "Задание 5. Проверка стиля элемента")]
        public void CheckCssTest()
        {
            IWebDriver driver = _builder.WithTimeout(TimeSpan.FromSeconds(10)).Build();
            Actions action = new Actions(driver);
            var fillRequestButton = driver.FindElement(By.XPath("//button[text()=' Заполнить заявку ']"));
            Thread.Sleep(1000);
            Assert.IsTrue(fillRequestButton.Enabled);
            string actualColor = fillRequestButton.GetCssValue("background-color");
            Assert.AreEqual("rgba(242, 97, 38, 1)", actualColor);

            action.MoveToElement(fillRequestButton).Perform();
            string hoverColor = fillRequestButton.GetCssValue("background-color");
            Assert.AreEqual("rgba(212, 73, 33, 1)", hoverColor);
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Thread.Sleep(500);
                try
                {
                    if (_builder.WebDriver is ITakesScreenshot sDriver)
                    {
                        Screenshot screenshot = sDriver.GetScreenshot();
                        string fileName = TestContext.CurrentContext.Test.Name + "_fail.png";
                        screenshot.SaveAsFile(fileName);
                    }
                }
                catch (Exception ex)
                {
                    TestContext.WriteLine("Не удалось сделать скриншот: " + ex.Message);
                }
            }
            _builder.Dispose();
        }
    }
}