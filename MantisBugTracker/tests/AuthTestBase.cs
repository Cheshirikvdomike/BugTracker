using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace MantisBugTracker
{
    public class AuthTestBase : BaseClass
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new LoginUserData("administrator", "123456"));//Логин на сайт
        }
    }
}
