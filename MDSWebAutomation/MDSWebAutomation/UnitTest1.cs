using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDS.WebTestFramework.Selenium;
using OpenQA.Selenium;
using MDS.WebTestFramework.Pages;
using MDS.WebTestFramework.Constants;
using MDS.WebTestFramework.Utility;

namespace MDSWebAutomation
{
    
    [TestClass]
    public class UnitTest1
    {

        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Driver.Instance.Navigate().GoToUrl("http://www.aol.com");
        }

        [TestMethod]
        [TestCategory("Registration")]
        public void RegisterNewUser()
        {
            var user = UserTestGoodies.GetRandomUser();
            var regPage = new RegisterPage();
            regPage.BaseUrl = RuntimeConstants.RegistrationBasePageUrl;
            regPage.GoTo();
            regPage.RegisterNewUser(user);

            //TODO: validate random user object in COSMOS database and apply Assert
            Driver.Instance.Close();
        }
    }
}
