using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MDS.WebTestFramework.Selenium;
using OpenQA.Selenium;

namespace MDS.WebTestFramework.Pages
{
    public class PageBase
    {
        public string BaseUrl {get; set;}
        public void GoTo()
        {
            if (!string.IsNullOrEmpty(this.BaseUrl))
            {
                Driver.Instance.Navigate().GoToUrl(this.BaseUrl);
                Driver.WaitForLoad();
            }
            else
            {
                throw new Exception("base url property must be set");
            }

        }

        public PageBase()
        {

        }
    }
}
