using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class ProcessStatusService : ServiceBase
    {
        public ProcessStatusService()
            : base()
        {

        }
        public IList<ProcessStatusItem> GetProcessStatuss()
        {
            IList<ProcessStatusItem> result = new List<ProcessStatusItem>();

            result = db.ProcessStatuss.Select(product => new ProcessStatusItem
            {
                ProcessStatusID = product.ProcessStatusID,
                ProcessStatusName = product.ProcessStatusName
            }).ToList();
            return result;
        }

        public void CreateProcessStatus(ProcessStatusItem processStatusItem)
        {
            var entity = new ProcessStatus
            {
                ProcessStatusName = processStatusItem.ProcessStatusName
            };
            db.ProcessStatuss.Add(entity);
            db.SaveChanges();
            processStatusItem.ProcessStatusID = entity.ProcessStatusID;
        }

        public void UpdateProcessStatus(ProcessStatusItem processStatusItem)
        {
            var entity = new ProcessStatus
            {
                ProcessStatusID = processStatusItem.ProcessStatusID,
                ProcessStatusName = processStatusItem.ProcessStatusName
            };
            db.ProcessStatuss.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteProcessStatus(ProcessStatusItem processStatusItem)
        {
            var entity = new ProcessStatus
            {
                ProcessStatusID = processStatusItem.ProcessStatusID
            };
            db.ProcessStatuss.Attach(entity);
            db.ProcessStatuss.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
