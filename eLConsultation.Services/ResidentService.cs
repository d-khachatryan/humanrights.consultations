using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class ResidentService : ServiceBase
    {
        public ResidentService()
            : base()
        {

        }

        public List<SelectListItem> GetGenderDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            GenderService gender = new GenderService();
            selectedListItem = gender.GetGenders().Select(x => new SelectListItem { Text = x.GenderName, Value = x.GenderID.ToString() }).ToList();
            return selectedListItem;
        }
        public List<SelectListItem> GetRegionDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            RegionService region = new RegionService();
            selectedListItem = region.GetRegions().Select(x => new SelectListItem { Text = x.RegionName, Value = x.RegionID.ToString() }).ToList();
            return selectedListItem;
        }
        public List<SelectListItem> GetCommunityDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            CommunityService community = new CommunityService();
            selectedListItem = community.GetCommunities().Select(x => new SelectListItem { Text = x.CommunityName, Value = x.CommunityID.ToString() }).ToList();
            return selectedListItem;
        }

        /// <summary>
        /// Selects records from dbo.Resident table with given search criteria and fills in the list of ResidentSetItem model.
        /// </summary>
        /// <returns></returns>
        public IList<ResidentSetItem> SearchResidentSetItems(ResidentSearch residentSearch)
        {
            try
            {

                var residentQuery = from resident in db.Residents
                                    join t1 in db.Genders on resident.GenderID equals t1.GenderID into r1
                                    from gender in r1.DefaultIfEmpty()
                                    join t2 in db.Regions on resident.RegionID equals t2.RegionID into r2
                                    from region in r2.DefaultIfEmpty()
                                    join t3 in db.Communities on resident.CommunityID equals t3.CommunityID into r3
                                    from community in r3.DefaultIfEmpty()
                                    select new
                                    {
                                        ResidentTable = resident,
                                        GenderTable = gender,
                                        RegionTable = region,
                                        CommunityTable = community
                                    };


                if (residentSearch.FirstName != "")
                {
                    residentQuery = from p in residentQuery where p.ResidentTable.FirstName.StartsWith(residentSearch.FirstName) select p;
                }
                if (residentSearch.LastName != "")
                {
                    residentQuery = from p in residentQuery where p.ResidentTable.LastName.StartsWith(residentSearch.LastName) select p;
                }

                IList<ResidentSetItem> result = residentQuery.Select
                    (item => new ResidentSetItem
                    {
                        ResidentID = item.ResidentTable.ResidentID,
                        FirstName = item.ResidentTable.FirstName,
                        LastName = item.ResidentTable.LastName,
                        MiddleName = item.ResidentTable.MiddleName,
                        BirthDate = item.ResidentTable.BirthDate,
                        IdentificatorNumber = item.ResidentTable.IdentificatorNumber,
                        GenderID = item.ResidentTable.GenderID,
                        RegionID = item.ResidentTable.RegionID,
                        CommunityID = item.ResidentTable.CommunityID,
                        Street = item.ResidentTable.Street,
                        Building = item.ResidentTable.Building,
                        Home = item.ResidentTable.Home,
                        GenderName = item.GenderTable.GenderName,
                        RegionName = item.RegionTable.RegionName,
                        CommunityName = item.CommunityTable.CommunityName,
                        BirthYear = item.ResidentTable.BirthYear,
                        Phone = item.ResidentTable.Phone,
                        Email = item.ResidentTable.Email
                    }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        /// <summary>
        /// Get existing temporary Resident and return it as a result
        /// </summary>
        /// <returns></returns>
        public ResidentItem GetResidentItem(int? residentID = null)
        {
            try
            {
                if (residentID != null)
                {
                    Resident resident = db.Residents.Find(residentID);
                    ResidentItem item = new ResidentItem
                    {
                        ResidentID = resident.ResidentID,
                        FirstName = resident.FirstName,
                        LastName = resident.LastName,
                        MiddleName = resident.MiddleName,
                        BirthDate = resident.BirthDate,
                        IdentificatorNumber = resident.IdentificatorNumber,
                        GenderID = resident.GenderID,
                        RegionID = resident.RegionID,
                        CommunityID = resident.CommunityID,
                        Street = resident.Street,
                        Building = resident.Building,
                        Home = resident.Home,
                        BirthYear = resident.BirthYear,
                        Phone = resident.Phone,
                        Email = resident.Email,

                        InitializationType = InitializationTypes.Update,
                    };
                    return item;
                }
                else
                {
                    var item = new ResidentItem
                    {
                        InitializationType = InitializationTypes.Insert,
                    };
                    return item;
                }

            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public ResidentItem SaveResident(ResidentItem residentItem)
        {
            try
            {
                Resident resident = null;
                switch (residentItem.InitializationType)
                {
                    case InitializationTypes.Insert:
                        resident = new Resident
                        {
                            FirstName = residentItem.FirstName,
                            LastName = residentItem.LastName,
                            MiddleName = residentItem.MiddleName,
                            //BirthDate = new DateTime(residentItem.BirthYear, 1, 1),
                            IdentificatorNumber = residentItem.IdentificatorNumber,
                            GenderID = residentItem.GenderID,
                            RegionID = residentItem.RegionID,
                            CommunityID = residentItem.CommunityID,
                            Street = residentItem.Street,
                            Building = residentItem.Building,
                            Home = residentItem.Home,
                            BirthYear = residentItem.BirthYear,
                            Phone = residentItem.Phone,
                            Email = residentItem.Email
                        };
                        if(residentItem.BirthYear != null)
                        {
                            resident.BirthDate = new DateTime((Int16)residentItem.BirthYear, 1, 1);
                        }
                        db.Residents.Add(resident);
                        break;
                    case InitializationTypes.Update:
                        resident = new Resident
                        {
                            ResidentID = residentItem.ResidentID,
                            FirstName = residentItem.FirstName,
                            LastName = residentItem.LastName,
                            MiddleName = residentItem.MiddleName,
                            //BirthDate = new DateTime(residentItem.BirthYear, 1, 1),
                            IdentificatorNumber = residentItem.IdentificatorNumber,
                            GenderID = residentItem.GenderID,
                            RegionID = residentItem.RegionID,
                            CommunityID = residentItem.CommunityID,
                            Street = residentItem.Street,
                            Building = residentItem.Building,
                            Home = residentItem.Home,
                            BirthYear = residentItem.BirthYear,
                            Phone = residentItem.Phone,
                            Email = residentItem.Email
                        };
                        if (residentItem.BirthYear != null)
                        {
                            resident.BirthDate = new DateTime((Int16)residentItem.BirthYear, 1, 1);
                        }
                        db.Residents.Attach(resident);
                        db.Entry(resident).State = EntityState.Modified;
                        break;
                }
                db.SaveChanges();
                residentItem.ResidentID = resident.ResidentID;
                return residentItem;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        /// <summary>
        /// Delete record from dbo.Resident table with the given ResidentID
        /// </summary>
        /// <param name="residentID"></param>
        /// <returns></returns>
        public bool? DeleteResident(int residentID)
        {
            try
            {
                var resident = db.Residents.Find(residentID);
                if (resident != null)
                {
                    db.Residents.Remove(resident);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public IList<ResidentTypeConsultationSet> GetTypeConsultationsByResidentID(int residentID)
        {
            IList<ResidentTypeConsultationSet> result = new List<ResidentTypeConsultationSet>();

            var query = from typeconsultation in db.TypeConsultations
                        join t1 in db.Issues on typeconsultation.IssueID equals t1.IssueID
                        into r1
                        from issue in r1.DefaultIfEmpty().Where(p => p.ResidentID == residentID)
                        join t11 in db.IssueTypes on issue.IssueTypeID equals t11.IssueTypeID into r11
                        from issueType in r11.DefaultIfEmpty()
                        join t12 in db.IssueCategorys on issue.IssueCategoryID equals t12.IssueCategoryID into r12
                        from issueCategory in r12.DefaultIfEmpty()
                        join t2 in db.ConsultationTypes on typeconsultation.ConsultationTypeID equals t2.ConsultationTypeID into r2
                        from consultationtype in r2.DefaultIfEmpty()
                        join t3 in db.TargetGroups on typeconsultation.TargetGroupID equals t3.TargetGroupID into r3
                        from targetgroup in r3.DefaultIfEmpty()
                        join t4 in db.ProcessStatuss on typeconsultation.ProcessStatusID equals t4.ProcessStatusID into r4
                        from processstatus in r4.DefaultIfEmpty()
                        join t5 in db.ConsultationResults on typeconsultation.ConsultationResultID equals t5.ConsultationResultID into r5
                        from consultationresult in r5.DefaultIfEmpty()
                        select new
                        {
                            TypeConsultationTable = typeconsultation,
                            IssueTable = issue,
                            IssueTypeTable = issueType,
                            IssueCategoryTable = issueCategory,
                            ConsultationTypeTable = consultationtype,
                            TargetGroupTable = targetgroup,
                            ProcessStatusTable = processstatus,
                            ConsultationResultTable = consultationresult
                        };



            result = query.Select(list => new ResidentTypeConsultationSet
            {
                TypeConsultationID = list.TypeConsultationTable.TypeConsultationID,
                //ResidentID = list.TypeConsultationTable.ResidentID,
                TypeConsultationDate = list.TypeConsultationTable.TypeConsultationDate,
                IssueName = list.IssueTable.IssueName,
                IssueDescription = list.IssueTable.IssueDescription,
                IssueDate = list.IssueTable.IssueDate,
                IssueTypeID = list.IssueTable.IssueTypeID,
                IssueTypeName = list.IssueTypeTable.IssueTypeName,
                IssueCategoryID = list.IssueTable.IssueCategoryID,
                IssueCategoryName = list.IssueCategoryTable.IssueCategoryName,
                ConsultationTypeID = list.TypeConsultationTable.ConsultationTypeID,
                ConsultationTypeName = list.ConsultationTypeTable.ConsultationTypeName,
                ProcessStatusID = list.TypeConsultationTable.ProcessStatusID,
                ProcessStatusName = list.ProcessStatusTable.ProcessStatusName,
                ConsultationResultID = list.TypeConsultationTable.ConsultationResultID,
                ConsultationResultName = list.ConsultationResultTable.ConsultationResultName,
                TargetGroupID = list.TypeConsultationTable.TargetGroupID,
                TargetGroupName = list.TargetGroupTable.TargetGroupName,
                TypeConsultationName = list.TypeConsultationTable.TypeConsultationName
            }).ToList();

            return result;
        }

        public IList<ResidentOralConsultationSet> GetOralConsultationsByResidentID(int residentID)
        {
            IList<ResidentOralConsultationSet> result = new List<ResidentOralConsultationSet>();

            var query = from oralconsultation in db.OralConsultations
                        join t1 in db.Issues on oralconsultation.IssueID equals t1.IssueID
                        into r1
                        from issue in r1.DefaultIfEmpty().Where(p => p.ResidentID == residentID)
                        join t11 in db.IssueTypes on issue.IssueTypeID equals t11.IssueTypeID into r11
                        from issueType in r11.DefaultIfEmpty()
                        join t12 in db.IssueCategorys on issue.IssueCategoryID equals t12.IssueCategoryID into r12
                        from issueCategory in r12.DefaultIfEmpty()
                        join t2 in db.InvocationTypes on oralconsultation.InvocationTypeID equals t2.InvocationTypeID into r2
                        from invocationtype in r2.DefaultIfEmpty()
                        join t3 in db.TargetGroups on oralconsultation.TargetGroupID equals t3.TargetGroupID into r3
                        from targetgroup in r3.DefaultIfEmpty()

                        select new
                        {
                            OralConsultationTable = oralconsultation,
                            IssueTable = issue,
                            IssueTypeTable = issueType,
                            IssueCategoryTable = issueCategory,
                            InvocationTypeTable = invocationtype,
                            TargetGroupTable = targetgroup
                        };


            result = query.Select(list => new ResidentOralConsultationSet
            {
                OralConsultationID = list.OralConsultationTable.OralConsultationID,
                ResidentID = list.IssueTable.ResidentID,
                IssueName = list.IssueTable.IssueName,
                IssueDescription = list.IssueTable.IssueDescription,
                IssueDate = list.IssueTable.IssueDate,
                IssueTypeID = list.IssueTable.IssueTypeID,
                IssueTypeName = list.IssueTypeTable.IssueTypeName,
                IssueCategoryID = list.IssueTable.IssueCategoryID,
                IssueCategoryName = list.IssueCategoryTable.IssueCategoryName,
                OralConsultationDate = list.OralConsultationTable.OralConsultationDate,
                TargetGroupName = list.TargetGroupTable.TargetGroupName,
                InvocationTypeName = list.InvocationTypeTable.InvocationTypeName
            }).ToList();

            return result;
        }

    }
}

