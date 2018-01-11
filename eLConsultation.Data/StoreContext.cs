using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace eLConsultation.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext() 
            : base("DefaultConnection")
        {
            //this.Database.Connection.ConnectionString = connectionString;
            //this.Database.Connection.ConnectionString = @"Data Source=.\SQL2014;Initial Catalog=eConsultationDB;Integrated Security=True";
        }

        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<Company> Companys { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<OralConsultation> OralConsultations { get; set; }
        public virtual DbSet<OralConsultationConsultant> OralConsultationConsultants { get; set; }
        public virtual DbSet<TmpOralConsultationConsultant> TmpOralConsultationConsultants { get; set; }
        public virtual DbSet<OralConsultationOrganization> OralConsultationOrganizations { get; set; }
        public virtual DbSet<TmpOralConsultationOrganization> TmpOralConsultationOrganizations { get; set; }
        public virtual DbSet<OralConsultationRight> OralConsultationRights { get; set; }
        public virtual DbSet<TmpOralConsultationRight> TmpOralConsultationRights { get; set; }
        public virtual DbSet<OralConsultationPermission> OralConsultationPermissions { get; set; }
        public virtual DbSet<TmpOralConsultationPermission> TmpOralConsultationPermissions { get; set; }
        public virtual DbSet<TypeConsultation> TypeConsultations { get; set; }
        public virtual DbSet<TypeConsultationConsultant> TypeConsultationConsultants { get; set; }
        public virtual DbSet<TmpTypeConsultationConsultant> TmpTypeConsultationConsultants { get; set; }
        public virtual DbSet<TypeConsultationDeclarationType> TypeConsultationDeclarationTypes { get; set; }
        public virtual DbSet<TmpTypeConsultationDeclarationType> TmpTypeConsultationDeclarationTypes { get; set; }
        public virtual DbSet<TypeConsultationInstance> TypeConsultationInstances { get; set; }
        public virtual DbSet<TmpTypeConsultationInstance> TmpTypeConsultationInstances { get; set; }
        public virtual DbSet<TypeConsultationRecipient> TypeConsultationRecipients { get; set; }
        public virtual DbSet<TmpTypeConsultationRecipient> TmpTypeConsultationRecipients { get; set; }
        public virtual DbSet<TypeConsultationRight> TypeConsultationRights { get; set; }
        public virtual DbSet<TmpTypeConsultationRight> TmpTypeConsultationRights { get; set; }
        public virtual DbSet<TypeConsultationPermission> TypeConsultationPermissions { get; set; }
        public virtual DbSet<TmpTypeConsultationPermission> TmpTypeConsultationPermissions { get; set; }

        public DbSet<ResponseType> ResponseTypes { get; set; }
        public DbSet<ResponseQuality> ResponseQualities { get; set; }
        public DbSet<ResponseContent> ResponseContents { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<IssueCategory> IssueCategorys { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<AspNetUsers> AspNetUsers { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<ConsultationResult> ConsultationResults { get; set; }
        public DbSet<ConsultationType> ConsultationTypes { get; set; }
        public DbSet<DeclarationType> DeclarationTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<HumanRight> HumanRights { get; set; }
        public DbSet<InvocationType> InvocationTypes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ProcessStatus> ProcessStatuss { get; set; }
        public DbSet<TargetGroup> TargetGroups { get; set; }

        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<StoreContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ResidentConfiguration());
            modelBuilder.Configurations.Add(new OralConsultationConfiguration());
            modelBuilder.Configurations.Add(new OralConsultationConsultantConfiguration());
            modelBuilder.Configurations.Add(new TmpOralConsultationConsultantConfiguration());


            modelBuilder.Configurations.Add(new ResponseTypeConfiguration());
            modelBuilder.Configurations.Add(new ResponseQualityConfiguration());
            modelBuilder.Configurations.Add(new ResponseContentConfiguration());

            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new CommunityConfiguration());
            modelBuilder.Configurations.Add(new AgeGroupConfiguration());
            modelBuilder.Configurations.Add(new ConsultantConfiguration());
            modelBuilder.Configurations.Add(new ConsultationResultConfiguration());
            modelBuilder.Configurations.Add(new ConsultationTypeConfiguration());
            modelBuilder.Configurations.Add(new DeclarationTypeConfiguration());
            modelBuilder.Configurations.Add(new GenderConfiguration());
            modelBuilder.Configurations.Add(new HumanRightConfiguration());
            modelBuilder.Configurations.Add(new InvocationTypeConfiguration());
            modelBuilder.Configurations.Add(new OrganizationConfiguration());
            modelBuilder.Configurations.Add(new ProcessStatusConfiguration());
            modelBuilder.Configurations.Add(new TargetGroupConfiguration());

            modelBuilder.Configurations.Add(new SettingConfiguration());
        }
    }
}
