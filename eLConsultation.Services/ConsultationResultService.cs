using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class ConsultationResultService : ServiceBase
    {
        public ConsultationResultService()
            : base()
        {

        }
        public IList<ConsultationResultItem> GetConsultationResults()
        {
            IList<ConsultationResultItem> result = new List<ConsultationResultItem>();

            result = db.ConsultationResults.Select(product => new ConsultationResultItem
            {
                ConsultationResultID = product.ConsultationResultID,
                ConsultationResultName = product.ConsultationResultName
            }).ToList();
            return result;
        }

        public void CreateConsultationResult(ConsultationResultItem consultationResultItem)
        {
            var entity = new ConsultationResult
            {
                ConsultationResultName = consultationResultItem.ConsultationResultName
            };
            db.ConsultationResults.Add(entity);
            db.SaveChanges();
            consultationResultItem.ConsultationResultID = entity.ConsultationResultID;
        }

        public void UpdateConsultationResult(ConsultationResultItem consultationResultItem)
        {
            var entity = new ConsultationResult
            {
                ConsultationResultID = consultationResultItem.ConsultationResultID,
                ConsultationResultName = consultationResultItem.ConsultationResultName
            };
            db.ConsultationResults.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteConsultationResult(ConsultationResultItem consultationResultItem)
        {
            var entity = new ConsultationResult
            {
                ConsultationResultID = consultationResultItem.ConsultationResultID
            };
            db.ConsultationResults.Attach(entity);
            db.ConsultationResults.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
