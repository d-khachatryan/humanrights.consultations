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
    public class IssueTypeTests
    {
        HttpContextBase abstractContext;
        public IssueTypeTests()
        {
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            abstractContext = new System.Web.HttpContextWrapper(HttpContext.Current);
        }

        [TestMethod]
        public void TestGetIssueTypes()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SQLConnectionString))
            {
                connection.Open();

                DeleteTables(connection);

                int ID1 = -1;
                string name1 = "Test";
                Create(connection, ID1, name1);

                int ID2 = -2;
                string name2 = "Test";
                Create(connection, ID2, name2);

                IssueTypeService issueTypeService = new IssueTypeService();
                IList<IssueTypeItem> issueTypeItemList = issueTypeService.GetIssueTypes();

                Assert.AreEqual(issueTypeItemList.Count, 2);
            }
        }

        [TestMethod]
        public void TestCreateIssueType()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SQLConnectionString))
            {
                connection.Open();

                DeleteTables(connection);

                string name = "TestIssueType1";
                IssueTypeService issueTypeService = new IssueTypeService();
                IssueTypeItem issueTypeItem = new IssueTypeItem
                {
                    IssueTypeName = name
                };

                issueTypeService.CreateIssueType(issueTypeItem);

                int count = GetCount(connection, name);

                Assert.AreEqual(count, 1);
            }
        }

        [TestMethod]
        public void TestUpdateIssueType()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SQLConnectionString))
            {
                connection.Open();

                DeleteTables(connection);

                int ID = -1;
                string name = "XXXZZZ";

                Create(connection, ID, name);

                string updatedName = "XXXZZZUUU";

                IssueTypeService issueTypeService = new IssueTypeService();
                IssueTypeItem issueTypeItem = new IssueTypeItem
                {
                    IssueTypeID = -1,
                    IssueTypeName = updatedName
                };

                issueTypeService.UpdateIssueType(issueTypeItem);

                int count = GetCount(connection, updatedName);

                Assert.AreEqual(count, 1);
            }
        }

        [TestMethod]
        public void TestDeleteIssueType()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SQLConnectionString))
            {
                connection.Open();

                DeleteTables(connection);

                int ID = -1;
                string name = "Test";
                Create(connection, ID, name);

                IssueTypeService issueTypeService = new IssueTypeService();
                IssueTypeItem issueTypeItem = new IssueTypeItem
                {
                    IssueTypeID = ID
                };

                issueTypeService.DeleteIssueType(issueTypeItem);

                int count = GetCount(connection);

                Assert.AreEqual(count, 0);
            }
        }

        private void DeleteTables(SqlConnection connection)
        {
            string clearCommandText = "DELETE FROM dbo.TypeConsultation " +
                    "DELETE FROM dbo.OralConsultation " +
                    "DELETE FROM dbo.Issue " +
                    "DELETE FROM dbo.IssueType";
            SqlCommand deleteCommand = new SqlCommand(clearCommandText, connection);
            deleteCommand.ExecuteNonQuery();
        }

        private void Create(SqlConnection connection, int issueTypeID, string issueTypeName)
        {
            string commandText = "SET IDENTITY_INSERT IssueType ON " +
                " INSERT INTO dbo.IssueType (IssueTypeID, IssueTypeName) VALUES (@IssueTypeID, @IssueTypeName)" +
                " SET IDENTITY_INSERT IssueType OFF";
            SqlCommand insertCommand = new SqlCommand(commandText, connection);
            SqlParameter prmIssueTypeID = new SqlParameter("@IssueTypeID", SqlDbType.Int);
            SqlParameter prmIssueTypeName = new SqlParameter("@IssueTypeName", SqlDbType.NVarChar);
            insertCommand.Parameters.Add(prmIssueTypeID);
            insertCommand.Parameters.Add(prmIssueTypeName);
            prmIssueTypeID.Value = issueTypeID;
            prmIssueTypeName.Value = issueTypeName;
            insertCommand.ExecuteNonQuery();
        }

        private int GetCount(SqlConnection connection, string issueTypeName)
        {
            string selectCommandText = "SELECT Count(*) FROM dbo.IssueType WHERE IssueTypeName = '" + issueTypeName + "'";
            SqlCommand selectCommand = new SqlCommand(selectCommandText, connection);
            int count = (int)selectCommand.ExecuteScalar();
            return count;
        }

        private int GetCount(SqlConnection connection)
        {
            string selectCommandText = "SELECT Count(*) FROM dbo.IssueType";
            SqlCommand selectCommand = new SqlCommand(selectCommandText, connection);
            int count = (int)selectCommand.ExecuteScalar();
            return count;
        }
    }
}
