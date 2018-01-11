using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eLConsultation.Data;
using System.Collections.Generic;

namespace eLConsultation.Tests.Data
{
    [TestClass]
    public class OralConsultationPermissionTests
    {
        [TestMethod]
        public void UserListTest()
        {
            OralConsultationPermissionService obj = new OralConsultationPermissionService(new StoreContext());
            IList<AspNetUsers> item = new List<AspNetUsers>();
            item = obj.UserList();
            Assert.AreNotEqual(0, item.Count);
        }

        [TestMethod]
        public void InsertPermissionTest()
        {
            OralConsultationPermissionService obj = new OralConsultationPermissionService(new StoreContext());
            OralConsultationPermissionItem item = new OralConsultationPermissionItem
            {
                OralConsultationPermissionID = 0,
                OralConsultationID = null,
                UserID = "4B14DB66-29E2-4373-B88A-0B9677728611",
                IsRead = true,
                IsChange = true,
                GUID = new Guid("4B14DB66-29E2-4373-B88A-0B9677728611")
            };
            OralConsultationPermissionItem result = obj.InsertPermission(item);
            Assert.AreNotEqual(null, result);
        }
    }
}
