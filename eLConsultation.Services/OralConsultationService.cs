using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class OralConsultationService : ServiceBase
    {
        public OralConsultationService()
            : base()
        {
        }

        public List<SelectListItem> GetTargetGroupDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            TargetGroupService targetGroup = new TargetGroupService();
            selectedListItem = targetGroup.GetTargetGroups().Select(x => new SelectListItem { Text = x.TargetGroupName, Value = x.TargetGroupID.ToString() }).ToList();
            return selectedListItem;
        }

        public List<SelectListItem> GetInvocationTypeDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            InvocationTypeService invocationType = new InvocationTypeService();
            selectedListItem = invocationType.GetInvocationTypes().Select(x => new SelectListItem { Text = x.InvocationTypeName, Value = x.InvocationTypeID.ToString() }).ToList();
            return selectedListItem;
        }

        public IList<OralConsultationSetItem> FilterOralConsultations(OralConsultationSearch oralConsultationSearch)
        {
            IList<OralConsultationSetItem> result = new List<OralConsultationSetItem>();

            var query = from oralconsultation in db.OralConsultations
                        join t1 in db.Issues on oralconsultation.IssueID equals t1.IssueID into r1
                        from issue in r1.DefaultIfEmpty()
                        join t2 in db.InvocationTypes on oralconsultation.InvocationTypeID equals t2.InvocationTypeID into r2
                        from invocationtype in r2.DefaultIfEmpty()
                        join t3 in db.TargetGroups on oralconsultation.TargetGroupID equals t3.TargetGroupID into r3
                        from targetgroup in r3.DefaultIfEmpty()
                        select new { OralConsultationTable = oralconsultation, IssueTable = issue, InvocationTypeTable = invocationtype, TargetGroupTable = targetgroup };

            if (oralConsultationSearch.OralConsultationDate != null)
            {
                query = from p in query where p.OralConsultationTable.OralConsultationDate == oralConsultationSearch.OralConsultationDate select p;
            }
            if (oralConsultationSearch.OralConsultationID != null)
            {
                query = from p in query where p.OralConsultationTable.OralConsultationID == oralConsultationSearch.OralConsultationID select p;
            }

            result = query.Select(list => new OralConsultationSetItem
            {
                OralConsultationID = list.OralConsultationTable.OralConsultationID,
                OralConsultationDate = list.OralConsultationTable.OralConsultationDate,
                IssueID = list.OralConsultationTable.IssueID,
                IssueName = list.IssueTable.IssueName,
                TargetGroupName = list.TargetGroupTable.TargetGroupName,
                InvocationTypeName = list.InvocationTypeTable.InvocationTypeName
            }).ToList();

            return result;
        }

        public OralConsultationDetail GetOralConsultationDetail(int oralConsultationID)
        {
            var oralConsultationQuery = from oralconsultation in db.OralConsultations
                                        join t2 in db.InvocationTypes on oralconsultation.InvocationTypeID equals t2.InvocationTypeID into r2
                                        from invocationtype in r2.DefaultIfEmpty()
                                        join t3 in db.TargetGroups on oralconsultation.TargetGroupID equals t3.TargetGroupID into r3
                                        from targetgroup in r3.DefaultIfEmpty()
                                        where oralconsultation.OralConsultationID == oralConsultationID
                                        select new { DetailTable = oralconsultation, InvocationTypeTable = invocationtype, TargetGroupTable = targetgroup };

            OralConsultationDetail oralConsultationDetail = oralConsultationQuery.Select(list => new OralConsultationDetail
            {
                OralConsultationID = list.DetailTable.OralConsultationID,
                OralConsultationDate = list.DetailTable.OralConsultationDate,
                InvocationTypeID = list.DetailTable.InvocationTypeID,
                InvocationTypeName = list.InvocationTypeTable.InvocationTypeName,
                TargetGroupID = list.DetailTable.TargetGroupID,
                TargetGroupName = list.TargetGroupTable.TargetGroupName,
                ProblemDescription = list.DetailTable.ProblemDescription,
                ConsultationDescription = list.DetailTable.ConsultationDescription
            }).First();

            oralConsultationDetail.OralConsultationConsultantDetails = GetOralConsultationConsultantDetail(oralConsultationID);
            oralConsultationDetail.OralConsultationOrganizationDetails = GetOralConsultationOrganizationDetail(oralConsultationID);
            oralConsultationDetail.OralConsultationRightDetails = GetOralConsultationRightDetail(oralConsultationID);

            return oralConsultationDetail;

        }

        public OralConsultationItem GetOralConsultationItemByIssueID(int issueID)
        {
            var issue = db.Issues.Find(issueID);
            Resident resident = null;
            if (issue.ResidentID != null)
            {
                resident = db.Residents.Find(issue.ResidentID);
            }
            OralConsultationItem item = new OralConsultationItem
            {
                OralConsultationID = 0,
                IssueID = issue.IssueID,
                IssueName = issue.IssueName,
                IssueDate = issue.IssueDate,
                IssueDescription = issue.IssueDescription,
                OralConsultationDate = null,
                InvocationTypeID = null,
                TargetGroupID = null,
                ProblemDescription = String.Empty,
                ConsultationDescription = String.Empty,
                GUID = Guid.NewGuid(),
                InitializationType = InitializationTypes.Insert,
                UserID = String.Empty,
                ChangeDate = null
            };

            return item;
        }

        public OralConsultationItem GetOralConsultationItemByID(int oralConsultationID)
        {
            var oralConsultation = db.OralConsultations.Find(oralConsultationID);
            var issue = db.Issues.Find(oralConsultation.IssueID);

            OralConsultationItem item = new OralConsultationItem
            {
                OralConsultationID = oralConsultation.OralConsultationID,
                IssueID = issue.IssueID,
                IssueName = issue.IssueName,
                IssueDate = issue.IssueDate,
                IssueDescription = issue.IssueDescription,
                OralConsultationDate = oralConsultation.OralConsultationDate,
                InvocationTypeID = oralConsultation.InvocationTypeID,
                TargetGroupID = oralConsultation.TargetGroupID,
                ProblemDescription = oralConsultation.ProblemDescription,
                ConsultationDescription = oralConsultation.ConsultationDescription,
                GUID = Guid.NewGuid(),
                InitializationType = InitializationTypes.Update,
                UserID = String.Empty,
                ChangeDate = null
            };

            foreach (var consultant in db.OralConsultationConsultants.Where(p => p.OralConsultationID == oralConsultationID))
            {
                TmpOralConsultationConsultant itm = new TmpOralConsultationConsultant();
                itm.OralConsultationConsultantID = consultant.OralConsultationConsultantID;
                itm.OralConsultationID = consultant.OralConsultationID;
                itm.ConsultantID = consultant.ConsultantID;
                itm.GUID = item.GUID;
                db.TmpOralConsultationConsultants.Add(itm);
            }

            foreach (var organization in db.OralConsultationOrganizations.Where(p => p.OralConsultationID == oralConsultationID))
            {
                TmpOralConsultationOrganization itm = new TmpOralConsultationOrganization();
                itm.OralConsultationOrganizationID = organization.OralConsultationOrganizationID;
                itm.OralConsultationID = organization.OralConsultationID;
                itm.OrganizationID = organization.OrganizationID;
                itm.GUID = item.GUID;
                db.TmpOralConsultationOrganizations.Add(itm);
            }

            foreach (var right in db.OralConsultationRights.Where(p => p.OralConsultationID == oralConsultationID))
            {
                TmpOralConsultationRight itm = new TmpOralConsultationRight();
                itm.OralConsultationRightID = right.OralConsultationRightID;
                itm.OralConsultationID = right.OralConsultationID;
                itm.HumanRightID = right.HumanRightID;
                itm.GUID = item.GUID;
                db.TmpOralConsultationRights.Add(itm);
            }

            foreach (var permission in db.OralConsultationPermissions.Where(p => p.OralConsultationID == oralConsultationID))
            {
                TmpOralConsultationPermission itm = new TmpOralConsultationPermission();
                itm.OralConsultationPermissionID = permission.OralConsultationPermissionID;
                itm.OralConsultationID = permission.OralConsultationID;
                itm.UserID = permission.UserID;
                itm.IsChange = permission.IsChange;
                itm.IsRead = permission.IsRead;
                itm.GUID = item.GUID;
                db.TmpOralConsultationPermissions.Add(itm);
            }

            db.SaveChanges();

            return item;
        }

        public OralConsultationItem SaveOralConsultation(OralConsultationItem item)
        {      
                OralConsultationItem resultItem = null;
                switch (item.InitializationType)
                {
                    case InitializationTypes.Insert:
                        resultItem = this.InsertOralConsultation(item);
                        break;
                    case InitializationTypes.Update:
                        resultItem = this.UpdateOralConsultation(item);
                        break;
                }
                return resultItem;
        }

        public bool? DeleteOralConsultation(int oralConsultationID)
        {
            try
            {
                var item = db.OralConsultations.Find(oralConsultationID);
                if (item != null)
                {
                    db.OralConsultationConsultants.RemoveRange(item.OralConsultationConsultants);
                    db.OralConsultationOrganizations.RemoveRange(item.OralConsultationOrganizations);
                    db.OralConsultationPermissions.RemoveRange(item.OralConsultationPermissionss);
                    db.OralConsultationRights.RemoveRange(item.OralConsultationRights);
                    db.OralConsultations.Remove(item);
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

        private OralConsultationItem InsertOralConsultation(OralConsultationItem item)
        {

            OralConsultation entity = new OralConsultation
            {
                OralConsultationID = item.OralConsultationID,
                //ResidentID = (int)item.ResidentID,
                IssueID = (int)item.IssueID,
                OralConsultationDate = item.OralConsultationDate,
                InvocationTypeID = item.InvocationTypeID,
                TargetGroupID = item.TargetGroupID,
                ProblemDescription = item.ProblemDescription,
                ConsultationDescription = item.ConsultationDescription,
                UserID = item.UserID,
                ChangeDate = DateTime.Now,
                OwnerID = item.UserID
            };

            db.OralConsultations.Add(entity);

            this.InsertConsultant(item, entity);
            this.InsertOrganization(item, entity);
            this.InsertRight(item, entity);
            this.InsertPermission(item, entity);

            db.SaveChanges();

            item.OralConsultationID = entity.OralConsultationID;

            return item;
        }
        private OralConsultationItem UpdateOralConsultation(OralConsultationItem item)
        {
            OralConsultation entity = new OralConsultation
            {
                OralConsultationID = item.OralConsultationID,
                //ResidentID = (int)item.ResidentID,
                IssueID = (int)item.IssueID,
                OralConsultationDate = item.OralConsultationDate,
                InvocationTypeID = item.InvocationTypeID,
                TargetGroupID = item.TargetGroupID,
                ProblemDescription = item.ProblemDescription,
                ConsultationDescription = item.ConsultationDescription,
                UserID = item.UserID,
                ChangeDate = DateTime.Now
            };

            db.OralConsultations.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;

            this.UpdateConsultant(item, entity);
            this.UpdateOrganization(item, entity);
            this.UpdateRight(item, entity);
            this.UpdatePermission(item, entity);

            db.SaveChanges();

            item.OralConsultationID = entity.OralConsultationID;

            return item;

        }
        private bool InsertConsultant(OralConsultationItem item, OralConsultation entity)
        {
            foreach (var itm in db.TmpOralConsultationConsultants.Where(p => p.GUID == item.GUID))
            {
                OralConsultationConsultant dbItem = new OralConsultationConsultant
                {
                    OralConsultation = entity,
                    ConsultantID = itm.ConsultantID,
                    OralConsultationID = itm.OralConsultationID,
                    OralConsultationConsultantID = itm.OralConsultationConsultantID
                };
                db.OralConsultationConsultants.Add(dbItem);
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpOralConsultationConsultants.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpOralConsultationConsultants.Remove(db.TmpOralConsultationConsultants.Find(ID));
            }
            return true;
        }
        private bool UpdateConsultant(OralConsultationItem item, OralConsultation entity)
        {
            List<int> existingItems = new List<int>();
            foreach (var itm in db.TmpOralConsultationConsultants.Where(p => p.GUID == item.GUID))
            {
                existingItems.Add(itm.OralConsultationConsultantID);
                OralConsultationConsultant dbItem = new OralConsultationConsultant
                {
                    OralConsultation = entity,
                    ConsultantID = itm.ConsultantID,
                    OralConsultationID = itm.OralConsultationID,
                    OralConsultationConsultantID = itm.OralConsultationConsultantID
                };

                if (itm.OralConsultationConsultantID == 0)
                {
                    db.OralConsultationConsultants.Add(dbItem);
                }
                else
                {
                    db.OralConsultationConsultants.Attach(dbItem);
                    db.Entry(dbItem).State = EntityState.Modified;
                }
            }

            List<int> deletedItems = new List<int>();
            foreach (var itm2 in db.OralConsultationConsultants.Where(p => p.OralConsultationID == item.OralConsultationID))
            {
                deletedItems.Add(itm2.OralConsultationConsultantID);
            }

            List<int> common = deletedItems.Except(existingItems).ToList();
            foreach (int deletionID in common)
            {
                db.OralConsultationConsultants.Remove(db.OralConsultationConsultants.Find(deletionID));
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpOralConsultationConsultants.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpOralConsultationConsultants.Remove(db.TmpOralConsultationConsultants.Find(ID));
            }
            return true;
        }
        private bool InsertOrganization(OralConsultationItem item, OralConsultation entity)
        {
            foreach (var itm in db.TmpOralConsultationOrganizations.Where(p => p.GUID == item.GUID))
            {
                OralConsultationOrganization dbItem = new OralConsultationOrganization
                {
                    OralConsultation = entity,
                    OrganizationID = itm.OrganizationID,
                    OralConsultationID = itm.OralConsultationID,
                    OralConsultationOrganizationID = itm.OralConsultationOrganizationID
                };
                db.OralConsultationOrganizations.Add(dbItem);
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpOralConsultationOrganizations.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpOralConsultationOrganizations.Remove(db.TmpOralConsultationOrganizations.Find(ID));
            }
            return true;
        }
        private bool UpdateOrganization(OralConsultationItem item, OralConsultation entity)
        {
            List<int> existingItems = new List<int>();
            foreach (var itm in db.TmpOralConsultationOrganizations.Where(p => p.GUID == item.GUID))
            {
                existingItems.Add(itm.OralConsultationOrganizationID);
                OralConsultationOrganization dbItem = new OralConsultationOrganization
                {
                    OralConsultation = entity,
                    OrganizationID = itm.OrganizationID,
                    OralConsultationID = itm.OralConsultationID,
                    OralConsultationOrganizationID = itm.OralConsultationOrganizationID
                };

                if (itm.OralConsultationOrganizationID == 0)
                {
                    db.OralConsultationOrganizations.Add(dbItem);
                }
                else
                {
                    db.OralConsultationOrganizations.Attach(dbItem);
                    db.Entry(dbItem).State = EntityState.Modified;
                }
            }

            List<int> deletedItems = new List<int>();
            foreach (var itm2 in db.OralConsultationOrganizations.Where(p => p.OralConsultationID == item.OralConsultationID))
            {
                deletedItems.Add(itm2.OralConsultationOrganizationID);
            }

            List<int> common = deletedItems.Except(existingItems).ToList();
            foreach (int deletionID in common)
            {
                db.OralConsultationOrganizations.Remove(db.OralConsultationOrganizations.Find(deletionID));
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpOralConsultationOrganizations.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpOralConsultationOrganizations.Remove(db.TmpOralConsultationOrganizations.Find(ID));
            }
            return true;
        }
        private bool InsertRight(OralConsultationItem item, OralConsultation entity)
        {
            foreach (var itm in db.TmpOralConsultationRights.Where(p => p.GUID == item.GUID))
            {
                OralConsultationRight dbItem = new OralConsultationRight
                {
                    OralConsultation = entity,
                    HumanRightID = itm.HumanRightID,
                    OralConsultationID = itm.OralConsultationID,
                    OralConsultationRightID = itm.OralConsultationRightID
                };
                db.OralConsultationRights.Add(dbItem);
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpOralConsultationRights.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpOralConsultationRights.Remove(db.TmpOralConsultationRights.Find(ID));
            }
            return true;
        }
        private bool UpdateRight(OralConsultationItem item, OralConsultation entity)
        {
            List<int> existingItems = new List<int>();
            foreach (var itm in db.TmpOralConsultationRights.Where(p => p.GUID == item.GUID))
            {
                existingItems.Add(itm.OralConsultationRightID);
                OralConsultationRight dbItem = new OralConsultationRight
                {
                    OralConsultation = entity,
                    HumanRightID = itm.HumanRightID,
                    OralConsultationID = itm.OralConsultationID,
                    OralConsultationRightID = itm.OralConsultationRightID
                };

                if (itm.OralConsultationRightID == 0)
                {
                    db.OralConsultationRights.Add(dbItem);
                }
                else
                {
                    db.OralConsultationRights.Attach(dbItem);
                    db.Entry(dbItem).State = EntityState.Modified;
                }
            }

            List<int> deletedItems = new List<int>();
            foreach (var itm2 in db.OralConsultationRights.Where(p => p.OralConsultationID == item.OralConsultationID))
            {
                deletedItems.Add(itm2.OralConsultationRightID);
            }

            List<int> common = deletedItems.Except(existingItems).ToList();
            foreach (int deletionID in common)
            {
                db.OralConsultationRights.Remove(db.OralConsultationRights.Find(deletionID));
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpOralConsultationRights.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpOralConsultationRights.Remove(db.TmpOralConsultationRights.Find(ID));
            }
            return true;
        }
        private bool InsertPermission(OralConsultationItem item, OralConsultation entity)
        {
            foreach (var itm in db.TmpOralConsultationPermissions.Where(p => p.GUID == item.GUID))
            {
                OralConsultationPermission dbItem = new OralConsultationPermission
                {
                    OralConsultation = entity,
                    UserID = itm.UserID,
                    IsChange = itm.IsChange,
                    IsRead = itm.IsRead,
                    OralConsultationID = itm.OralConsultationID,
                    OralConsultationPermissionID = itm.OralConsultationPermissionID
                };
                db.OralConsultationPermissions.Add(dbItem);
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpOralConsultationPermissions.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpOralConsultationPermissions.Remove(db.TmpOralConsultationPermissions.Find(ID));
            }
            return true;
        }
        private bool UpdatePermission(OralConsultationItem item, OralConsultation entity)
        {
            List<int> existingItems = new List<int>();
            foreach (var itm in db.TmpOralConsultationPermissions.Where(p => p.GUID == item.GUID))
            {
                existingItems.Add(itm.OralConsultationPermissionID);
                OralConsultationPermission dbItem = new OralConsultationPermission
                {
                    OralConsultation = entity,
                    UserID = itm.UserID,
                    IsChange = itm.IsChange,
                    IsRead = itm.IsRead,
                    OralConsultationID = itm.OralConsultationID,
                    OralConsultationPermissionID = itm.OralConsultationPermissionID
                };

                if (itm.OralConsultationPermissionID == 0)
                {
                    db.OralConsultationPermissions.Add(dbItem);
                }
                else
                {
                    db.OralConsultationPermissions.Attach(dbItem);
                    db.Entry(dbItem).State = EntityState.Modified;
                }
            }

            List<int> deletedItems = new List<int>();
            foreach (var itm2 in db.OralConsultationPermissions.Where(p => p.OralConsultationID == item.OralConsultationID))
            {
                deletedItems.Add(itm2.OralConsultationPermissionID);
            }

            List<int> common = deletedItems.Except(existingItems).ToList();
            foreach (int deletionID in common)
            {
                db.OralConsultationPermissions.Remove(db.OralConsultationPermissions.Find(deletionID));
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpOralConsultationPermissions.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpOralConsultationPermissions.Remove(db.TmpOralConsultationPermissions.Find(ID));
            }
            return true;
        }
        private IList<OralConsultationConsultantDetail> GetOralConsultationConsultantDetail(int? oralConsultationID)
        {
            IList<OralConsultationConsultantDetail> item = null;
            return item = (from occ in db.OralConsultationConsultants
                           join c in db.Consultants on occ.ConsultantID equals c.ConsultantID into x
                           from z in x.DefaultIfEmpty()
                           where occ.OralConsultationID == oralConsultationID
                           select new
                           {
                               OralConsultationConsultantTable = occ,
                               ConsultantTable = z
                           })
                           .Select(list => new OralConsultationConsultantDetail
                           {
                               OralConsultationConsultantID = list.OralConsultationConsultantTable.OralConsultationConsultantID,
                               OralConsultationID = list.OralConsultationConsultantTable.OralConsultationID,
                               ConsultantID = list.OralConsultationConsultantTable.ConsultantID,
                               ConsultantName = list.ConsultantTable.FirstName + " " + list.ConsultantTable.LastName
                           }).ToList();
        }
        private IList<OralConsultationOrganizationDetail> GetOralConsultationOrganizationDetail(int? oralConsultationID)
        {
            IList<OralConsultationOrganizationDetail> item = null;
            return item = (from oco in db.OralConsultationOrganizations
                           join c in db.Organizations on oco.OrganizationID equals c.OrganizationID into x
                           from z in x.DefaultIfEmpty()
                           where oco.OralConsultationID == oralConsultationID
                           select new
                           {
                               OralConsultationOrganizationTable = oco,
                               OrganizationTable = z
                           })
                           .Select(list => new OralConsultationOrganizationDetail
                           {
                               OralConsultationOrganizationID = list.OralConsultationOrganizationTable.OralConsultationOrganizationID,
                               OralConsultationID = list.OralConsultationOrganizationTable.OralConsultationID,
                               OrganizationID = list.OralConsultationOrganizationTable.OrganizationID,
                               OrganizationName = list.OrganizationTable.OrganizationName
                           }).ToList();
        }
        private IList<OralConsultationRightDetail> GetOralConsultationRightDetail(int? oralConsultationID)
        {
            IList<OralConsultationRightDetail> item = null;
            return item = (from ocr in db.OralConsultationRights
                           join c in db.HumanRights on ocr.HumanRightID equals c.HumanRightID into x
                           from z in x.DefaultIfEmpty()
                           where ocr.OralConsultationID == oralConsultationID
                           select new
                           {
                               OralConsultationRightTable = ocr,
                               HumanRightTable = z
                           })
                           .Select(list => new OralConsultationRightDetail
                           {
                               OralConsultationRightID = list.OralConsultationRightTable.OralConsultationRightID,
                               OralConsultationID = list.OralConsultationRightTable.OralConsultationID,
                               HumanRightID = list.OralConsultationRightTable.HumanRightID,
                               HumanRightName = list.HumanRightTable.HumanRightName
                           }).ToList();
        }

    }
}
