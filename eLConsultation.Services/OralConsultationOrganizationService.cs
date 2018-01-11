using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationOrganizationService
    {
        private StoreContext db;
        private Exception exception;

        public OralConsultationOrganizationService(StoreContext context)
        {
            db = context;
        }

        public IList<Organization> OrganizationList()
        {
            using (var db = new StoreContext())
            {
                IList<Organization> list = db.Organizations.ToList();
                return list;
            }
        }

        public IList<OralConsultationOrganizationItem> SelectOrganizations(string prmGUID)
        {
            IList<OralConsultationOrganizationItem> result = new List<OralConsultationOrganizationItem>();
            result = db.TmpOralConsultationOrganizations.Join
                (db.Organizations, c => c.OrganizationID, cm => cm.OrganizationID,
                    (c, cm) => new { TmpOralConsultationOrganization = c, Organization = cm }
                )
                .Where(c => c.TmpOralConsultationOrganization.GUID == new Guid(prmGUID))
                .Select(list => new OralConsultationOrganizationItem
                {
                    ID = list.TmpOralConsultationOrganization.ID,
                    GUID = new Guid(prmGUID),
                    OralConsultationOrganizationID = list.TmpOralConsultationOrganization.OralConsultationOrganizationID,
                    OralConsultationID = list.TmpOralConsultationOrganization.OralConsultationID,
                    OrganizationID = list.TmpOralConsultationOrganization.OrganizationID,
                    OrganizationName = list.Organization.OrganizationName 
                }).ToList();
            return result;
        }

        public OralConsultationOrganizationItem InsertOrganization(OralConsultationOrganizationItem item)
        {
            try
            {
                TmpOralConsultationOrganization entity = new TmpOralConsultationOrganization
                {
                    OralConsultationOrganizationID = 0,
                    OralConsultationID = item.OralConsultationID,
                    OrganizationID = item.OrganizationID,
                    GUID = item.GUID
                };

                db.TmpOralConsultationOrganizations.Add(entity);

                db.SaveChanges();

                item.ID = entity.ID;
                item.OralConsultationOrganizationID = entity.OralConsultationOrganizationID;
                Organization organization = db.Organizations.Find(item.OrganizationID);
                item.OrganizationName = organization.OrganizationName; 

                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public OralConsultationOrganizationItem UpdateOrganization(OralConsultationOrganizationItem item)
        {
            try
            {
                TmpOralConsultationOrganization entity = new TmpOralConsultationOrganization
                {
                    ID = item.ID,
                    OralConsultationOrganizationID = item.OralConsultationOrganizationID,
                    OralConsultationID = item.OralConsultationID,
                    OrganizationID = item.OrganizationID,
                    GUID = item.GUID
                };

                db.TmpOralConsultationOrganizations.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;

                db.SaveChanges();

                Organization organization = db.Organizations.Find(item.OrganizationID);
                item.OrganizationName = organization.OrganizationName; 
                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public OralConsultationOrganizationItem DeleteOrganization(OralConsultationOrganizationItem item)
        {
            try
            {
                TmpOralConsultationOrganization entity = new TmpOralConsultationOrganization
                {
                    ID = item.ID,
                    OralConsultationOrganizationID = item.OralConsultationOrganizationID,
                    OralConsultationID = item.OralConsultationID,
                    OrganizationID = item.OrganizationID,
                    GUID = item.GUID
                };

                db.TmpOralConsultationOrganizations.Attach(entity);
                db.TmpOralConsultationOrganizations.Remove(entity);

                db.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }
    }
}

