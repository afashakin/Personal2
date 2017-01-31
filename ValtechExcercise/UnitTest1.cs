using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Collections.Generic;

namespace ValtechExcercise
{
    [TestFixture]
    public class UnitTest1
    {

        //Create reference to the Driver
        IWebDriver driver = new FirefoxDriver();
        String checkTextNews = "Latest news";
        public static IList<IWebElement> elements;
        [SetUp]
        public void Initialise() {
        Console.WriteLine("Running SetUP");
        driver.Navigate().GoToUrl("https://www.valtech.com");
        }
        [Test]
        public void LatestNews()
        {
            //Test to determine if Latest News section is displayed
            Console.WriteLine("Assert to determine if Latest News section is displayed");
            NUnit.Framework.Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains(checkTextNews));

        }

        [Test]
        public void work_link()
        {
            driver.FindElement(By.XPath(".//div[@id='navigationMenuWrapper']//div//a[text()='Work']")).Click();
            NUnit.Framework.Assert.IsTrue(driver.FindElement(By.TagName("h1")).Text.Contains("Work"));
            driver.FindElement(By.ClassName("valtech-logo--header glyph")).Click();
        }

        [Test]
        public void services_link()
        {
            driver.FindElement(By.XPath(".//div[@id='navigationMenuWrapper']//div//a[text()='services']")).Click();
            NUnit.Framework.Assert.IsTrue(driver.FindElement(By.TagName("h1")).Text.Contains("Services"));
            driver.FindElement(By.ClassName("valtech-logo--header glyph")).Click();
        }

        [Test]
        public void jobs_link()
        {
            driver.FindElement(By.XPath(".//div[@id='navigationMenuWrapper']/div/ul/li[5]//a[Text='Careers']")).Click();
            NUnit.Framework.Assert.IsTrue(driver.FindElement(By.TagName("h1")).Text.Contains("Careers"));
            driver.FindElement(By.ClassName("valtech-logo--header glyph")).Click();

        }

        [Test]
        public void contacts()
        {
            driver.FindElement(By.XPath(".//div[@id='navigationMenuWrapper']/div/ul/li[6]/a[Text()='Investors']")).Click();
            driver.FindElement(By.XPath(".//div[@id='container']/div[8]/div[2]/a[Text()='Valtech Offices']")).Click();
            elements = driver.FindElements(By.XPath(".//div[@id='container']/section/div/h2"));
            Console.WriteLine("The number of Offices Valtech have is " + elements);
         }

    [TearDown]
        public void Cleanup()
        {

            driver.Quit();

        }
    }
}
