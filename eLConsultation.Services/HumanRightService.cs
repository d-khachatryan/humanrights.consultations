using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class HumanRightService : ServiceBase
    {
        public HumanRightService()
            : base()
        {

        }
        public IList<HumanRightItem> GetHumanRights()
        {
            IList<HumanRightItem> result = new List<HumanRightItem>();

            result = db.HumanRights.Select(product => new HumanRightItem
            {
                HumanRightID = product.HumanRightID,
                HumanRightName = product.HumanRightName
            }).ToList();
            return result;
        }

        public void CreateHumanRight(HumanRightItem humanRightItem)
        {
            var entity = new HumanRight
            {
                HumanRightName = humanRightItem.HumanRightName
            };
            db.HumanRights.Add(entity);
            db.SaveChanges();
            humanRightItem.HumanRightID = entity.HumanRightID;
        }

        public void UpdateHumanRight(HumanRightItem humanRightItem)
        {
            var entity = new HumanRight
            {
                HumanRightID = humanRightItem.HumanRightID,
                HumanRightName = humanRightItem.HumanRightName
            };
            db.HumanRights.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteHumanRight(HumanRightItem humanRightItem)
        {
            var entity = new HumanRight
            {
                HumanRightID = humanRightItem.HumanRightID
            };
            db.HumanRights.Attach(entity);
            db.HumanRights.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
