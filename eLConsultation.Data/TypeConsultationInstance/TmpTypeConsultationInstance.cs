﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TmpTypeConsultationInstance
    {
        public int ID { get; set; }

        public int TypeConsultationInstanceID { get; set; }

        public int? TypeConsultationID { get; set; }

        public int? OrganizationID { get; set; }

        public Guid? GUID { get; set; }
    }
}
