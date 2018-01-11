using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class Issue
    {
        public int IssueID { get; set; }
        public int? ResidentID { get; set; }
        public string IssueName { get; set; }
        public string IssueDescription { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? IssueDate { get; set; }
        public int? IssueTypeID { get; set; }
        public IssueType IssueType { get; set; }

        public int? CompanyID { get; set; }
        public int? IssueCategoryID { get; set; }
        public IssueCategory IssueCategory { get; set; }
    }
}
