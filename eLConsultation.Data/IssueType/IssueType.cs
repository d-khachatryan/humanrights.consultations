using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class IssueType
    {
        public int IssueTypeID { get; set; }

        [Required]
        public string IssueTypeName { get; set; }

        public virtual ICollection<Issue> Issues { get; private set; }
    }
}
