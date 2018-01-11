using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eLConsultation.Data
{
    public class IssueCategoryService : ServiceBase
    {
        public IssueCategoryService()
            : base()
        {
        }
        public IList<IssueCategoryItem> GetIssueCategorys()
        {
            IList<IssueCategoryItem> result = new List<IssueCategoryItem>();

            result = db.IssueCategorys.Select(product => new IssueCategoryItem
            {
                IssueCategoryID = product.IssueCategoryID,
                IssueCategoryName = product.IssueCategoryName
            }).ToList();
            return result;
        }

        public void CreateIssueCategory(IssueCategoryItem issueCategoryItem)
        {
            var entity = new IssueCategory
            {
                IssueCategoryName = issueCategoryItem.IssueCategoryName
            };
            db.IssueCategorys.Add(entity);
            db.SaveChanges();
            issueCategoryItem.IssueCategoryID = entity.IssueCategoryID;
        }

        public void UpdateIssueCategory(IssueCategoryItem issueCategoryItem)
        {
            var entity = new IssueCategory
            {
                IssueCategoryID = issueCategoryItem.IssueCategoryID,
                IssueCategoryName = issueCategoryItem.IssueCategoryName
            };
            db.IssueCategorys.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteIssueCategory(IssueCategoryItem issueCategoryItem)
        {
            var entity = new IssueCategory
            {
                IssueCategoryID = issueCategoryItem.IssueCategoryID
            };
            db.IssueCategorys.Attach(entity);
            db.IssueCategorys.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
