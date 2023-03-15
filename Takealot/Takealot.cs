using System;
using Xunit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Takealot
{
    public class Takealot
    {
        [Fact]
        public void AddItemtoCart()
        {

            // Variable

            string TextSearch = ("FIVESTAR 48V 10KVA 10KW Hybrid Solar Inverter MPPT WIFI COMPATIBLE");

            // ChromeDriver Setup

            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalChromeOption("useAutomationExtension",false);
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Open URL and Maximise Window

            driver.Navigate().GoToUrl("https://www.takealot.com");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

            // Input Search Word

            driver.FindElement(By.XPath("//*[@id=\"shopfront-app\"]/header/div/div/div[2]/form/div/div[1]/input")).SendKeys(TextSearch);
            Thread.Sleep(2000);

            // Click Search

            driver.FindElement(By.XPath("//*[@id=\"shopfront-app\"]/header/div/div/div[2]/form/div[1]/div[2]/button")).Click();
            Thread.Sleep(2000);

            // Click Add to Cart on First Search Result

            driver.FindElement(By.XPath("//*[@id=\"91127643\"]/div/div[4]/div/button")).Click();
            Thread.Sleep(2000);

            // Click on Cart Icon

            driver.FindElement(By.XPath("//*[@id=\"shopfront-app\"]/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[1]/button/div[2]/div/div")).Click();
            Thread.Sleep(2000);

            // Grab Text to Assert against expected values

            string headingText = driver.FindElement(By.XPath("//*[@id=\"shopfront-app\"]/div[3]/div[2]/section/div[2]/div[1]/div[1]/div/div/article/div/div/div[3]/div/div[1]/div/div[1]/div[1]/div/a/h3")).Text;
            string checkoutButton = driver.FindElement(By.XPath("//*[@id=\"shopfront-app\"]/div[3]/div[2]/section/div[2]/div[2]/div/div[1]/div[3]/div/div[2]/a")).Text;

            // Assertions

            // Assert that name of searched item is displaying in cart

            Assert.Equal(headingText, TextSearch);

            //  Assert that Proceed to Checkout button is displaying

            Assert.Equal("Proceed to Checkout", checkoutButton);

            Thread.Sleep(2000);

            // Close Browser

            driver.Close();
            driver.Dispose();


        }
    }
}