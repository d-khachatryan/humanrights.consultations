using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class ServiceBase
    {
        protected StoreContext db;

        protected Exception exception;

        public Exception ServiceException
        {
            get
            {
                return exception;
            }

        }
        public ServiceBase()
        {
            db = new StoreContext();
        }
    }
}
