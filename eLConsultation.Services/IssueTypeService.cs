using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eLConsultation.Data
{
    public class IssueTypeService : ServiceBase
    {
        public IssueTypeService()
            : base()
        {
        }
        public IList<IssueTypeItem> GetIssueTypes()
        {
            IList<IssueTypeItem> result = new List<IssueTypeItem>();

            result = db.IssueTypes.Select(product => new IssueTypeItem
            {
                IssueTypeID = product.IssueTypeID,
                IssueTypeName = product.IssueTypeName
            }).ToList();
            return result;
        }

        public void CreateIssueType(IssueTypeItem issueTypeItem)
        {
            var entity = new IssueType
            {
                IssueTypeName = issueTypeItem.IssueTypeName
            };
            db.IssueTypes.Add(entity);
            db.SaveChanges();
            issueTypeItem.IssueTypeID = entity.IssueTypeID;
        }

        public void UpdateIssueType(IssueTypeItem issueTypeItem)
        {
            var entity = new IssueType
            {
                IssueTypeID = issueTypeItem.IssueTypeID,
                IssueTypeName = issueTypeItem.IssueTypeName
            };
            db.IssueTypes.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteIssueType(IssueTypeItem issueTypeItem)
        {
            var entity = new IssueType
            {
                IssueTypeID = issueTypeItem.IssueTypeID
            };
            db.IssueTypes.Attach(entity);
            db.IssueTypes.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
