using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class AgeGroupService : ServiceBase
    {
        //private Exception exception;
        public AgeGroupService(HttpContextBase httpContext)
            : base()
        {

        }
        public IList<AgeGroupItem> GetAgeGroups()
        {
            IList<AgeGroupItem> result = new List<AgeGroupItem>();

            result = db.AgeGroups.Select(product => new AgeGroupItem
            {
                AgeGroupID = product.AgeGroupID,
                AgeGroupName = product.AgeGroupName
            }).ToList();
            return result;
        }

        public void CreateAgeGroup(AgeGroupItem ageGroupItem)
        {
            var entity = new AgeGroup
            {
                AgeGroupName = ageGroupItem.AgeGroupName
            };
            db.AgeGroups.Add(entity);
            db.SaveChanges();
            ageGroupItem.AgeGroupID = entity.AgeGroupID;
        }

        public void UpdateAgeGroup(AgeGroupItem ageGroupItem)
        {
            var entity = new AgeGroup
            {
                AgeGroupID = ageGroupItem.AgeGroupID,
                AgeGroupName = ageGroupItem.AgeGroupName
            };
            db.AgeGroups.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteAgeGroup(AgeGroupItem ageGroupItem)
        {
            var entity = new AgeGroup
            {
                AgeGroupID = ageGroupItem.AgeGroupID
            };
            db.AgeGroups.Attach(entity);
            db.AgeGroups.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
