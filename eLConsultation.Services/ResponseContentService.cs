using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eLConsultation.Data
{
    public class ResponseContentService : ServiceBase
    {
        public ResponseContentService()
            : base()
        {
        }
        public IList<ResponseContentItem> GetResponseContents()
        {
            IList<ResponseContentItem> result = new List<ResponseContentItem>();

            result = db.ResponseContents.Select(product => new ResponseContentItem
            {
                ResponseContentID = product.ResponseContentID,
                ResponseContentName = product.ResponseContentName
            }).ToList();
            return result;
        }

        public void CreateResponseContent(ResponseContentItem ResponseContentItem)
        {
            var entity = new ResponseContent
            {
                ResponseContentName = ResponseContentItem.ResponseContentName
            };
            db.ResponseContents.Add(entity);
            db.SaveChanges();
            ResponseContentItem.ResponseContentID = entity.ResponseContentID;
        }

        public void UpdateResponseContent(ResponseContentItem ResponseContentItem)
        {
            var entity = new ResponseContent
            {
                ResponseContentID = ResponseContentItem.ResponseContentID,
                ResponseContentName = ResponseContentItem.ResponseContentName
            };
            db.ResponseContents.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteResponseContent(ResponseContentItem ResponseContentItem)
        {
            var entity = new ResponseContent
            {
                ResponseContentID = ResponseContentItem.ResponseContentID
            };
            db.ResponseContents.Attach(entity);
            db.ResponseContents.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
