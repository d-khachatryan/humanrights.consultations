using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class IssueService : ServiceBase
    {
        public IssueService()
            : base()
        {
        }

        public List<SelectListItem> GetIssueTypeDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            IssueTypeService issueType = new IssueTypeService();
            selectedListItem = issueType.GetIssueTypes().Select(x => new SelectListItem { Text = x.IssueTypeName, Value = x.IssueTypeID.ToString() }).ToList();
            return selectedListItem;
        }

        public List<SelectListItem> GetIssueCategoryDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            IssueCategoryService issueCategory = new IssueCategoryService();
            selectedListItem = issueCategory.GetIssueCategorys().Select(x => new SelectListItem { Text = x.IssueCategoryName, Value = x.IssueCategoryID.ToString() }).ToList();
            return selectedListItem;
        }

        public IList<IssueSetItem> SearchIssueSetItems(IssueSearch issueSearch)
        {
            var issueQuery = from issue in db.Issues
                             join t2 in db.IssueTypes on issue.IssueTypeID equals t2.IssueTypeID into r2
                             from issuetype in r2.DefaultIfEmpty()
                             join t3 in db.IssueCategorys on issue.IssueCategoryID equals t3.IssueCategoryID into r3
                             from issuecategory in r3.DefaultIfEmpty()
                             where issue.ResidentID == null
                             select new { IssueTable = issue, IssueTypeTable = issuetype, IssueCategoryTable = issuecategory };

            if (issueSearch.IssueName != "")
            {
                issueQuery = from p in issueQuery where p.IssueTable.IssueName.StartsWith(issueSearch.IssueName) select p;
            }

            IList<IssueSetItem> result = issueQuery.Select(list => new IssueSetItem
            {
                IssueID = list.IssueTable.IssueID,
                ResidentID = list.IssueTable.ResidentID,
                IssueName = list.IssueTable.IssueName,
                IssueDescription = list.IssueTable.IssueDescription,
                IssueDate = list.IssueTable.IssueDate,
                IssueTypeID = list.IssueTable.IssueTypeID,
                IssueTypeName = list.IssueTypeTable.IssueTypeName,
                CompanyID = list.IssueTable.CompanyID,
                IssueCategoryID = list.IssueCategoryTable.IssueCategoryID,
                IssueCategoryName = list.IssueCategoryTable.IssueCategoryName
            }).ToList();

            return result;
        }

        public IList<IssueSetItem> GetIssueSetItemsByResidentID(int residentID)
        {
            IList<IssueSetItem> result = new List<IssueSetItem>();

            result = (from issue in db.Issues
                      join t1 in db.Residents on issue.ResidentID equals t1.ResidentID into r1
                      from resident in r1.DefaultIfEmpty()
                      join t2 in db.IssueTypes on issue.IssueTypeID equals t2.IssueTypeID into r2
                      from issuetype in r2.DefaultIfEmpty()

                      join t3 in db.IssueCategorys on issue.IssueCategoryID equals t3.IssueCategoryID into r3
                      from issuecategory in r3.DefaultIfEmpty()

                      where issue.ResidentID == residentID
                      select new { IssueTable = issue, ResidentTable = resident, IssueTypeTable = issuetype, IssueCategoryTable = issuecategory })
                         .Select(list => new IssueSetItem
                         {
                             IssueID = list.IssueTable.IssueID,
                             ResidentID = list.IssueTable.ResidentID,
                             FirstName = list.ResidentTable.FirstName,
                             LastName = list.ResidentTable.LastName,
                             MiddleName = list.ResidentTable.MiddleName,
                             IdentificatorNumber = list.ResidentTable.IdentificatorNumber,
                             BirthDate = list.ResidentTable.BirthDate,
                             IssueName = list.IssueTable.IssueName,
                             IssueDescription = list.IssueTable.IssueDescription,
                             IssueDate = list.IssueTable.IssueDate,
                             IssueTypeID = list.IssueTable.IssueTypeID,
                             IssueTypeName = list.IssueTypeTable.IssueTypeName,

                             CompanyID = list.IssueTable.CompanyID,
                             IssueCategoryID = list.IssueCategoryTable.IssueCategoryID,
                             IssueCategoryName = list.IssueCategoryTable.IssueCategoryName
                         }).ToList();

            return result;
        }


        public IList<IssueSetItem> GetIssueSetItemsByCompanyID(int companyID)
        {
            IList<IssueSetItem> result = new List<IssueSetItem>();

            result = (from issue in db.Issues
                      join t1 in db.Companys on issue.CompanyID equals t1.CompanyID into r1
                      from company in r1.DefaultIfEmpty()
                      join t2 in db.IssueTypes on issue.IssueTypeID equals t2.IssueTypeID into r2
                      from issuetype in r2.DefaultIfEmpty()
                      join t3 in db.IssueCategorys on issue.IssueCategoryID equals t3.IssueCategoryID into r3
                      from issuecategory in r3.DefaultIfEmpty()
                      where issue.CompanyID == companyID
                      select new { IssueTable = issue, CompanyTable = company, IssueTypeTable = issuetype, IssueCategoryTable = issuecategory })
                         .Select(list => new IssueSetItem
                         {
                             IssueID = list.IssueTable.IssueID,
                             ResidentID = list.IssueTable.ResidentID,

                             CompanyID = list.CompanyTable.CompanyID,
                             CompanyName = list.CompanyTable.CompanyName,

                             IssueName = list.IssueTable.IssueName,
                             IssueDescription = list.IssueTable.IssueDescription,
                             IssueDate = list.IssueTable.IssueDate,
                             IssueTypeID = list.IssueTable.IssueTypeID,
                             IssueTypeName = list.IssueTypeTable.IssueTypeName,

                             IssueCategoryID = list.IssueCategoryTable.IssueCategoryID,
                             IssueCategoryName = list.IssueCategoryTable.IssueCategoryName
                         }).ToList();

            return result;
        }

        public IssueItem GetIssueItemByID(int issueID)
        {
            var issue = db.Issues.Find(issueID);

            Resident resident = null;
            if (issue.ResidentID != null)
            {
                resident = db.Residents.Find(issue.ResidentID);
            }

            Company company = null;
            if (issue.CompanyID != null)
            {
                company = db.Companys.Find(issue.CompanyID);
            }

            if (issue == null)
            {
                throw new NullReferenceException(String.Format("There is no record in the 'Issue' table with given {0} ID", issueID));
            }

            IssueItem item = new IssueItem();

            if (issue.IssueCategoryID == 1)
            {
                item.IssueID = issue.IssueID;
                item.IssueName = issue.IssueName;
                item.IssueDescription = issue.IssueDescription;
                item.IssueDate = issue.IssueDate;
                item.IssueCategoryID = issue.IssueCategoryID;
                item.IssueTypeID = issue.IssueTypeID;

                item.ResidentID = issue.ResidentID;

                if (resident != null)
                {
                    item.FirstName = resident.FirstName;
                    item.LastName = resident.LastName;
                    item.MiddleName = resident.MiddleName;
                    item.IdentificatorNumber = resident.IdentificatorNumber;
                    item.BirthDate = resident.BirthDate;
                }

            }
            else if (issue.IssueCategoryID == 2)
            {
                item.IssueID = issue.IssueID;
                item.IssueName = issue.IssueName;
                item.IssueDescription = issue.IssueDescription;
                item.IssueDate = issue.IssueDate;
                item.IssueCategoryID = issue.IssueCategoryID;
                item.IssueTypeID = issue.IssueTypeID;

                item.CompanyID = issue.CompanyID;

                if (company != null)
                {
                    item.CompanyName = company.CompanyName;
                }
            }
            else
            {
                throw new NullReferenceException(String.Format("The issue have not a category"));
            }
            return item;
        }

        public AnonymousIssueItem GetAnonymousIssueItem()
        {
            AnonymousIssueItem item = new AnonymousIssueItem
            {
                IssueID = 0,
                IssueName = String.Empty,
                IssueDescription = String.Empty,
                IssueDate = null,
                IssueTypeID = null,
                IssueCategoryID = 1,
            };

            item.InitializationType = InitializationTypes.Insert;

            return item;

        }

        public IssueItem GetIssueItemByResidentID(int residentID)
        {

            var resident = db.Residents.Find(residentID);

            if (resident == null)
            {
                throw new NullReferenceException(String.Format("There is no record in the 'Resident' table with given {0} ID", residentID));
            }

            IssueItem item = new IssueItem
            {
                IssueID = 0,
                ResidentID = resident.ResidentID,
                FirstName = resident.FirstName,
                LastName = resident.LastName,
                MiddleName = resident.MiddleName,
                IdentificatorNumber = resident.IdentificatorNumber,
                BirthDate = resident.BirthDate,
                IssueName = String.Empty,
                IssueDescription = String.Empty,
                IssueDate = null,
                IssueTypeID = null,
                IssueCategoryID = 1,
                CompanyID = null,
                CompanyName = null
            };

            item.InitializationType = InitializationTypes.Insert;

            return item;

        }

        public IssueItem GetIssueItemByCompanyID(int companyID)
        {
            var company = db.Companys.Find(companyID);

            if (company == null)
            {
                throw new NullReferenceException(String.Format("There is no record in the 'Company' table with given {0} ID", companyID));
            }

            IssueItem item = new IssueItem
            {
                IssueID = 0,
                ResidentID = null,
                IssueName = String.Empty,
                IssueDescription = String.Empty,
                IssueDate = null,
                IssueTypeID = null,

                IssueCategoryID = 2,
                CompanyID = company.CompanyID,
                CompanyName = company.CompanyName
            };

            item.InitializationType = InitializationTypes.Insert;

            return item;

        }

        public AnonymousIssueItem SaveAnonymousIssue(AnonymousIssueItem anonymousIssueItem)
        {
            Issue issue = null;
            switch (anonymousIssueItem.InitializationType)
            {
                case InitializationTypes.Insert:
                    issue = new Issue
                    {
                        IssueID = 0,
                        ResidentID = null,
                        IssueName = anonymousIssueItem.IssueName,
                        IssueDescription = anonymousIssueItem.IssueDescription,
                        IssueDate = anonymousIssueItem.IssueDate,
                        IssueTypeID = anonymousIssueItem.IssueTypeID,

                        IssueCategoryID = anonymousIssueItem.IssueCategoryID,
                        CompanyID = null
                    };
                    db.Issues.Add(issue);
                    break;
                case InitializationTypes.Update:
                    issue = new Issue
                    {
                        IssueID = anonymousIssueItem.IssueID,
                        ResidentID = null,
                        IssueName = anonymousIssueItem.IssueName,
                        IssueDescription = anonymousIssueItem.IssueDescription,
                        IssueDate = anonymousIssueItem.IssueDate,
                        IssueTypeID = anonymousIssueItem.IssueTypeID,

                        IssueCategoryID = anonymousIssueItem.IssueCategoryID,
                        CompanyID = null
                    };
                    db.Issues.Attach(issue);
                    db.Entry(issue).State = EntityState.Modified;
                    break;
            }
            db.SaveChanges();
            anonymousIssueItem.IssueID = issue.IssueID;
            return anonymousIssueItem;
        }

        public IssueItem SaveIssue(IssueItem issueItem)
        {
            Issue issue = null;
            switch (issueItem.InitializationType)
            {
                case InitializationTypes.Insert:
                    issue = new Issue
                    {
                        IssueID = 0,
                        ResidentID = issueItem.ResidentID,
                        IssueName = issueItem.IssueName,
                        IssueDescription = issueItem.IssueDescription,
                        IssueDate = issueItem.IssueDate,
                        IssueTypeID = issueItem.IssueTypeID,

                        IssueCategoryID = issueItem.IssueCategoryID,
                        CompanyID = issueItem.CompanyID
                    };
                    db.Issues.Add(issue);
                    break;
                case InitializationTypes.Update:
                    issue = new Issue
                    {
                        IssueID = issueItem.IssueID,
                        ResidentID = issueItem.ResidentID,
                        IssueName = issueItem.IssueName,
                        IssueDescription = issueItem.IssueDescription,
                        IssueDate = issueItem.IssueDate,
                        IssueTypeID = issueItem.IssueTypeID,

                        IssueCategoryID = issueItem.IssueCategoryID,
                        CompanyID = issueItem.CompanyID
                    };
                    db.Issues.Attach(issue);
                    db.Entry(issue).State = EntityState.Modified;
                    break;
            }
            db.SaveChanges();
            issueItem.IssueID = issue.IssueID;
            return issueItem;
        }

        public bool? DeleteIssue(int issueID)
        {
            try
            {
                var item = db.Issues.Find(issueID);
                if (item != null)
                {
                    db.Issues.Remove(item);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public virtual void HandleException(Exception exception)
        {
            if (exception is DbUpdateConcurrencyException concurrencyEx)
            {
                // A custom exception of yours for concurrency issues
                throw new Exception(String.Format("Դուք չեք կարող հեռացնել խնդիրը, քանի որ տվյալ խնդրի շրջանակում առկա է խորհրդատվություն"));
            }
            else if (exception is DbUpdateException dbUpdateEx)
            {
                if (dbUpdateEx.InnerException != null
                        && dbUpdateEx.InnerException.InnerException != null)
                {
                    if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627:  // Unique constraint error
                            case 547:   // Constraint check violation
                            case 2601:  // Duplicated key row error
                                        // Constraint violation exception
                                        // A custom exception of yours for concurrency issues
                                throw new Exception(String.Format("Դուք չեք կարող հեռացնել խնդիրը, քանի որ տվյալ խնդրի շրջանակում առկա է խորհրդատվություն"));
                            default:
                                //// A custom exception of yours for other DB issues
                                //throw new DatabaseAccessException(
                                //dbUpdateEx.Message, dbUpdateEx.InnerException);
                                throw new Exception(String.Format("Դուք չեք կարող հեռացնել խնդիրը, քանի որ տվյալների բազան հասանելի չէ"));
                        }
                    }

                    //throw new DatabaseAccessException(dbUpdateEx.Message, dbUpdateEx.InnerException);
                    throw new Exception(String.Format("Դուք չեք կարող հեռացնել խնդիրը, քանի որ տվյալների բազան հասանելի չէ"));
                }
            }

            // If we're here then no exception has been thrown
            // So add another piece of code below for other exceptions not yet handled...
        }

    }

}

