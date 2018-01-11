using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class ConsultationTypeService : ServiceBase
    {
        private Exception exception;
        public ConsultationTypeService(HttpContextBase httpContext)
            : base()
        {

        }
        public IList<ConsultationTypeItem> GetConsultationTypes()
        {
            IList<ConsultationTypeItem> result = new List<ConsultationTypeItem>();

            result = db.ConsultationTypes.Select(product => new ConsultationTypeItem
            {
                ConsultationTypeID = product.ConsultationTypeID,
                ConsultationTypeName = product.ConsultationTypeName
            }).ToList();
            return result;
        }

        public void CreateConsultationType(ConsultationTypeItem consultationTypeItem)
        {
            var entity = new ConsultationType
            {
                ConsultationTypeName = consultationTypeItem.ConsultationTypeName
            };
            db.ConsultationTypes.Add(entity);
            db.SaveChanges();
            consultationTypeItem.ConsultationTypeID = entity.ConsultationTypeID;
        }

        public void UpdateConsultationType(ConsultationTypeItem consultationTypeItem)
        {
            var entity = new ConsultationType
            {
                ConsultationTypeID = consultationTypeItem.ConsultationTypeID,
                ConsultationTypeName = consultationTypeItem.ConsultationTypeName
            };
            db.ConsultationTypes.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteConsultationType(ConsultationTypeItem consultationTypeItem)
        {
            var entity = new ConsultationType
            {
                ConsultationTypeID = consultationTypeItem.ConsultationTypeID
            };
            db.ConsultationTypes.Attach(entity);
            db.ConsultationTypes.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
