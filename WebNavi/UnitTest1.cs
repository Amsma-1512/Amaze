using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.Ajax.Utilities;

namespace WebNavi
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver ChromeD;
       
        

        [AssemblyInitialize]
        public static void Setup(TestContext context)
        {
            ChromeD = new ChromeDriver(@"C:\Users\amsma\source\repos\Amaze\packages\Selenium.WebDriver.ChromeDriver.88.0.4324.9600\driver\win32");
           
            
        }

        [TestMethod]
        public void TChromeDriver()
        {
            double basePrice = 100.00;
            //Navigating to Amazon webpage
            ChromeD.Navigate().GoToUrl("https://www.amazon.com/");
            //Search for Laptop
            ChromeD.FindElement(By.Id("twotabsearchtextbox")).SendKeys("Laptop");
            ChromeD.FindElement(By.Id("nav-search-submit-button")).SendKeys(Keys.Enter);
            ChromeD.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //To Select the First result on searching Laptop, also to skip the AdHolders
            //Selects the first actual result ignoring the advertisements and Sponsors
            ChromeD.FindElement(By.XPath("(//a[@class='a-link-normal a-text-normal' and ancestor::div[@class='s-result-item s-asin sg-col-0-of-12 sg-col-16-of-20 sg-col sg-col-12-of-16']])[1]")).Click();
            ChromeD.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            string Price = ChromeD.FindElement(By.Id("price_inside_buybox")).Text;
            double priceValue = Convert.ToDouble(Price.Substring(1));
            //if (priceValue > basePrice) { }
            //   Console.WriteLine(priceValue);
            //To Check if the Laptop price is greater than 100$
            Assert.IsTrue(priceValue > basePrice, "Price is less than $100");
            Console.WriteLine ("Execution completed");
            ChromeD.Close();
            ChromeD.Quit();
        }

        

        [TestCleanup]
        public void TearDown()
        {
            ChromeD.Quit();
        }
    }
}
