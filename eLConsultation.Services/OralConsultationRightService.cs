using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationRightService
    {
        private StoreContext db;
        private Exception exception;

        public OralConsultationRightService(StoreContext context)
        {
            db = context;
        }

        public IList<HumanRight> HumanRightList()
        {
            using (var db = new StoreContext())
            {
                IList<HumanRight> list = db.HumanRights.ToList();
                return list;
            }
        }
        public IList<OralConsultationRightItem> SelectRights(string prmGUID)
        {
            IList<OralConsultationRightItem> result = new List<OralConsultationRightItem>();
            result = db.TmpOralConsultationRights.Join
                (db.HumanRights, c => c.HumanRightID, cm => cm.HumanRightID,
                    (c, cm) => new { TmpOralConsultationRight = c, HumanRight = cm }
                )
                .Where(c => c.TmpOralConsultationRight.GUID == new Guid(prmGUID))
                .Select(list => new OralConsultationRightItem
                {
                    ID = list.TmpOralConsultationRight.ID,
                    GUID = new Guid(prmGUID),
                    OralConsultationRightID = list.TmpOralConsultationRight.OralConsultationRightID,
                    OralConsultationID = list.TmpOralConsultationRight.OralConsultationID,
                    HumanRightID = list.TmpOralConsultationRight.HumanRightID,
                    HumanRightName = list.HumanRight.HumanRightName
                }).ToList();
            return result;
        }

        public OralConsultationRightItem InsertRight(OralConsultationRightItem item)
        {
            try
            {
                TmpOralConsultationRight entity = new TmpOralConsultationRight
                {
                    OralConsultationRightID = 0,
                    OralConsultationID = item.OralConsultationID,
                    HumanRightID = item.HumanRightID,
                    GUID = item.GUID
                };

                db.TmpOralConsultationRights.Add(entity);

                db.SaveChanges();

                item.ID = entity.ID;
                item.OralConsultationRightID = entity.OralConsultationRightID;
                HumanRight humanRight = db.HumanRights.Find(item.HumanRightID);
                item.HumanRightName = humanRight.HumanRightName;

                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public OralConsultationRightItem UpdateRight(OralConsultationRightItem item)
        {
            try
            {
                TmpOralConsultationRight entity = new TmpOralConsultationRight
                {
                    ID = item.ID,
                    OralConsultationRightID = item.OralConsultationRightID,
                    OralConsultationID = item.OralConsultationID,
                    HumanRightID = item.HumanRightID,
                    GUID = item.GUID
                };

                db.TmpOralConsultationRights.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;

                db.SaveChanges();

                HumanRight humanRight = db.HumanRights.Find(item.HumanRightID);
                item.HumanRightName = humanRight.HumanRightName;
                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public OralConsultationRightItem DeleteRight(OralConsultationRightItem item)
        {
            try
            {
                TmpOralConsultationRight entity = new TmpOralConsultationRight
                {
                    ID = item.ID,
                    OralConsultationRightID = item.OralConsultationRightID,
                    OralConsultationID = item.OralConsultationID,
                    HumanRightID = item.HumanRightID,
                    GUID = item.GUID
                };

                db.TmpOralConsultationRights.Attach(entity);
                db.TmpOralConsultationRights.Remove(entity);

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
