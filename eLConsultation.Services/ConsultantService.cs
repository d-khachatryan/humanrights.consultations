using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class ConsultantService : ServiceBase
    {
        public ConsultantService()
            : base()
        {

        }
        public IList<ConsultantItem> GetConsultants()
        {
            IList<ConsultantItem> result = new List<ConsultantItem>();

            result = db.Consultants.Select(product => new ConsultantItem
            {
                ConsultantID = product.ConsultantID,
                FirstName = product.FirstName,
                LastName = product.LastName,
                Id = product.Id
            }).ToList();
            return result;
        }

        public void CreateConsultant(ConsultantItem consultantItem)
        {
            var entity = new Consultant
            {
                FirstName = consultantItem.FirstName,
                LastName = consultantItem.LastName,
                Id = consultantItem.Id
            };
            db.Consultants.Add(entity);
            db.SaveChanges();
            consultantItem.ConsultantID = entity.ConsultantID;
        }

        public void UpdateConsultant(ConsultantItem consultantItem)
        {
            var entity = new Consultant
            {
                ConsultantID = consultantItem.ConsultantID,
                FirstName = consultantItem.FirstName,
                LastName = consultantItem.LastName,
                Id = consultantItem.Id
            };
            db.Consultants.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteConsultant(ConsultantItem consultantItem)
        {
            var entity = new Consultant
            {
                ConsultantID = consultantItem.ConsultantID
            };
            db.Consultants.Attach(entity);
            db.Consultants.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
