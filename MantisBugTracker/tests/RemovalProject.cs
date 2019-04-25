using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisBugTracker
{
    [TestFixture]
   public class RemovalProject :AuthTestBase
    {
        public static Random rnd = new Random();
        [Test]
        public void RemoveProject()
        {
            List<ProjectData> oldList = new List<ProjectData>();
            oldList = app.Proects.GetProjectList();
            if (oldList.Count < 1 || oldList.Count == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    ProjectData project = new ProjectData()
                    {
                        Project_name = BaseClass.GenerateRandomString(10),
                        Description = BaseClass.GenerateRandomString(50)
                    };
                    app.Proects.AdditionalProect(project);
                }
            }
            oldList = app.Proects.GetProjectList();
            app.Proects.RemoveProect(rnd.Next(0, oldList.Count - 1));
            List<ProjectData> newList = app.Proects.GetProjectList();
            Assert.AreEqual(oldList, newList);
            app.Auth.Logout();

        }

    }
}
