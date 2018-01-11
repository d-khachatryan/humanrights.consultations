using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationRecipientService
    {
        private StoreContext db;
        private Exception exception;

        public TypeConsultationRecipientService(StoreContext context)
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
        public IList<TypeConsultationRecipientItem> SelectCosultants(string prmGUID)
        {
            IList<TypeConsultationRecipientItem> result = new List<TypeConsultationRecipientItem>();
            result = db.TmpTypeConsultationRecipients.Join
                (db.Organizations, c => c.OrganizationID, cm => cm.OrganizationID,
                    (c, cm) => new { TmpTypeConsultationRecipient = c, Organization = cm }
                )
                .Where(c => c.TmpTypeConsultationRecipient.GUID == new Guid(prmGUID))
                .Select(list => new TypeConsultationRecipientItem
                {
                    ID = list.TmpTypeConsultationRecipient.ID,
                    GUID = new Guid(prmGUID),
                    TypeConsultationRecipientID = list.TmpTypeConsultationRecipient.TypeConsultationRecipientID,
                    TypeConsultationID = list.TmpTypeConsultationRecipient.TypeConsultationID,
                    OrganizationID = list.TmpTypeConsultationRecipient.OrganizationID,
                    OrganizationName = list.Organization.OrganizationName,
                    RecipientDate = list.TmpTypeConsultationRecipient.RecipientDate,
                }).ToList();
            return result;
        }

        public TypeConsultationRecipientItem InsertRecipient(TypeConsultationRecipientItem item)
        {
            try
            {
                TmpTypeConsultationRecipient entity = new TmpTypeConsultationRecipient
                {
                    TypeConsultationRecipientID = 0,
                    TypeConsultationID = item.TypeConsultationID,
                    OrganizationID = item.OrganizationID,
                    RecipientDate = item.RecipientDate,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationRecipients.Add(entity);

                db.SaveChanges();

                item.ID = entity.ID;
                item.TypeConsultationRecipientID = entity.TypeConsultationRecipientID;
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

        public TypeConsultationRecipientItem UpdateRecipient(TypeConsultationRecipientItem item)
        {
            try
            {
                TmpTypeConsultationRecipient entity = new TmpTypeConsultationRecipient
                {
                    ID = item.ID,
                    TypeConsultationRecipientID = item.TypeConsultationRecipientID,
                    TypeConsultationID = item.TypeConsultationID,
                    OrganizationID = item.OrganizationID,
                    RecipientDate = item.RecipientDate,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationRecipients.Attach(entity);
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

        public TypeConsultationRecipientItem DeleteRecipient(TypeConsultationRecipientItem item)
        {
            try
            {
                TmpTypeConsultationRecipient entity = new TmpTypeConsultationRecipient
                {
                    ID = item.ID,
                    TypeConsultationRecipientID = item.TypeConsultationRecipientID,
                    TypeConsultationID = item.TypeConsultationID,
                    OrganizationID = item.OrganizationID,
                    RecipientDate = item.RecipientDate,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationRecipients.Attach(entity);
                db.TmpTypeConsultationRecipients.Remove(entity);

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
