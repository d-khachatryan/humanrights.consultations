using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationConsultantService
    {
        private StoreContext db;
        private Exception exception;

        public OralConsultationConsultantService(StoreContext context)
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
        public IList<OralConsultationConsultantItem> SelectCosultants(string prmGUID)
        {
            IList<OralConsultationConsultantItem> result = new List<OralConsultationConsultantItem>();
            result = db.TmpOralConsultationConsultants.Join
                (db.Consultants, c => c.ConsultantID, cm => cm.ConsultantID,
                    (c, cm) => new { TmpOralConsultationConsultant = c, Consultant = cm }
                )
                .Where(c => c.TmpOralConsultationConsultant.GUID == new Guid(prmGUID))
                .Select(list => new OralConsultationConsultantItem
                {
                    ID = list.TmpOralConsultationConsultant.ID,
                    GUID = new Guid(prmGUID),
                    OralConsultationConsultantID = list.TmpOralConsultationConsultant.OralConsultationConsultantID,
                    OralConsultationID = list.TmpOralConsultationConsultant.OralConsultationID,
                    ConsultantID = list.TmpOralConsultationConsultant.ConsultantID,
                    ConsultantName = list.Consultant.FirstName + " " + list.Consultant.LastName
                }).ToList();
            return result;
        }

        public OralConsultationConsultantItem InsertConsultant(OralConsultationConsultantItem item)
        {
            try
            {
                TmpOralConsultationConsultant entity = new TmpOralConsultationConsultant
                {
                    OralConsultationConsultantID = 0,
                    OralConsultationID = item.OralConsultationID,
                    ConsultantID = item.ConsultantID,
                    GUID = item.GUID
                };

                db.TmpOralConsultationConsultants.Add(entity);

                db.SaveChanges();

                item.ID = entity.ID;
                item.OralConsultationConsultantID = entity.OralConsultationConsultantID;
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

        public OralConsultationConsultantItem UpdateConsultant(OralConsultationConsultantItem item)
        {
            try
            {
                TmpOralConsultationConsultant entity = new TmpOralConsultationConsultant
                {
                    ID = item.ID,
                    OralConsultationConsultantID = item.OralConsultationConsultantID,
                    OralConsultationID = item.OralConsultationID,
                    ConsultantID = item.ConsultantID,
                    GUID = item.GUID
                };

                db.TmpOralConsultationConsultants.Attach(entity);
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

        public OralConsultationConsultantItem DeleteConsultant(OralConsultationConsultantItem item)
        {
            try
            {
                TmpOralConsultationConsultant entity = new TmpOralConsultationConsultant
                {
                    ID = item.ID,
                    OralConsultationConsultantID = item.OralConsultationConsultantID,
                    OralConsultationID = item.OralConsultationID,
                    ConsultantID = item.ConsultantID,
                    GUID = item.GUID
                };

                db.TmpOralConsultationConsultants.Attach(entity);
                db.TmpOralConsultationConsultants.Remove(entity);

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
