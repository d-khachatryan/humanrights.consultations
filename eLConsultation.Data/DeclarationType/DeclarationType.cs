using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    public class DeclarationType
    {
        public int DeclarationTypeID { get; set; }

        public string DeclarationTypeName { get; set; }
    }
}
