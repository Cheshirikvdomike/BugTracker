using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;

namespace MantisBugTracker
{
    public class ApplicationManager
    {
        protected FirefoxDriver driver;
        protected LoginHelper loginHelper;
        protected ProjectHelper projectHelper;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        protected string baseUrl;

        private ApplicationManager()
        {
            driver = new FirefoxDriver();

        }

        public static ApplicationManager GetInstance()
        {
            if (app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                app.Value = newInstance;
                newInstance.driver.Url = "http://localhost/mantisbt-2.21.0/login_page.php";
             }

            return app.Value;
        }

        public FirefoxDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public ProjectHelper Proects
        {
            get { return projectHelper; }
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception) { }
        }


        
    }

}
