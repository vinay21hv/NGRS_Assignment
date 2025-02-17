﻿using NGRS_BDD_API_UI_Assignment.ApplicationLayer;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing.Imaging;
using TechTalk.SpecFlow;

namespace NGRS_BDD_API_UI_Assignment.Helpers
{
    [Binding]
    public class Utils : BasePage
    {
        public static void WaitUntilElementToBeClickable(IWebElement element, int TimeOut, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOut));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitForPageTitle(int TimeOut, IWebDriver driver, string Title)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOut));
            wait.Until(ExpectedConditions.TitleContains(Title));
        }

        public static void EnterText(IWebElement element, string TextToEnter)
        {
            element.Clear();
            element.SendKeys(TextToEnter);
        }

        public static void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public static void GetScreenShot()
        {
            try
            {
                Screenshot image = ((ITakesScreenshot)Driver).GetScreenshot();
                string fileName = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                          @"\Screenshot" + "_" +
                          DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)") + ".png");
                image.SaveAsFile(fileName, ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail("Failed with Exception: " + e);
            }
        }
    }
}
