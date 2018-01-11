using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class IssueCategory
    {
        public int IssueCategoryID { get; set; }

        [Required]
        public string IssueCategoryName { get; set; }

        public virtual ICollection<Issue> Issues { get; private set; }
    }
}
