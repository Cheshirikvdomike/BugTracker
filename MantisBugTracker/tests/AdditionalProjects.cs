using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisBugTracker
{
    [TestFixture]
    public class AccountCreationTests:AuthTestBase
    {
        [Test]
        public void AddProjectToBT()
        {
            ProjectData project = new ProjectData()
            {
                Project_name = BaseClass.GenerateRandomString(10),
                Description = BaseClass.GenerateRandomString(50)
            };

            List<ProjectData> oldList = app.Proects.GetProjectList();
            
            app.Proects.AdditionalProect(project);
            List<ProjectData> newList = app.Proects.GetProjectList();
            Assert.AreEqual(oldList, newList);
            app.Auth.Logout();
        }
        
    }
}
