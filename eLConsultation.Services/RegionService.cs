using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class RegionService : ServiceBase
    {
        public RegionService()
            : base()
        {

        }
        public IList<RegionItem> GetRegions()
        {
            IList<RegionItem> result = new List<RegionItem>();

            result = db.Regions.Select(product => new RegionItem
            {
                RegionID = product.RegionID,
                RegionName = product.RegionName
            }).ToList();
            return result;
        }

        public void CreateRegion(RegionItem regionItem)
        {
            var entity = new Region
            {
                RegionName = regionItem.RegionName
            };
            db.Regions.Add(entity);
            db.SaveChanges();
            regionItem.RegionID = entity.RegionID;
        }

        public void UpdateRegion(RegionItem regionItem)
        {
            var entity = new Region
            {
                RegionID = regionItem.RegionID,
                RegionName = regionItem.RegionName
            };
            db.Regions.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteRegion(RegionItem regionItem)
        {
            var entity = new Region
            {
                RegionID = regionItem.RegionID
            };
            db.Regions.Attach(entity);
            db.Regions.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
