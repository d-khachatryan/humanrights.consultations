using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationInstanceService
    {
        private StoreContext db;
        private Exception exception;

        public TypeConsultationInstanceService(StoreContext context)
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
        public IList<TypeConsultationInstanceItem> SelectCosultants(string prmGUID)
        {
            IList<TypeConsultationInstanceItem> result = new List<TypeConsultationInstanceItem>();
            result = db.TmpTypeConsultationInstances.Join
                (db.Organizations, c => c.OrganizationID, cm => cm.OrganizationID,
                    (c, cm) => new { TmpTypeConsultationInstance = c, Organization = cm }
                )
                .Where(c => c.TmpTypeConsultationInstance.GUID == new Guid(prmGUID))
                .Select(list => new TypeConsultationInstanceItem
                {
                    ID = list.TmpTypeConsultationInstance.ID,
                    GUID = new Guid(prmGUID),
                    TypeConsultationInstanceID = list.TmpTypeConsultationInstance.TypeConsultationInstanceID,
                    TypeConsultationID = list.TmpTypeConsultationInstance.TypeConsultationID,
                    OrganizationID = list.TmpTypeConsultationInstance.OrganizationID,
                    OrganizationName = list.Organization.OrganizationName
                }).ToList();
            return result;
        }

        public TypeConsultationInstanceItem InsertInstance(TypeConsultationInstanceItem item)
        {
            try
            {
                TmpTypeConsultationInstance entity = new TmpTypeConsultationInstance
                {
                    TypeConsultationInstanceID = 0,
                    TypeConsultationID = item.TypeConsultationID,
                    OrganizationID = item.OrganizationID,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationInstances.Add(entity);

                db.SaveChanges();

                item.ID = entity.ID;
                item.TypeConsultationInstanceID = entity.TypeConsultationInstanceID;
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

        public TypeConsultationInstanceItem UpdateInstance(TypeConsultationInstanceItem item)
        {
            try
            {
                TmpTypeConsultationInstance entity = new TmpTypeConsultationInstance
                {
                    ID = item.ID,
                    TypeConsultationInstanceID = item.TypeConsultationInstanceID,
                    TypeConsultationID = item.TypeConsultationID,
                    OrganizationID = item.OrganizationID,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationInstances.Attach(entity);
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

        public TypeConsultationInstanceItem DeleteInstance(TypeConsultationInstanceItem item)
        {
            try
            {
                TmpTypeConsultationInstance entity = new TmpTypeConsultationInstance
                {
                    ID = item.ID,
                    TypeConsultationInstanceID = item.TypeConsultationInstanceID,
                    TypeConsultationID = item.TypeConsultationID,
                    OrganizationID = item.OrganizationID,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationInstances.Attach(entity);
                db.TmpTypeConsultationInstances.Remove(entity);

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
