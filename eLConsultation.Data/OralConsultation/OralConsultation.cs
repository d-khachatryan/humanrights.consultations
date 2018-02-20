using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultation
    {
        public int OralConsultationID { get; set; }

        public int IssueID { get; set; }

        public DateTime? OralConsultationDate { get; set; }

        public int? InvocationTypeID { get; set; }

        public int? TargetGroupID { get; set; }

        public string ProblemDescription { get; set; }

        public string ConsultationDescription { get; set; }

        public string UserID { get; set; }

        public DateTime? ChangeDate { get; set; }

        public string OwnerID { get; set; }

        public virtual ICollection<OralConsultationConsultant> OralConsultationConsultants { get; private set; }

        public virtual ICollection<OralConsultationOrganization> OralConsultationOrganizations { get; private set; }

        public virtual ICollection<OralConsultationRight> OralConsultationRights { get; private set; }

        public virtual ICollection<OralConsultationPermission> OralConsultationPermissionss { get; private set; }


    }
}
