using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eLConsultation.Data
{
    public class CommunityService : ServiceBase
    {
        public CommunityService()
    : base()
        {

        }

        public IList<CommunityItem> GetCommunities()
        {
            IList<CommunityItem> result = new List<CommunityItem>();

            result = db.Communities.Select(product => new CommunityItem
            {
                CommunityID = product.CommunityID,
                RegionID = product.RegionID,
                CommunityName = product.CommunityName
            }).ToList();
            return result;
        }

        public void CreateCommunity(CommunityItem communityItem)
        {
            var entity = new Community
            {
                CommunityName = communityItem.CommunityName,
                RegionID = communityItem.RegionID
            };
            db.Communities.Add(entity);
            db.SaveChanges();
            communityItem.CommunityID = entity.CommunityID;
        }

        public void UpdateCommunity(CommunityItem communityItem)
        {
            var entity = new Community
            {
                CommunityID = communityItem.CommunityID,
                CommunityName = communityItem.CommunityName,
                RegionID = communityItem.RegionID
            };
            db.Communities.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCommunity(CommunityItem communityItem)
        {
            var entity = new Community
            {
                CommunityID = communityItem.CommunityID
            };
            db.Communities.Attach(entity);
            db.Communities.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
