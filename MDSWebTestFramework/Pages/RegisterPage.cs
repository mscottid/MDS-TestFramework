using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDS.WebTestFramework.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using MDS.WebTestFramework.Models.Registration;

using MDS.WebTestFramework.Models.Utility;
using MDS.WebTestFramework.Utility;
using System.Threading;

namespace MDS.WebTestFramework.Pages
{
    public class RegisterPage: PageBase
    {
        public RegisterPage(): base()
        {

        }

        public void RegisterNewUser(FakeUserRootObject model)
        {
            try
            {
               //TODO: check for results collection being null.

                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(30));
                string pwd = "!Parsnip451"; //TODO: modify password helper for casing rules.

                var emailTextField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Email")));
                emailTextField.SendKeys(model.results[0].email);

                var usernameTextField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Username")));
                usernameTextField.SendKeys(model.results[0].login.username);

                var passwordTextField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Password")));
                passwordTextField.SendKeys(pwd);

                var confirmPasswordTextField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("ConfirmPassword")));
                confirmPasswordTextField.SendKeys(pwd);

                Thread.Sleep(3);

                var submitBtn = Driver.Instance.FindElement(By.Id("btnRegSubmit"));
                Driver.Instance.JavascriptClick(submitBtn);

            }
            catch(Exception ex)
            {
                //TODO: incorporat logging here
            }
        }


    }
}
