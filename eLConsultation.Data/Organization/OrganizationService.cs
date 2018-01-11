using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class OrganizationService : ServiceBase
    {
        private Exception exception;
        public OrganizationService(HttpContextBase httpContext)
            : base()
        {

        }
        public IList<OrganizationItem> GetOrganizations()
        {
            IList<OrganizationItem> result = new List<OrganizationItem>();

            result = db.Organizations.Select(product => new OrganizationItem
            {
                OrganizationID = product.OrganizationID,
                OrganizationName = product.OrganizationName
            }).ToList();
            return result;
        }

        public void CreateOrganization(OrganizationItem organizationItem)
        {
            var entity = new Organization
            {
                OrganizationName = organizationItem.OrganizationName
            };
            db.Organizations.Add(entity);
            db.SaveChanges();
            organizationItem.OrganizationID = entity.OrganizationID;
        }

        public void UpdateOrganization(OrganizationItem organizationItem)
        {
            var entity = new Organization
            {
                OrganizationID = organizationItem.OrganizationID,
                OrganizationName = organizationItem.OrganizationName
            };
            db.Organizations.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteOrganization(OrganizationItem organizationItem)
        {
            var entity = new Organization
            {
                OrganizationID = organizationItem.OrganizationID
            };
            db.Organizations.Attach(entity);
            db.Organizations.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
