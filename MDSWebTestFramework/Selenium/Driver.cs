using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using MDS.WebTestFramework.Constants;
using System.Runtime.CompilerServices;
using MDS.WebTestFramework.Utility;

namespace MDS.WebTestFramework.Selenium
{
    public static class Driver
    {
        public static IWebDriver Instance { get; set; }
        //private const string IE_DRIVER_PATH = @"C:\Selenium_Drivers\";

        public static void Initialize()
        {
            //options for Internet Explorer driver
            var options = new InternetExplorerOptions
            {
                ForceCreateProcessApi = true,
                IgnoreZoomLevel = true,
                EnsureCleanSession = true,
                InitialBrowserUrl = "about:blank",
            };
            var optionsDefault = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true,
                EnsureCleanSession = true,
                InitialBrowserUrl = "about:blank",


            };

            if(RuntimeConstants.UseIEDriver)
            {
                Instance = new InternetExplorerDriver(RuntimeConstants.IEDriverPath, optionsDefault, TimeSpan.FromMinutes(2));
            }
            else
            {
                Instance = new ChromeDriver(RuntimeConstants.ChromeDriverPath);
            }

            Instance.Manage().Window.Maximize();

        }

        /// <summary>
        /// This method will allow the test to wait for the page to properly load.
        /// </summary>
        public static void WaitForLoad()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.Instance;
            
            WebDriverWait wait = new WebDriverWait(Driver.Instance, new TimeSpan(0, 0, RuntimeConstants.WaitForLoadTimeout));
            wait.Until(wd => Driver.Instance.Scripts().ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }

        /// <summary>
        /// This method will allow the driver to wait for a DOM element to be visible
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeoutSeconds"></param>
        /// <returns></returns>
        public static bool WaitForVisible(By by, int timeoutSeconds)
        {
            int elapsedSeconds = 0;
            while(elapsedSeconds < timeoutSeconds)
            {
                try
                {
                    var element = Instance.FindElement(by);
                    if (element.Displayed)
                    {
                        return true;
                    }
                }
                catch (Exception)
                { 
                    //TODO: add logging here
                }
                Thread.Sleep(1000); //pause for 1 second
            }

            return false;
        }

        /// <summary>
        /// This method will allow the Driver to wait for an element to be present.
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeoutSeconds"></param>
        public static void WaitForElementPresent(By by, int timeoutSeconds)
        {
            int elapsedSeconds = 0;
            while (elapsedSeconds < timeoutSeconds)
            {
                try
                {
                    if (IsElementPresent(by)) return;
                }
                catch (Exception)
                {
                    //TODO: add logging here
                }
                Thread.Sleep(1000); //pause for 1 second
            }
            throw new Exception("timeout waiting for element present: " + by);

        }

        /// <summary>
        /// Ths method will detect if a DOM element is present.
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public static bool IsElementPresent(By by)
        {
            try
            {
                Instance.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// This will close the browser possessed by the instance
        /// </summary>
        public static void Close()
        {
            Instance.Quit();
        }
    }
}
