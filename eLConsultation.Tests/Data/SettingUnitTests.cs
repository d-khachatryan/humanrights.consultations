using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eLConsultation.Data;

namespace eLConsultation.Tests.Data
{
    [TestClass]
    public class SettingUnitTests: SettingService
    {
       
        [TestMethod]
        public void TestSetSetting()
        {
            var db = new StoreContext();

            var itemToDelete = db.Settings.Where(p => p.SettingGroup == "TestSettingGroup" && p.SettingItem == "TestSettingItem" && p.SettingValue == "TestSettingValue");
            db.Settings.RemoveRange(itemToDelete);
            db.SaveChanges();

            //SettingService unit = new SettingService(db);
            this.SetSetting("TestSettingItem", "TestSettingGroup", "TestSettingValue");
            var itemToAssert = db.Settings.Where(p => p.SettingGroup == "TestSettingGroup" && p.SettingItem == "TestSettingItem" && p.SettingValue == "TestSettingValue");
            Assert.AreEqual(itemToAssert.Count(), 1);
        }

        [TestMethod]
        public void TestGetSettingByItem()
        {
            var db = new StoreContext();
            var itemToDelete = db.Settings.Where(p => p.SettingGroup == "TestSettingGroup" && p.SettingItem == "TestSettingItem" && p.SettingValue == "TestSettingValue");
            db.Settings.RemoveRange(itemToDelete);
            db.SaveChanges();

            var itemToAdd = new Setting
            {
                SettingItem = "TestSettingItem",
                SettingGroup = "TestSettingGroup",
                SettingValue = "TestSettingValue"
            };
            db.Settings.Add(itemToAdd);
            db.SaveChanges();

            SettingService unit = new SettingService(db);
            var itemToAssert = this.GetSettingByItem("TestSettingItem");
            Assert.IsNotNull(itemToAssert);
        }

        [TestMethod]
        public void TestGetSmtpSetting()
        {
            var db = new StoreContext();

            var userItemToDelete = db.Settings.Where(p => p.SettingGroup == "email");
            db.Settings.RemoveRange(userItemToDelete);
            db.SaveChanges();

            var userItemToAdd = new Setting
            {
                SettingItem = "username",
                SettingGroup = "email",
                SettingValue = "TestUser"
            };
            var passwordItemToAdd = new Setting
            {
                SettingItem = "password",
                SettingGroup = "email",
                SettingValue = "TestPassword"
            };

            var emailItemToAdd = new Setting
            {
                SettingItem = "email",
                SettingGroup = "email",
                SettingValue = "TestEmail"
            };

            var portItemToAdd = new Setting
            {
                SettingItem = "port",
                SettingGroup = "email",
                SettingValue = "25"
            };
            var deliveryMethodItemToAdd = new Setting
            {
                SettingItem = "deliverymethod",
                SettingGroup = "email",
                SettingValue = "1"
            };
            var useDefaultCredentialsItemToAdd = new Setting
            {
                SettingItem = "usedefaultcredentials",
                SettingGroup = "email",
                SettingValue = "true"
            };
            var enableSslItemToAdd = new Setting
            {
                SettingItem = "enablessl",
                SettingGroup = "email",
                SettingValue = "false"
            };
            db.Settings.Add(userItemToAdd);
            db.Settings.Add(passwordItemToAdd);
            db.Settings.Add(emailItemToAdd);
            db.Settings.Add(portItemToAdd);
            db.Settings.Add(deliveryMethodItemToAdd);
            db.Settings.Add(useDefaultCredentialsItemToAdd);
            db.Settings.Add(enableSslItemToAdd);
            db.SaveChanges();


            SmtpSettingService unit = new SmtpSettingService();
            //var itemToAssert = unit.GetSmtpSetting("email");
            //Assert.IsNotNull(itemToAssert);
        }
    }
}
