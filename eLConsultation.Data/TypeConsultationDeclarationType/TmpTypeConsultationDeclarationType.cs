using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TmpTypeConsultationDeclarationType
    {
        public int ID { get; set; }

        public int TypeConsultationDeclarationTypeID { get; set; }

        public int? TypeConsultationID { get; set; }

        public int? DeclarationTypeID { get; set; }

        public string DeclarationURL { get; set; }

        public DateTime? DeclarationDeadline { get; set; }

        public DateTime? DeclarationDate { get; set; }

        public int? OrganizationID { get; set; }

        public DateTime? ResponseDate { get; set; }

        public int? ResponseTypeID { get; set; }

        public int? ResponseQualityID { get; set; }

        public Guid? GUID { get; set; }

        public string ResponseContent { get; set; }
    }
}
