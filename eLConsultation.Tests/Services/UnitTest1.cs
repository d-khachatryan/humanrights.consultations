using System;
using eLConsultation.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eLConsultation.Tests.Services
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ResidentService s = new ResidentService();
            var o = s.GetOralConsultationsByResidentID(6);
            Assert.AreEqual(o.Count, 1);
            var t = s.GetTypeConsultationsByResidentID(6);
            Assert.AreEqual(t.Count, 1);
        }
    }
}
