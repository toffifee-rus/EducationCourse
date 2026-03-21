using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V119.DOMSnapshot;

namespace SeleniumInitialize_Builder
{
    public class SeleniumBuilder : IDisposable
    {
        private IWebDriver WebDriver { get; set; }
        public int Port { get; private set; }
        public bool IsDisposed { get; private set; }
        public List<string> ChangedArguments { get; private set; }
        public Dictionary<string, object> ChangedUserOptions { get; private set; }
        public TimeSpan Timeout { get; private set; }
        public string StartingURL { get; private set; }
        
        public IWebDriver Build()
        {
            //Создать экземпляр драйвера, присвоить получившийся результат переменной WebDriver, вернуть в качестве результата данного метода.
            var options = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService();


            if (Port > 0)
            {
                service.Port = this.Port;
            }

            if (ChangedArguments != null)
            {
                options.AddArguments(ChangedArguments);
            }

            if (ChangedUserOptions != null)
            {
                foreach (var option in ChangedUserOptions)
                {
                    options.AddAdditionalOption(option.Key, option.Value);
                }
            }

            WebDriver = new ChromeDriver(service, options);

            if (Timeout != TimeSpan.Zero)
            {
                WebDriver.Manage().Timeouts().ImplicitWait = Timeout;
            }

            if (!string.IsNullOrEmpty(StartingURL))
            {
                WebDriver.Navigate().GoToUrl(StartingURL);
            }



            return WebDriver;
        }

        public void Dispose()
        {
            //Закрыть браузер, очистить использованные ресурсы, по завершении переключить IsDisposed на состояние true
            if (IsDisposed) return;

            WebDriver.Quit();
            IsDisposed = true; 
        }
        
        public SeleniumBuilder ChangePort(int port)
        {
            //Реализовать смену порта, на котором развёрнут IWebDriver для этого необходимо ознакомиться с классом DriverService соответствующего драйвера (ChromeDriverService для хрома)
            //Изменить свойство Port на тот порт, на который поменяли.
            //Builder в данном методе должен возвращать сам себя
            this.Port = port;
            return this;
        }

        public SeleniumBuilder SetArgument(string argument)
        {
            //Реализовать добавление аргумента. При решении данной задаче ознакомитесь с классом Options соответствующего драйвера (ChromeOptions для браузера Chrome)
            //Все изменённые/добавленные аргументы необходимо отразить в свойстве СhangedArguments, которое перед этим нужно где-то будет проинициализировать.
            //Builder в данном методе должен возвращать сам себя
            if (ChangedArguments == null)
            {
                ChangedArguments = new List<string>();
            }
            ChangedArguments.Add(argument);
            return this;
        }

        public SeleniumBuilder SetUserOption(string option, object value) 
        {
            //Реализовать добавление пользовательской настройки.
            //Все изменения сохранить в свойстве ChangedUserOptions
            //Builder в данном методе должен возвращать сам себя
            if (ChangedUserOptions == null)
            {
                ChangedUserOptions = new Dictionary<string, object>();
            }
            ChangedUserOptions.Add(option, value);
            return this;
        }
        
        public SeleniumBuilder WithTimeout(TimeSpan timeout)
        {
            //Реализовать изменение изначального таймаута запускаемого браузера
            //Отслеживать изменения в свойстве Timeout
            //Builder возвращает себя
            this.Timeout = timeout;

            return this;
        }

        public SeleniumBuilder WithURL(string url)
        {
            //Реализовать изменения изначального URL запускаемого браузера
            //Отслеживать изменения в строке StartingURL
            //Builder возвращает себя
            this.StartingURL = url;
            return this;
            throw new NotImplementedException();
        }
    }
}