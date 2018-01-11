using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class InvocationTypeService : ServiceBase
    {
        private Exception exception;
        public InvocationTypeService(HttpContextBase httpContext)
            : base()
        {

        }
        public IList<InvocationTypeItem> GetInvocationTypes()
        {
            IList<InvocationTypeItem> result = new List<InvocationTypeItem>();

            result = db.InvocationTypes.Select(product => new InvocationTypeItem
            {
                InvocationTypeID = product.InvocationTypeID,
                InvocationTypeName = product.InvocationTypeName
            }).ToList();
            return result;
        }

        public void CreateInvocationType(InvocationTypeItem invocationTypeItem)
        {
            var entity = new InvocationType
            {
                InvocationTypeName = invocationTypeItem.InvocationTypeName
            };
            db.InvocationTypes.Add(entity);
            db.SaveChanges();
            invocationTypeItem.InvocationTypeID = entity.InvocationTypeID;
        }

        public void UpdateInvocationType(InvocationTypeItem invocationTypeItem)
        {
            var entity = new InvocationType
            {
                InvocationTypeID = invocationTypeItem.InvocationTypeID,
                InvocationTypeName = invocationTypeItem.InvocationTypeName
            };
            db.InvocationTypes.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteInvocationType(InvocationTypeItem invocationTypeItem)
        {
            var entity = new InvocationType
            {
                InvocationTypeID = invocationTypeItem.InvocationTypeID
            };
            db.InvocationTypes.Attach(entity);
            db.InvocationTypes.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
