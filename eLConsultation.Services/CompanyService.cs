using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class CompanyService : ServiceBase
    {
        public CompanyService()
            : base()
        {

        }
        public IList<CompanyItem> GetCompanys()
        {
            IList<CompanyItem> result = new List<CompanyItem>();

            result = db.Companys.Select(product => new CompanyItem
            {
                CompanyID = product.CompanyID,
                CompanyName = product.CompanyName
            }).ToList();
            return result;
        }

        public IList<CompanyTypeConsultationSet> GetTypeConsultationsByCompanyID(int companyID)
        {
            IList<CompanyTypeConsultationSet> result = new List<CompanyTypeConsultationSet>();

            var query = from typeconsultation in db.TypeConsultations
                        join t1 in db.Issues on typeconsultation.IssueID equals t1.IssueID
                        into r1
                        from issue in r1.DefaultIfEmpty().Where(p => p.CompanyID == companyID)
                        join t11 in db.IssueTypes on issue.IssueTypeID equals t11.IssueTypeID into r11
                        from issueType in r11.DefaultIfEmpty()
                        join t12 in db.IssueCategorys on issue.IssueCategoryID equals t12.IssueCategoryID into r12
                        from issueCategory in r12.DefaultIfEmpty()
                        join t2 in db.ConsultationTypes on typeconsultation.ConsultationTypeID equals t2.ConsultationTypeID into r2
                        from consultationtype in r2.DefaultIfEmpty()
                        join t3 in db.TargetGroups on typeconsultation.TargetGroupID equals t3.TargetGroupID into r3
                        from targetgroup in r3.DefaultIfEmpty()
                        join t4 in db.ProcessStatuss on typeconsultation.ProcessStatusID equals t4.ProcessStatusID into r4
                        from processstatus in r4.DefaultIfEmpty()
                        join t5 in db.ConsultationResults on typeconsultation.ConsultationResultID equals t5.ConsultationResultID into r5
                        from consultationresult in r5.DefaultIfEmpty()
                        select new
                        {
                            TypeConsultationTable = typeconsultation,
                            IssueTable = issue,
                            IssueTypeTable = issueType,
                            IssueCategoryTable = issueCategory,
                            ConsultationTypeTable = consultationtype,
                            TargetGroupTable = targetgroup,
                            ProcessStatusTable = processstatus,
                            ConsultationResultTable = consultationresult
                        };



            result = query.Select(list => new CompanyTypeConsultationSet
            {
                TypeConsultationID = list.TypeConsultationTable.TypeConsultationID,
                CompanyID = list.IssueTable.CompanyID,
                TypeConsultationDate = list.TypeConsultationTable.TypeConsultationDate,
                IssueName = list.IssueTable.IssueName,
                IssueDescription = list.IssueTable.IssueDescription,
                IssueDate = list.IssueTable.IssueDate,
                IssueTypeID = list.IssueTable.IssueTypeID,
                IssueTypeName = list.IssueTypeTable.IssueTypeName,
                IssueCategoryID = list.IssueTable.IssueCategoryID,
                IssueCategoryName = list.IssueCategoryTable.IssueCategoryName,
                ConsultationTypeID = list.TypeConsultationTable.ConsultationTypeID,
                ConsultationTypeName = list.ConsultationTypeTable.ConsultationTypeName,
                ProcessStatusID = list.TypeConsultationTable.ProcessStatusID,
                ProcessStatusName = list.ProcessStatusTable.ProcessStatusName,
                ConsultationResultID = list.TypeConsultationTable.ConsultationResultID,
                ConsultationResultName = list.ConsultationResultTable.ConsultationResultName,
                TargetGroupID = list.TypeConsultationTable.TargetGroupID,
                TargetGroupName = list.TargetGroupTable.TargetGroupName,
                TypeConsultationName = list.TypeConsultationTable.TypeConsultationName
            }).ToList();

            return result;
        }


        public IList<CompanySetItem> SearchCompanySetItems(CompanySearch companySearch)
        {
            try
            {

                var companyQuery = from company in db.Companys
                                    select new
                                    {
                                        CompanyTable = company
                                    };


                if (companySearch.CompanyName != "")
                {
                    companyQuery = from p in companyQuery where p.CompanyTable.CompanyName.StartsWith(companySearch.CompanyName) select p;
                }

                IList<CompanySetItem> result = companyQuery.Select
                    (item => new CompanySetItem
                    {
                        CompanyID = item.CompanyTable.CompanyID,
                        CompanyName = item.CompanyTable.CompanyName
                    }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public CompanyItem GetCompanyItem(int? companyID = null)
        {
            try
            {
                if (companyID != null)
                {
                    Company company = db.Companys.Find(companyID);
                    CompanyItem item = new CompanyItem
                    {
                        CompanyID = company.CompanyID,
                        CompanyName = company.CompanyName,
                       
                        InitializationType = InitializationTypes.Update,
                    };
                    return item;
                }
                else
                {
                    var item = new CompanyItem
                    {
                        InitializationType = InitializationTypes.Insert,
                    };
                    return item;
                }

            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public CompanyItem SaveCompany(CompanyItem companyItem)
        {
            try
            {
                Company company = null;
                switch (companyItem.InitializationType)
                {
                    case InitializationTypes.Insert:
                        company = new Company
                        {
                            CompanyName = companyItem.CompanyName
                        };
                        db.Companys.Add(company);
                        break;
                    case InitializationTypes.Update:
                        company = new Company
                        {
                            CompanyID = companyItem.CompanyID,
                            CompanyName = companyItem.CompanyName
                           
                        };
                        db.Companys.Attach(company);
                        db.Entry(company).State = EntityState.Modified;
                        break;
                }
                db.SaveChanges();
                companyItem.CompanyID = company.CompanyID;
                return companyItem;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public void CreateCompany(CompanyItem companyItem)
        {
            var entity = new Company
            {
                CompanyName = companyItem.CompanyName
            };
            db.Companys.Add(entity);
            db.SaveChanges();
            companyItem.CompanyID = entity.CompanyID;
        }

        public void UpdateCompany(CompanyItem companyItem)
        {
            var entity = new Company
            {
                CompanyID = companyItem.CompanyID,
                CompanyName = companyItem.CompanyName
            };
            db.Companys.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCompany(CompanyItem companyItem)
        {
            var entity = new Company
            {
                CompanyID = companyItem.CompanyID
            };
            db.Companys.Attach(entity);
            db.Companys.Remove(entity);
            db.SaveChanges();
        }

        //public bool? DeleteCompany(int companyID)
        //{
        //    try
        //    {
        //        var company = db.Companys.Find(companyID);
        //        if (company != null)
        //        {
        //            db.Companys.Remove(company);
        //            db.SaveChanges();
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        exception = ex;
        //        return null;
        //    }
        //}

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
