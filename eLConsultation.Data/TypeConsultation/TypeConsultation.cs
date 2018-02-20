using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultation
    {
        public int TypeConsultationID { get; set; }

        public string TypeConsultationName { get; set; }

        //public int? ResidentID { get; set; }

        public int IssueID { get; set; }

        public DateTime? TypeConsultationDate { get; set; }

        public int? ConsultationTypeID { get; set; }

        public int? ProcessStatusID { get; set; }

        public int? ConsultationResultID { get; set; }

        public int? TargetGroupID { get; set; }

        public string UserID { get; set; }

        public DateTime? ChangeDate { get; set; }

        public string OwnerID { get; set; }

        public virtual ICollection<TypeConsultationConsultant> TypeConsultationConsultants { get; private set; }

        public virtual ICollection<TypeConsultationInstance> TypeConsultationInstances { get; private set; }

        public virtual ICollection<TypeConsultationDeclarationType> TypeConsultationDeclarationTypes { get; private set; }

        public virtual ICollection<TypeConsultationRecipient> TypeConsultationRecipients { get; private set; }

        public virtual ICollection<TypeConsultationRight> TypeConsultationRights { get; private set; }

        public virtual ICollection<TypeConsultationPermission> TypeConsultationPermissionss { get; private set; }

    }
}
