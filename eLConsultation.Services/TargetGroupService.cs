using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class TargetGroupService : ServiceBase
    {
        public TargetGroupService()
            : base()
        {

        }
        public IList<TargetGroupItem> GetTargetGroups()
        {
            IList<TargetGroupItem> result = new List<TargetGroupItem>();

            result = db.TargetGroups.Select(product => new TargetGroupItem
            {
                TargetGroupID = product.TargetGroupID,
                TargetGroupName = product.TargetGroupName
            }).ToList();
            return result;
        }

        public void CreateTargetGroup(TargetGroupItem targetGroupItem)
        {
            var entity = new TargetGroup
            {
                TargetGroupName = targetGroupItem.TargetGroupName
            };
            db.TargetGroups.Add(entity);
            db.SaveChanges();
            targetGroupItem.TargetGroupID = entity.TargetGroupID;
        }

        public void UpdateTargetGroup(TargetGroupItem targetGroupItem)
        {
            var entity = new TargetGroup
            {
                TargetGroupID = targetGroupItem.TargetGroupID,
                TargetGroupName = targetGroupItem.TargetGroupName
            };
            db.TargetGroups.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteTargetGroup(TargetGroupItem targetGroupItem)
        {
            var entity = new TargetGroup
            {
                TargetGroupID = targetGroupItem.TargetGroupID
            };
            db.TargetGroups.Attach(entity);
            db.TargetGroups.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
