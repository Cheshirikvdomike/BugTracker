using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBugTracker
{
   public class ProjectHelper : HelperBase
    {

        private List<ProjectData> projectCashe = null;
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {

        }
       
        public ProjectHelper AdditionalProect(ProjectData project)
        {
            driver.FindElementByXPath("//*[@id='sidebar']//a[contains(@href,'/mantisbt-2.21.0/manage_overview_page.php')]").Click();
            driver.FindElementByXPath("//a[text()='Управление проектами']").Click();
            driver.FindElementByXPath("(//button[@type='submit'])[1]").Click();
            Type(By.Id("project-name"), project.Project_name);
            Type(By.Id("project-description"), project.Description);
            driver.FindElementByXPath("//input[@value='Добавить проект']").Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElements(By.Id("breadcrumbs")).Count > 0);
            return this;
        }

        public ProjectHelper RemoveProect(int index)
        {
            driver.FindElementByXPath("//*[@id='sidebar']//a[contains(@href,'/mantisbt-2.21.0/manage_overview_page.php')]").Click();
            string toRemoveProject = GetProjectList()[index].Project_name;
            driver.FindElement(By.XPath("//table/tbody/tr/td/a[text()='" + toRemoveProject + "']")).Click();
            driver.FindElementByXPath("//input[@value='Удалить проект']").Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElements(By.XPath("//ps")).Count > 0);
            return this;
        }

        public List<ProjectData> GetProjectList()
        {
            if (projectCashe == null)
            {
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table/tbody/tr/td"));
                ICollection<IWebElement> cells = null;
                foreach (IWebElement element in elements)
                {
                    cells = element.FindElements(By.XPath("//a[contains(@href,'manage_proj_edit_page.php?project')]"));
                    projectCashe.Add(new ProjectData(cells.ElementAt(1).Text));
                }
            }
            return new List<ProjectData>(projectCashe);
        }
    }
}
