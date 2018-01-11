using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    public class ProcessStatus
    {
        public int ProcessStatusID { get; set; }

        public string ProcessStatusName { get; set; }
    }
}
