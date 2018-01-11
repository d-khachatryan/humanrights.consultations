using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationConsultantService
    {
        private StoreContext db;
        private Exception exception;

        public TypeConsultationConsultantService(StoreContext context)
        {
            db = context;
        }

        public IList<Consultant> ConsultantList()
        {
            using (var db = new StoreContext())
            {
                IList<Consultant> list = db.Consultants.ToList();
                return list;
            }
        }
        public IList<TypeConsultationConsultantItem> SelectCosultants(string prmGUID)
        {
            IList<TypeConsultationConsultantItem> result = new List<TypeConsultationConsultantItem>();
            result = db.TmpTypeConsultationConsultants.Join
                (db.Consultants, c => c.ConsultantID, cm => cm.ConsultantID,
                    (c, cm) => new { TmpTypeConsultationConsultant = c, Consultant = cm }
                )
                .Where(c => c.TmpTypeConsultationConsultant.GUID == new Guid(prmGUID))
                .Select(list => new TypeConsultationConsultantItem
                {
                    ID = list.TmpTypeConsultationConsultant.ID,
                    GUID = new Guid(prmGUID),
                    TypeConsultationConsultantID = list.TmpTypeConsultationConsultant.TypeConsultationConsultantID,
                    TypeConsultationID = list.TmpTypeConsultationConsultant.TypeConsultationID,
                    ConsultantID = list.TmpTypeConsultationConsultant.ConsultantID,
                    ConsultantName = list.Consultant.FirstName + " " + list.Consultant.LastName
                }).ToList();
            return result;
        }

        public TypeConsultationConsultantItem InsertConsultant(TypeConsultationConsultantItem item)
        {
            try
            {
                TmpTypeConsultationConsultant entity = new TmpTypeConsultationConsultant
                {
                    TypeConsultationConsultantID = 0,
                    TypeConsultationID = item.TypeConsultationID,
                    ConsultantID = item.ConsultantID,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationConsultants.Add(entity);

                db.SaveChanges();

                item.ID = entity.ID;
                item.TypeConsultationConsultantID = entity.TypeConsultationConsultantID;
                Consultant consultant = db.Consultants.Find(item.ConsultantID);
                item.ConsultantName = consultant.FirstName + " " + consultant.LastName;

                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public TypeConsultationConsultantItem UpdateConsultant(TypeConsultationConsultantItem item)
        {
            try
            {
                TmpTypeConsultationConsultant entity = new TmpTypeConsultationConsultant
                {
                    ID = item.ID,
                    TypeConsultationConsultantID = item.TypeConsultationConsultantID,
                    TypeConsultationID = item.TypeConsultationID,
                    ConsultantID = item.ConsultantID,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationConsultants.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;

                db.SaveChanges();

                Consultant consultant = db.Consultants.Find(item.ConsultantID);
                item.ConsultantName = consultant.FirstName + " " + consultant.LastName;
                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public TypeConsultationConsultantItem DeleteConsultant(TypeConsultationConsultantItem item)
        {
            try
            {
                TmpTypeConsultationConsultant entity = new TmpTypeConsultationConsultant
                {
                    ID = item.ID,
                    TypeConsultationConsultantID = item.TypeConsultationConsultantID,
                    TypeConsultationID = item.TypeConsultationID,
                    ConsultantID = item.ConsultantID,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationConsultants.Attach(entity);
                db.TmpTypeConsultationConsultants.Remove(entity);

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
