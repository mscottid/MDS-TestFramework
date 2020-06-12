using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MDS.WebTestFramework.Utility
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Extension method to provide JevaScript Executor
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static IJavaScriptExecutor Scripts(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }

        /// <summary>
        /// Extension method to assist in clicking web element 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void JavascriptClick(this IWebDriver driver, IWebElement element)
        {
            driver.Scripts().ExecuteScript("arguments[0].click();", element);
        }

        private static void HighlightElement(this IWebDriver driver, By selectonScheme, int duration = 2)
        {
            var element = driver.FindElement(selectonScheme);
            var originalStyle = element.GetAttribute("style");

            driver.Scripts().ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, "Style", "border: 7px solid yellow;border-style: dashed;");

            if (duration <= 0) 
                return;
            Thread.Sleep(TimeSpan.FromSeconds(duration));
            driver.Scripts().ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, "Style", originalStyle);

        }
    }

}
