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
