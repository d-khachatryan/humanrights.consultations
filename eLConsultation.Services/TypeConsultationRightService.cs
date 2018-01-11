using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationRightService
    {
        private StoreContext db;
        private Exception exception;

        public TypeConsultationRightService(StoreContext context)
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
        public IList<TypeConsultationRightItem> SelectCosultants(string prmGUID)
        {
            IList<TypeConsultationRightItem> result = new List<TypeConsultationRightItem>();
            result = db.TmpTypeConsultationRights.Join
                (db.HumanRights, c => c.HumanRightID, cm => cm.HumanRightID,
                    (c, cm) => new { TmpTypeConsultationRight = c, HumanRight = cm }
                )
                .Where(c => c.TmpTypeConsultationRight.GUID == new Guid(prmGUID))
                .Select(list => new TypeConsultationRightItem
                {
                    ID = list.TmpTypeConsultationRight.ID,
                    GUID = new Guid(prmGUID),
                    TypeConsultationRightID = list.TmpTypeConsultationRight.TypeConsultationRightID,
                    TypeConsultationID = list.TmpTypeConsultationRight.TypeConsultationID,
                    HumanRightID = list.TmpTypeConsultationRight.HumanRightID,
                    HumanRightName = list.HumanRight.HumanRightName
                }).ToList();
            return result;
        }

        public TypeConsultationRightItem InsertRight(TypeConsultationRightItem item)
        {
            try
            {
                TmpTypeConsultationRight entity = new TmpTypeConsultationRight
                {
                    TypeConsultationRightID = 0,
                    TypeConsultationID = item.TypeConsultationID,
                    HumanRightID = item.HumanRightID,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationRights.Add(entity);

                db.SaveChanges();

                item.ID = entity.ID;
                item.TypeConsultationRightID = entity.TypeConsultationRightID;
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

        public TypeConsultationRightItem UpdateRight(TypeConsultationRightItem item)
        {
            try
            {
                TmpTypeConsultationRight entity = new TmpTypeConsultationRight
                {
                    ID = item.ID,
                    TypeConsultationRightID = item.TypeConsultationRightID,
                    TypeConsultationID = item.TypeConsultationID,
                    HumanRightID = item.HumanRightID,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationRights.Attach(entity);
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

        public TypeConsultationRightItem DeleteRight(TypeConsultationRightItem item)
        {
            try
            {
                TmpTypeConsultationRight entity = new TmpTypeConsultationRight
                {
                    ID = item.ID,
                    TypeConsultationRightID = item.TypeConsultationRightID,
                    TypeConsultationID = item.TypeConsultationID,
                    HumanRightID = item.HumanRightID,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationRights.Attach(entity);
                db.TmpTypeConsultationRights.Remove(entity);

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
