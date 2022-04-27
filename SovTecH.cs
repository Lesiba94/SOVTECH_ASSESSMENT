using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;



namespace SOVTECH_ASSESSMENT
{
    public class Tests
    {
        public IWebDriver _driver { get; set; }

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        { 
            _driver.Navigate().GoToUrl("https://www.sovtech.co.za/contact-us/");

            WebDriverWait wait = new WebDriverWait(_driver,System.TimeSpan.FromSeconds(5000));

            IWebElement frameSwitch = wait.Until(drv =>drv.FindElement(By.XPath("//iframe[@title='Form 0']")));
            _driver.SwitchTo().Frame(0);
            IWebElement name = wait.Until(drv => drv.FindElement(By.XPath("//input[@name='your_name']")));
            name.SendKeys("Lesiba");
            IWebElement email = wait.Until(drv => drv.FindElement(By.XPath("//input[@name='email']")));
            email.SendKeys("lesiba@gmail.com");
            IWebElement mobilephone = wait.Until(drv => drv.FindElement(By.XPath("//input[@name='mobilephone']")));
            mobilephone.SendKeys("0837212345");
            IWebElement numemployees = wait.Until(drv => drv.FindElement(By.XPath("//select[@name='numemployees']")));
            numemployees.Click();
            SelectElement Sel = new SelectElement(numemployees);
            Sel.SelectByIndex(1);

            IWebElement businessType = wait.Until(drv => drv.FindElement(By.XPath("(//select[@name])[2]")));
	        SelectElement BussinessT = new SelectElement(businessType);
	        BussinessT.SelectByIndex(2);

            businessType.SendKeys(Keys.Enter);
            businessType.SendKeys(Keys.Enter);

            WebDriverWait waitt = new WebDriverWait(_driver,System.TimeSpan.FromSeconds(5000));
            IWebElement message = waitt.Until(drv => drv.FindElement(By.XPath("//textarea[@name='message']")));
            message.SendKeys("Testing");

            IWebElement checkbox = wait.Until(drv => drv.FindElement(By.XPath("//input[@type='checkbox']")));
            checkbox.Click();
            
            IWebElement sumbit = wait.Until(drv => drv.FindElement(By.XPath("//input[@type='submit']")));
            sumbit.Click();

            System.Threading.Thread.Sleep(5000);
            Assert.Pass();

        }

        [TearDown]
        public void TearDown()
        {
            if(_driver!=null)
            {
                 _driver.Close();
                 _driver.Quit();
            }
        }
    }
}