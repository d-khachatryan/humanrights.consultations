using System.Data.SqlClient;
using System.Data;
using eLConsultation.Data;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.IO;

namespace eLConsultation.Tests.Data
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void IsAdminUserExistsTest()
        {
            UserService service = new UserService();
            bool a = service.IsUserInRole("administrator");
            Assert.AreEqual(a, true);
        }        
    }
}
