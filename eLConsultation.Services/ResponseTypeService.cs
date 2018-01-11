using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eLConsultation.Data
{
    public class ResponseTypeService : ServiceBase
    {
        public ResponseTypeService()
            : base()
        {
        }
        public IList<ResponseTypeItem> GetResponseTypes()
        {
            IList<ResponseTypeItem> result = new List<ResponseTypeItem>();

            result = db.ResponseTypes.Select(product => new ResponseTypeItem
            {
                ResponseTypeID = product.ResponseTypeID,
                ResponseTypeName = product.ResponseTypeName
            }).ToList();
            return result;
        }

        public void CreateResponseType(ResponseTypeItem ResponseTypeItem)
        {
            var entity = new ResponseType
            {
                ResponseTypeName = ResponseTypeItem.ResponseTypeName
            };
            db.ResponseTypes.Add(entity);
            db.SaveChanges();
            ResponseTypeItem.ResponseTypeID = entity.ResponseTypeID;
        }

        public void UpdateResponseType(ResponseTypeItem ResponseTypeItem)
        {
            var entity = new ResponseType
            {
                ResponseTypeID = ResponseTypeItem.ResponseTypeID,
                ResponseTypeName = ResponseTypeItem.ResponseTypeName
            };
            db.ResponseTypes.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteResponseType(ResponseTypeItem ResponseTypeItem)
        {
            var entity = new ResponseType
            {
                ResponseTypeID = ResponseTypeItem.ResponseTypeID
            };
            db.ResponseTypes.Attach(entity);
            db.ResponseTypes.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
