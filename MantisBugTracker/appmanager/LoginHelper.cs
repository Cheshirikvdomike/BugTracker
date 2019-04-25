using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MantisBugTracker
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(LoginUserData loginUserData)//?
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(loginUserData))
                { return; }
                Logout();
            }
            Type(By.Id("username"), loginUserData.Login);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElements(By.Id("password")).Count>0);
            Type(By.Id("password"), loginUserData.Password);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public bool IsLoggedIn(LoginUserData loginUserData)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == loginUserData.Login;

        }
        private string GetLoggetUserName()
        {
            string text = driver.FindElement(By.XPath("//span[@class='user-info']")).Text;//?
            return text.Substring(1, text.Length - 2);
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Id("breadcrumbs"));//?
        }

        public void Logout()
        {   
            if (IsLoggedIn())
            {
                driver.FindElement(By.XPath("//span[@class='user-info']")).Click();
                driver.FindElement(By.XPath("//*[text()=' Выход']")).Click();//?
                
            }
        }
    }
}
