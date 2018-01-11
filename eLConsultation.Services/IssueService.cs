using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IList<IssueSetItem> GetIssueSetItemsByResidentID(int residentID)
        {
            try
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
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }


        public IList<IssueSetItem> GetIssueSetItemsByCompanyID(int companyID)
        {
            try
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
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public IssueItem GetIssueItemByID(int issueID)
        {
            try
            {
                var issue = db.Issues.Find(issueID);
                var resident = db.Residents.Find(issue.ResidentID);
                var company = db.Companys.Find(issue.CompanyID);

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
                    item.FirstName = resident.FirstName;
                    item.LastName = resident.LastName;
                    item.MiddleName = resident.MiddleName;
                    item.IdentificatorNumber = resident.IdentificatorNumber;
                    item.BirthDate = resident.BirthDate;

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
                    item.CompanyName = company.CompanyName;
                }
                else
                {
                    throw new NullReferenceException(String.Format("The issue have not a category"));
                }
                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
        }


        public IssueItem GetIssueItemByResidentID(int residentID)
        {
            try
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
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
        }

        public IssueItem GetIssueItemByCompanyID(int companyID)
        {
            try
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
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
        }


        public IssueItem SaveIssue(IssueItem issueItem)
        {
            try
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
                            IssueID = 0,
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
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

    }

}

