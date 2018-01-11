using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eLConsultation.Data
{
    public class ResponseQualityService : ServiceBase
    {
        public ResponseQualityService()
            : base()
        {
        }
        public IList<ResponseQualityItem> GetResponseQualities()
        {
            IList<ResponseQualityItem> result = new List<ResponseQualityItem>();

            result = db.ResponseQualities.Select(product => new ResponseQualityItem
            {
                ResponseQualityID = product.ResponseQualityID,
                ResponseQualityName = product.ResponseQualityName
            }).ToList();
            return result;
        }

        public void CreateResponseQuality(ResponseQualityItem ResponseQualityItem)
        {
            var entity = new ResponseQuality
            {
                ResponseQualityName = ResponseQualityItem.ResponseQualityName
            };
            db.ResponseQualities.Add(entity);
            db.SaveChanges();
            ResponseQualityItem.ResponseQualityID = entity.ResponseQualityID;
        }

        public void UpdateResponseQuality(ResponseQualityItem ResponseQualityItem)
        {
            var entity = new ResponseQuality
            {
                ResponseQualityID = ResponseQualityItem.ResponseQualityID,
                ResponseQualityName = ResponseQualityItem.ResponseQualityName
            };
            db.ResponseQualities.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteResponseQuality(ResponseQualityItem ResponseQualityItem)
        {
            var entity = new ResponseQuality
            {
                ResponseQualityID = ResponseQualityItem.ResponseQualityID
            };
            db.ResponseQualities.Attach(entity);
            db.ResponseQualities.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
