using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    public class ConsultationType
    {
        public int ConsultationTypeID { get; set; }

        public string ConsultationTypeName { get; set; }
    }
}
