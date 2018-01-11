using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    public class InvocationType
    {
        public int InvocationTypeID { get; set; }

        public string InvocationTypeName { get; set; }
    }
}
