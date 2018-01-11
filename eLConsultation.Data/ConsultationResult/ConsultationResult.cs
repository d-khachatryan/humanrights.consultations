using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    public class ConsultationResult
    {
        public int ConsultationResultID { get; set; }

        public string ConsultationResultName { get; set; }
    }
}
