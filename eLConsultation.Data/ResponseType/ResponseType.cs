using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class ResponseType
    {
        public int ResponseTypeID { get; set; }

        [Required]
        public string ResponseTypeName { get; set; }
    }
}
