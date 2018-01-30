using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class TypeConsultationService : ServiceBase
    {
        public TypeConsultationService()
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
        public List<SelectListItem> GetConsultationTypeDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            ConsultationTypeService consultationType = new ConsultationTypeService();
            selectedListItem = consultationType.GetConsultationTypes().Select(x => new SelectListItem { Text = x.ConsultationTypeName, Value = x.ConsultationTypeID.ToString() }).ToList();
            return selectedListItem;
        }
        public List<SelectListItem> GetProcessStatusDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            ProcessStatusService processStatus = new ProcessStatusService();
            selectedListItem = processStatus.GetProcessStatuss().Select(x => new SelectListItem { Text = x.ProcessStatusName, Value = x.ProcessStatusID.ToString() }).ToList();
            return selectedListItem;
        }
        public List<SelectListItem> GetConsultationResultDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            ConsultationResultService consultationResult = new ConsultationResultService();
            selectedListItem = consultationResult.GetConsultationResults().Select(x => new SelectListItem { Text = x.ConsultationResultName, Value = x.ConsultationResultID.ToString() }).ToList();
            return selectedListItem;
        }
        public IList<TypeConsultationSetItem> FilterTypeConsultations(TypeConsultationSearch typeConsultationSearch)
        {
            IList<TypeConsultationSetItem> result = new List<TypeConsultationSetItem>();

            var query = from typeconsultation in db.TypeConsultations
                        //join t1 in db.Residents on typeconsultation.ResidentID equals t1.ResidentID into r1
                        //from resident in r1.DefaultIfEmpty()
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
                            //ResidentTable = resident,
                            ConsultationTypeTable = consultationtype,
                            TargetGroupTable = targetgroup,
                            ProcessStatusTable = processstatus,
                            ConsultationResultTable = consultationresult
                        };


            //if (typeConsultationSearch.FirstName != "")
            //{
            //    query = from p in query where p.ResidentTable.FirstName.StartsWith(typeConsultationSearch.FirstName) select p;
            //}
            //if (typeConsultationSearch.LastName != "")
            //{
            //    query = from p in query where p.ResidentTable.LastName.StartsWith(typeConsultationSearch.LastName) select p;
            //}
            if (typeConsultationSearch.TypeConsultationDate != null)
            {
                query = from p in query where p.TypeConsultationTable.TypeConsultationDate == typeConsultationSearch.TypeConsultationDate select p;
            }
            if (typeConsultationSearch.TypeConsultationID != null)
            {
                query = from p in query where p.TypeConsultationTable.TypeConsultationID == typeConsultationSearch.TypeConsultationID select p;
            }

            result = query.Select(list => new TypeConsultationSetItem
            {
                TypeConsultationID = list.TypeConsultationTable.TypeConsultationID,
                ResidentID = list.TypeConsultationTable.ResidentID,
                TypeConsultationDate = list.TypeConsultationTable.TypeConsultationDate,
                //FirstName = list.ResidentTable.FirstName,
                //LastName = list.ResidentTable.LastName,
                //MiddleName = list.ResidentTable.MiddleName,
                //BirthDate = list.ResidentTable.BirthDate,
                //IdentificatorNumber = list.ResidentTable.IdentificatorNumber,
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
        public TypeConsultationDetail GetTypeConsultationDetail(int? typeConsultationID)
        {
            var typeConsultationQuery = from typeconsultation in db.TypeConsultations
                                        join t1 in db.Residents on typeconsultation.ResidentID equals t1.ResidentID into r1
                                        from resident in r1.DefaultIfEmpty()
                                        join t2 in db.ConsultationTypes on typeconsultation.ConsultationTypeID equals t2.ConsultationTypeID into r2
                                        from consultationtype in r2.DefaultIfEmpty()
                                        join t3 in db.TargetGroups on typeconsultation.TargetGroupID equals t3.TargetGroupID into r3
                                        from targetgroup in r3.DefaultIfEmpty()
                                        join t4 in db.ProcessStatuss on typeconsultation.ProcessStatusID equals t4.ProcessStatusID into r4
                                        from processstatus in r4.DefaultIfEmpty()
                                        join t5 in db.ConsultationResults on typeconsultation.ConsultationResultID equals t5.ConsultationResultID into r5
                                        from consultationresult in r5.DefaultIfEmpty()
                                        where typeconsultation.TypeConsultationID == typeConsultationID
                                        select new
                                        {
                                            TypeConsultationTable = typeconsultation,
                                            ResidentTable = resident,
                                            ConsultationTypeTable = consultationtype,
                                            TargetGroupTable = targetgroup,
                                            ProcessStatusTable = processstatus,
                                            ConsultationResultTable = consultationresult
                                        };

            TypeConsultationDetail typeConsultationDetail = typeConsultationQuery.Select(list => new TypeConsultationDetail
            {
                TypeConsultationID = list.TypeConsultationTable.TypeConsultationID,
                TypeConsultationName = list.TypeConsultationTable.TypeConsultationName,
                ResidentID = list.TypeConsultationTable.ResidentID,
                FirstName = list.ResidentTable.FirstName,
                LastName = list.ResidentTable.LastName,
                MiddleName = list.ResidentTable.MiddleName,
                IdentificatorNumber = list.ResidentTable.IdentificatorNumber,
                BirthDate = list.ResidentTable.BirthDate,
                TypeConsultationDate = list.TypeConsultationTable.TypeConsultationDate,
                ConsultationTypeID = list.TypeConsultationTable.ConsultationTypeID,
                ConsultationTypeName = list.ConsultationTypeTable.ConsultationTypeName,
                ProcessStatusID = list.TypeConsultationTable.ProcessStatusID,
                ProcessStatusName = list.ProcessStatusTable.ProcessStatusName,
                ConsultationResultID = list.TypeConsultationTable.ConsultationResultID,
                ConsultationResultName = list.ConsultationResultTable.ConsultationResultName,
                TargetGroupID = list.TypeConsultationTable.TargetGroupID,
                TargetGroupName = list.TargetGroupTable.TargetGroupName,
            }).First();

            typeConsultationDetail.TypeConsultationConsultantDetails = GetTypeConsultationConsultantDetail(typeConsultationID);
            typeConsultationDetail.TypeConsultationInstanceDetails = GetTypeConsultationInstanceDetail(typeConsultationID);
            typeConsultationDetail.TypeConsultationDeclarationTypeDetails = GetTypeConsultationDeclarationTypeDetail(typeConsultationID);
            typeConsultationDetail.TypeConsultationRecipientDetails = GetTypeConsultationRecipientDetail(typeConsultationID);
            typeConsultationDetail.TypeConsultationRightDetails = GetTypeConsultationRightDetail(typeConsultationID);

            return typeConsultationDetail;
        }
        public TypeConsultationItem GetTypeConsultationByIssueID(int issueID)
        {
            var issue = db.Issues.Find(issueID);
            //var resident = db.Residents.Find(issue.ResidentID);

            TypeConsultationItem item = new TypeConsultationItem
            {
                TypeConsultationID = 0,
                //ResidentID = resident.ResidentID,
                //FirstName = resident.FirstName,
                //LastName = resident.LastName,
                //MiddleName = resident.MiddleName,
                //IdentificatorNumber = resident.IdentificatorNumber,
                //BirthDate = resident.BirthDate,
                IssueID = issue.IssueID,
                IssueName = issue.IssueName,
                IssueDate = issue.IssueDate,
                IssueDescription = issue.IssueDescription,
                TypeConsultationDate = null,
                ConsultationTypeID = null,
                ProcessStatusID = null,
                ConsultationResultID = null,
                TargetGroupID = null,
                GUID = Guid.NewGuid(),
                InitializationType = InitializationTypes.Insert,
                UserID = String.Empty,
                ChangeDate = null,
            };

            return item;
        }

        public IssueItem GetIssueItemByID(int typeConsultationID)
        {
            var typeConsultation = db.TypeConsultations.Find(typeConsultationID);
            var issue = db.Issues.Find(typeConsultation.IssueID);
            var resident = db.Residents.Find(issue.ResidentID);
            var company = db.Companys.Find(issue.CompanyID);

            IssueItem item = new IssueItem();

            if (issue.IssueCategoryID == 1)
            {
                item.IssueID = issue.IssueID;
                item.ResidentID = issue.ResidentID;
                item.FirstName = resident.FirstName;
                item.LastName = resident.LastName;
                item.MiddleName = resident.MiddleName;
                item.IdentificatorNumber = resident.IdentificatorNumber;
                item.BirthDate = resident.BirthDate;
                item.IssueName = issue.IssueName;
                item.IssueDescription = issue.IssueDescription;
                item.IssueDate = issue.IssueDate;
                item.IssueCategoryID = issue.IssueCategoryID;
                item.IssueTypeID = issue.IssueTypeID;

            }
            else if (issue.IssueCategoryID == 2)
            {
                item.IssueID = issue.IssueID;
                item.IssueName = issue.IssueName;
                item.IssueDescription = issue.IssueDescription;
                item.IssueDate = issue.IssueDate;
                item.IssueCategoryID = issue.IssueCategoryID;
                item.IssueTypeID = issue.IssueTypeID;
                item.CompanyID = issue.CompanyID;
                item.CompanyName = company.CompanyName;
            }
            else
            {
                throw new NullReferenceException(String.Format("The issue have not a category"));
            }
            return item;
        }


            public TypeConsultationItem GetTypeConsultationItemByID(int typeConsultationID)
        {
            var typeConsultation = db.TypeConsultations.Find(typeConsultationID);
            var issue = db.Issues.Find(typeConsultation.IssueID);
            var resident = db.Residents.Find(issue.ResidentID);
            var company = db.Companys.Find(issue.CompanyID);

            //TypeConsultationItem item = new TypeConsultationItem();
            //if (issue.IssueCategoryID == 1)
            //{
            //    item.TypeConsultationID = typeConsultationID;
            //    item.TypeConsultationName = typeConsultation.TypeConsultationName;
            //    item.IssueID = typeConsultation.IssueID;
            //    item.ResidentID = issue.ResidentID;
            //    item.TypeConsultationDate = typeConsultation.TypeConsultationDate;
            //    item.ConsultationTypeID = typeConsultation.ConsultationTypeID;
            //    item.ProcessStatusID = typeConsultation.ProcessStatusID;
            //    item.ConsultationResultID = typeConsultation.ConsultationResultID;
            //    item.

            //}

            TypeConsultationItem item = new TypeConsultationItem
            {
                TypeConsultationID = typeConsultationID,
                TypeConsultationName = typeConsultation.TypeConsultationName,
                ResidentID = issue.ResidentID,
                //FirstName = resident.FirstName,
                //LastName = resident.LastName,
                //MiddleName = resident.MiddleName,
               // IdentificatorNumber = resident.IdentificatorNumber,
                //BirthDate = resident.BirthDate,
                IssueID = issue.IssueID,
                IssueName = issue.IssueName,
                IssueDate = issue.IssueDate,
                IssueDescription = issue.IssueDescription,
                TypeConsultationDate = typeConsultation.TypeConsultationDate,
                ConsultationTypeID = typeConsultation.ConsultationTypeID,
                ProcessStatusID = typeConsultation.ProcessStatusID,
                ConsultationResultID = typeConsultation.ConsultationTypeID,
                TargetGroupID = typeConsultation.TargetGroupID,
                GUID = Guid.NewGuid(),
                InitializationType = InitializationTypes.Update,
                UserID = String.Empty,
                ChangeDate = null,
            };

            foreach (var consultant in db.TypeConsultationConsultants.Where(p => p.TypeConsultationID == typeConsultationID))
            {
                TmpTypeConsultationConsultant itm = new TmpTypeConsultationConsultant();
                itm.TypeConsultationConsultantID = consultant.TypeConsultationConsultantID;
                itm.TypeConsultationID = consultant.TypeConsultationID;
                itm.ConsultantID = consultant.ConsultantID;
                itm.GUID = item.GUID;
                db.TmpTypeConsultationConsultants.Add(itm);
            }

            foreach (var instance in db.TypeConsultationInstances.Where(p => p.TypeConsultationID == typeConsultationID))
            {
                TmpTypeConsultationInstance itm = new TmpTypeConsultationInstance();
                itm.TypeConsultationInstanceID = instance.TypeConsultationInstanceID;
                itm.TypeConsultationID = instance.TypeConsultationID;
                itm.OrganizationID = instance.OrganizationID;
                itm.GUID = item.GUID;
                db.TmpTypeConsultationInstances.Add(itm);
            }

            foreach (var declarationType in db.TypeConsultationDeclarationTypes.Where(p => p.TypeConsultationID == typeConsultationID))
            {
                TmpTypeConsultationDeclarationType itm = new TmpTypeConsultationDeclarationType();
                itm.TypeConsultationDeclarationTypeID = declarationType.TypeConsultationDeclarationTypeID;
                itm.TypeConsultationID = declarationType.TypeConsultationID;
                itm.DeclarationTypeID = declarationType.DeclarationTypeID;
                itm.DeclarationURL = declarationType.DeclarationURL;
                itm.DeclarationDeadline = declarationType.DeclarationDeadline;
                itm.DeclarationDate = declarationType.DeclarationDate;
                itm.OrganizationID = declarationType.OrganizationID;
                itm.ResponseDate = declarationType.ResponseDate;
                itm.ResponseTypeID = declarationType.ResponseTypeID;
                itm.ResponseContent = declarationType.ResponseContent;
                itm.ResponseQualityID = declarationType.ResponseQualityID;
                itm.GUID = item.GUID;
                db.TmpTypeConsultationDeclarationTypes.Add(itm);
            }

            foreach (var recipient in db.TypeConsultationRecipients.Where(p => p.TypeConsultationID == typeConsultationID))
            {
                TmpTypeConsultationRecipient itm = new TmpTypeConsultationRecipient();
                itm.TypeConsultationRecipientID = recipient.TypeConsultationRecipientID;
                itm.TypeConsultationID = recipient.TypeConsultationID;
                itm.OrganizationID = recipient.OrganizationID;
                itm.RecipientDate = recipient.RecipientDate;
                itm.GUID = item.GUID;
                db.TmpTypeConsultationRecipients.Add(itm);
            }

            foreach (var right in db.TypeConsultationRights.Where(p => p.TypeConsultationID == typeConsultationID))
            {
                TmpTypeConsultationRight itm = new TmpTypeConsultationRight();
                itm.TypeConsultationRightID = right.TypeConsultationRightID;
                itm.TypeConsultationID = right.TypeConsultationID;
                itm.HumanRightID = right.HumanRightID;
                itm.GUID = item.GUID;
                db.TmpTypeConsultationRights.Add(itm);
            }

            foreach (var permission in db.TypeConsultationPermissions.Where(p => p.TypeConsultationID == typeConsultationID))
            {
                TmpTypeConsultationPermission itm = new TmpTypeConsultationPermission();
                itm.TypeConsultationPermissionID = permission.TypeConsultationPermissionID;
                itm.TypeConsultationID = permission.TypeConsultationID;
                itm.UserID = permission.UserID;
                itm.IsChange = permission.IsChange;
                itm.IsRead = permission.IsRead;
                itm.GUID = item.GUID;
                db.TmpTypeConsultationPermissions.Add(itm);
            }

            db.SaveChanges();

            return item;
        }
        public TypeConsultationItem SaveTypeConsultation(TypeConsultationItem item)
        {
            try
            {
                TypeConsultationItem resultItem = null;
                switch (item.InitializationType)
                {
                    case InitializationTypes.Insert:
                        resultItem = this.InsertTypeConsultation(item);
                        break;
                    case InitializationTypes.Update:
                        resultItem = this.UpdateTypeConsultation(item);
                        break;
                }
                return resultItem;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }
        public bool? DeleteTypeConsultation(int typeConsultationID)
        {
            try
            {
                var item = db.TypeConsultations.Find(typeConsultationID);
                if (item != null)
                {
                    db.TypeConsultationConsultants.RemoveRange(item.TypeConsultationConsultants);
                    db.TypeConsultationDeclarationTypes.RemoveRange(item.TypeConsultationDeclarationTypes);
                    db.TypeConsultationInstances.RemoveRange(item.TypeConsultationInstances);
                    db.TypeConsultationRecipients.RemoveRange(item.TypeConsultationRecipients);
                    db.TypeConsultationRights.RemoveRange(item.TypeConsultationRights);
                    db.TypeConsultationPermissions.RemoveRange(item.TypeConsultationPermissionss);
                    db.TypeConsultations.Remove(item);
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

        private TypeConsultationItem InsertTypeConsultation(TypeConsultationItem item)
        {
            TypeConsultation entity = new TypeConsultation
            {
                TypeConsultationID = item.TypeConsultationID,
                TypeConsultationName = item.TypeConsultationName,
                ResidentID = item.ResidentID,
                IssueID = (int)item.IssueID,
                TypeConsultationDate = item.TypeConsultationDate,
                ConsultationTypeID = item.ConsultationTypeID,
                ProcessStatusID = item.ProcessStatusID,
                ConsultationResultID = item.ConsultationResultID,
                TargetGroupID = item.TargetGroupID,
                UserID = item.UserID,
                ChangeDate = DateTime.Now,
                OwnerID = item.UserID
            };

            db.TypeConsultations.Add(entity);

            this.InsertConsultant(item, entity);
            this.InsertDeclarationType(item, entity);
            this.InsertInstance(item, entity);
            this.InsertRecipient(item, entity);
            this.InsertRight(item, entity);
            this.InsertPermission(item, entity);

            db.SaveChanges();

            item.TypeConsultationID = entity.TypeConsultationID;

            return item;
        }
        private TypeConsultationItem UpdateTypeConsultation(TypeConsultationItem item)
        {
            TypeConsultation entity = new TypeConsultation
            {
                TypeConsultationID = item.TypeConsultationID,
                TypeConsultationName = item.TypeConsultationName,
                //ResidentID = (int)item.ResidentID,
                IssueID = (int)item.IssueID,
                TypeConsultationDate = item.TypeConsultationDate,
                ConsultationTypeID = item.ConsultationTypeID,
                ProcessStatusID = item.ProcessStatusID,
                ConsultationResultID = item.ConsultationResultID,
                TargetGroupID = item.TargetGroupID,
                UserID = item.UserID,
                ChangeDate = DateTime.Now
            };

            db.TypeConsultations.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;

            this.UpdateConsultant(item, entity);
            this.UpdateDeclarationType(item, entity);
            this.UpdateInstance(item, entity);
            this.UpdateRecipient(item, entity);
            this.UpdateRight(item, entity);
            this.UpdatePermission(item, entity);

            db.SaveChanges();

            item.TypeConsultationID = entity.TypeConsultationID;

            return item;
        }
        private bool InsertConsultant(TypeConsultationItem item, TypeConsultation entity)
        {
            foreach (var itm in db.TmpTypeConsultationConsultants.Where(p => p.GUID == item.GUID))
            {
                TypeConsultationConsultant dbItem = new TypeConsultationConsultant
                {
                    TypeConsultation = entity,
                    ConsultantID = itm.ConsultantID,
                    TypeConsultationID = itm.TypeConsultationID,
                    TypeConsultationConsultantID = itm.TypeConsultationConsultantID
                };
                db.TypeConsultationConsultants.Add(dbItem);
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpTypeConsultationConsultants.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpTypeConsultationConsultants.Remove(db.TmpTypeConsultationConsultants.Find(ID));
            }
            return true;
        }
        private bool UpdateConsultant(TypeConsultationItem item, TypeConsultation entity)
        {
            List<int> existingItems = new List<int>();
            foreach (var itm in db.TmpTypeConsultationConsultants.Where(p => p.GUID == item.GUID))
            {
                existingItems.Add(itm.TypeConsultationConsultantID);
                TypeConsultationConsultant dbItem = new TypeConsultationConsultant
                {
                    TypeConsultation = entity,
                    ConsultantID = itm.ConsultantID,
                    TypeConsultationID = itm.TypeConsultationID,
                    TypeConsultationConsultantID = itm.TypeConsultationConsultantID
                };

                if (itm.TypeConsultationConsultantID == 0)
                {
                    db.TypeConsultationConsultants.Add(dbItem);
                }
                else
                {
                    db.TypeConsultationConsultants.Attach(dbItem);
                    db.Entry(dbItem).State = EntityState.Modified;
                }
            }

            List<int> deletedItems = new List<int>();
            foreach (var itm2 in db.TypeConsultationConsultants.Where(p => p.TypeConsultationID == item.TypeConsultationID))
            {
                deletedItems.Add(itm2.TypeConsultationConsultantID);
            }

            List<int> common = deletedItems.Except(existingItems).ToList();
            foreach (int deletionID in common)
            {
                db.TypeConsultationConsultants.Remove(db.TypeConsultationConsultants.Find(deletionID));
            }


            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpTypeConsultationConsultants.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpTypeConsultationConsultants.Remove(db.TmpTypeConsultationConsultants.Find(ID));
            }
            return true;
        }
        private bool InsertInstance(TypeConsultationItem item, TypeConsultation entity)
        {
            foreach (var itm in db.TmpTypeConsultationInstances.Where(p => p.GUID == item.GUID))
            {
                TypeConsultationInstance dbItem = new TypeConsultationInstance
                {
                    TypeConsultation = entity,
                    OrganizationID = itm.OrganizationID,
                    TypeConsultationID = itm.TypeConsultationID,
                    TypeConsultationInstanceID = itm.TypeConsultationInstanceID
                };
                db.TypeConsultationInstances.Add(dbItem);
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpTypeConsultationInstances.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpTypeConsultationInstances.Remove(db.TmpTypeConsultationInstances.Find(ID));
            }
            return true;
        }
        private bool UpdateInstance(TypeConsultationItem item, TypeConsultation entity)
        {
            List<int> existingItems = new List<int>();
            foreach (var itm in db.TmpTypeConsultationInstances.Where(p => p.GUID == item.GUID))
            {
                existingItems.Add(itm.TypeConsultationInstanceID);
                TypeConsultationInstance dbItem = new TypeConsultationInstance
                {
                    TypeConsultation = entity,
                    OrganizationID = itm.OrganizationID,
                    TypeConsultationID = itm.TypeConsultationID,
                    TypeConsultationInstanceID = itm.TypeConsultationInstanceID
                };

                if (itm.TypeConsultationInstanceID == 0)
                {
                    db.TypeConsultationInstances.Add(dbItem);
                }
                else
                {
                    db.TypeConsultationInstances.Attach(dbItem);
                    db.Entry(dbItem).State = EntityState.Modified;
                }
            }

            List<int> deletedItems = new List<int>();
            foreach (var itm2 in db.TypeConsultationInstances.Where(p => p.TypeConsultationID == item.TypeConsultationID))
            {
                deletedItems.Add(itm2.TypeConsultationInstanceID);
            }

            List<int> common = deletedItems.Except(existingItems).ToList();
            foreach (int deletionID in common)
            {
                db.TypeConsultationInstances.Remove(db.TypeConsultationInstances.Find(deletionID));
            }


            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpTypeConsultationInstances.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpTypeConsultationInstances.Remove(db.TmpTypeConsultationInstances.Find(ID));
            }
            return true;
        }
        private bool InsertRecipient(TypeConsultationItem item, TypeConsultation entity)
        {
            foreach (var itm in db.TmpTypeConsultationRecipients.Where(p => p.GUID == item.GUID))
            {
                TypeConsultationRecipient dbItem = new TypeConsultationRecipient
                {
                    TypeConsultation = entity,
                    OrganizationID = itm.OrganizationID,
                    RecipientDate = itm.RecipientDate,
                    TypeConsultationID = itm.TypeConsultationID,
                    TypeConsultationRecipientID = itm.TypeConsultationRecipientID
                };
                db.TypeConsultationRecipients.Add(dbItem);
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpTypeConsultationRecipients.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpTypeConsultationRecipients.Remove(db.TmpTypeConsultationRecipients.Find(ID));
            }
            return true;
        }
        private bool UpdateRecipient(TypeConsultationItem item, TypeConsultation entity)
        {
            List<int> existingItems = new List<int>();
            foreach (var itm in db.TmpTypeConsultationRecipients.Where(p => p.GUID == item.GUID))
            {
                existingItems.Add(itm.TypeConsultationRecipientID);
                TypeConsultationRecipient dbItem = new TypeConsultationRecipient
                {
                    TypeConsultation = entity,
                    OrganizationID = itm.OrganizationID,
                    RecipientDate = itm.RecipientDate,
                    TypeConsultationID = itm.TypeConsultationID,
                    TypeConsultationRecipientID = itm.TypeConsultationRecipientID
                };

                if (itm.TypeConsultationRecipientID == 0)
                {
                    db.TypeConsultationRecipients.Add(dbItem);
                }
                else
                {
                    db.TypeConsultationRecipients.Attach(dbItem);
                    db.Entry(dbItem).State = EntityState.Modified;
                }
            }

            List<int> deletedItems = new List<int>();
            foreach (var itm2 in db.TypeConsultationRecipients.Where(p => p.TypeConsultationID == item.TypeConsultationID))
            {
                deletedItems.Add(itm2.TypeConsultationRecipientID);
            }

            List<int> common = deletedItems.Except(existingItems).ToList();
            foreach (int deletionID in common)
            {
                db.TypeConsultationRecipients.Remove(db.TypeConsultationRecipients.Find(deletionID));
            }


            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpTypeConsultationRecipients.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpTypeConsultationRecipients.Remove(db.TmpTypeConsultationRecipients.Find(ID));
            }
            return true;
        }
        private bool InsertDeclarationType(TypeConsultationItem item, TypeConsultation entity)
        {
            foreach (var itm in db.TmpTypeConsultationDeclarationTypes.Where(p => p.GUID == item.GUID))
            {
                TypeConsultationDeclarationType dbItem = new TypeConsultationDeclarationType
                {
                    TypeConsultation = entity,
                    DeclarationTypeID = itm.DeclarationTypeID,
                    TypeConsultationID = itm.TypeConsultationID,
                    TypeConsultationDeclarationTypeID = itm.TypeConsultationDeclarationTypeID,
                    DeclarationURL = itm.DeclarationURL,
                    DeclarationDeadline = itm.DeclarationDeadline,
                    DeclarationDate = itm.DeclarationDate,
                    OrganizationID = itm.OrganizationID,
                    ResponseDate = itm.ResponseDate,
                    ResponseTypeID = itm.ResponseTypeID,
                    ResponseContent = itm.ResponseContent,
                    ResponseQualityID = itm.ResponseQualityID,
                };
                db.TypeConsultationDeclarationTypes.Add(dbItem);
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpTypeConsultationDeclarationTypes.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpTypeConsultationDeclarationTypes.Remove(db.TmpTypeConsultationDeclarationTypes.Find(ID));
            }
            return true;
        }
        private bool UpdateDeclarationType(TypeConsultationItem item, TypeConsultation entity)
        {
            List<int> existingItems = new List<int>();
            foreach (var itm in db.TmpTypeConsultationDeclarationTypes.Where(p => p.GUID == item.GUID))
            {
                existingItems.Add(itm.TypeConsultationDeclarationTypeID);
                TypeConsultationDeclarationType dbItem = new TypeConsultationDeclarationType
                {
                    TypeConsultation = entity,
                    DeclarationTypeID = itm.DeclarationTypeID,
                    TypeConsultationID = itm.TypeConsultationID,
                    TypeConsultationDeclarationTypeID = itm.TypeConsultationDeclarationTypeID,
                    DeclarationURL = itm.DeclarationURL,
                    DeclarationDeadline = itm.DeclarationDeadline,
                    DeclarationDate = itm.DeclarationDate,
                    OrganizationID = itm.OrganizationID,
                    ResponseDate = itm.ResponseDate,
                    ResponseTypeID = itm.ResponseTypeID,
                    ResponseContent = itm.ResponseContent,
                    ResponseQualityID = itm.ResponseQualityID,
                };

                if (itm.TypeConsultationDeclarationTypeID == 0)
                {
                    db.TypeConsultationDeclarationTypes.Add(dbItem);
                }
                else
                {
                    db.TypeConsultationDeclarationTypes.Attach(dbItem);
                    db.Entry(dbItem).State = EntityState.Modified;
                }
            }

            List<int> deletedItems = new List<int>();
            foreach (var itm2 in db.TypeConsultationDeclarationTypes.Where(p => p.TypeConsultationID == item.TypeConsultationID))
            {
                deletedItems.Add(itm2.TypeConsultationDeclarationTypeID);
            }

            List<int> common = deletedItems.Except(existingItems).ToList();
            foreach (int deletionID in common)
            {
                db.TypeConsultationDeclarationTypes.Remove(db.TypeConsultationDeclarationTypes.Find(deletionID));
            }


            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpTypeConsultationDeclarationTypes.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpTypeConsultationDeclarationTypes.Remove(db.TmpTypeConsultationDeclarationTypes.Find(ID));
            }
            return true;
        }
        private bool InsertRight(TypeConsultationItem item, TypeConsultation entity)
        {
            foreach (var itm in db.TmpTypeConsultationRights.Where(p => p.GUID == item.GUID))
            {
                TypeConsultationRight dbItem = new TypeConsultationRight
                {
                    TypeConsultation = entity,
                    HumanRightID = itm.HumanRightID,
                    TypeConsultationID = itm.TypeConsultationID,
                    TypeConsultationRightID = itm.TypeConsultationRightID
                };
                db.TypeConsultationRights.Add(dbItem);
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpTypeConsultationRights.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpTypeConsultationRights.Remove(db.TmpTypeConsultationRights.Find(ID));
            }
            return true;
        }
        private bool UpdateRight(TypeConsultationItem item, TypeConsultation entity)
        {
            List<int> existingItems = new List<int>();
            foreach (var itm in db.TmpTypeConsultationRights.Where(p => p.GUID == item.GUID))
            {
                existingItems.Add(itm.TypeConsultationRightID);
                TypeConsultationRight dbItem = new TypeConsultationRight
                {
                    TypeConsultation = entity,
                    HumanRightID = itm.HumanRightID,
                    TypeConsultationID = itm.TypeConsultationID,
                    TypeConsultationRightID = itm.TypeConsultationRightID
                };

                if (itm.TypeConsultationRightID == 0)
                {
                    db.TypeConsultationRights.Add(dbItem);
                }
                else
                {
                    db.TypeConsultationRights.Attach(dbItem);
                    db.Entry(dbItem).State = EntityState.Modified;
                }
            }

            List<int> deletedItems = new List<int>();
            foreach (var itm2 in db.TypeConsultationRights.Where(p => p.TypeConsultationID == item.TypeConsultationID))
            {
                deletedItems.Add(itm2.TypeConsultationRightID);
            }

            List<int> common = deletedItems.Except(existingItems).ToList();
            foreach (int deletionID in common)
            {
                db.TypeConsultationRights.Remove(db.TypeConsultationRights.Find(deletionID));
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpTypeConsultationRights.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpTypeConsultationRights.Remove(db.TmpTypeConsultationRights.Find(ID));
            }
            return true;
        }
        private bool InsertPermission(TypeConsultationItem item, TypeConsultation entity)
        {
            foreach (var itm in db.TmpTypeConsultationPermissions.Where(p => p.GUID == item.GUID))
            {
                TypeConsultationPermission dbItem = new TypeConsultationPermission
                {
                    TypeConsultation = entity,
                    UserID = itm.UserID,
                    IsChange = itm.IsChange,
                    IsRead = itm.IsRead,
                    TypeConsultationID = itm.TypeConsultationID,
                    TypeConsultationPermissionID = itm.TypeConsultationPermissionID
                };
                db.TypeConsultationPermissions.Add(dbItem);
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpTypeConsultationPermissions.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpTypeConsultationPermissions.Remove(db.TmpTypeConsultationPermissions.Find(ID));
            }
            return true;
        }
        private bool UpdatePermission(TypeConsultationItem item, TypeConsultation entity)
        {
            List<int> existingItems = new List<int>();
            foreach (var itm in db.TmpTypeConsultationPermissions.Where(p => p.GUID == item.GUID))
            {
                existingItems.Add(itm.TypeConsultationPermissionID);
                TypeConsultationPermission dbItem = new TypeConsultationPermission
                {
                    TypeConsultation = entity,
                    UserID = itm.UserID,
                    IsChange = itm.IsChange,
                    IsRead = itm.IsRead,
                    TypeConsultationID = itm.TypeConsultationID,
                    TypeConsultationPermissionID = itm.TypeConsultationPermissionID
                };

                if (itm.TypeConsultationPermissionID == 0)
                {
                    db.TypeConsultationPermissions.Add(dbItem);
                }
                else
                {
                    db.TypeConsultationPermissions.Attach(dbItem);
                    db.Entry(dbItem).State = EntityState.Modified;
                }
            }

            List<int> deletedItems = new List<int>();
            foreach (var itm2 in db.TypeConsultationPermissions.Where(p => p.TypeConsultationID == item.TypeConsultationID))
            {
                deletedItems.Add(itm2.TypeConsultationPermissionID);
            }

            List<int> common = deletedItems.Except(existingItems).ToList();
            foreach (int deletionID in common)
            {
                db.TypeConsultationPermissions.Remove(db.TypeConsultationPermissions.Find(deletionID));
            }

            List<int> deletionTempItems = new List<int>();
            foreach (var itm3 in db.TmpTypeConsultationPermissions.Where(p => p.GUID == item.GUID))
            {
                deletionTempItems.Add(itm3.ID);
            }
            foreach (int ID in deletionTempItems)
            {
                db.TmpTypeConsultationPermissions.Remove(db.TmpTypeConsultationPermissions.Find(ID));
            }
            return true;
        }
        private IList<TypeConsultationConsultantDetail> GetTypeConsultationConsultantDetail(int? typeConsultationID)
        {
            IList<TypeConsultationConsultantDetail> item = null;
            return item = (from occ in db.TypeConsultationConsultants
                           join c in db.Consultants on occ.ConsultantID equals c.ConsultantID into x
                           from z in x.DefaultIfEmpty()
                           where occ.TypeConsultationID == typeConsultationID
                           select new
                           {
                               TypeConsultationInstanceTable = occ,
                               OrganizationTable = z
                           })
                           .Select(list => new TypeConsultationConsultantDetail
                           {
                               TypeConsultationConsultantID = list.TypeConsultationInstanceTable.TypeConsultationConsultantID,
                               TypeConsultationID = list.TypeConsultationInstanceTable.TypeConsultationID,
                               ConsultantID = list.TypeConsultationInstanceTable.ConsultantID,
                               ConsultantName = list.OrganizationTable.FirstName + " " + list.OrganizationTable.LastName
                           }).ToList();
        }
        private IList<TypeConsultationInstanceDetail> GetTypeConsultationInstanceDetail(int? typeConsultationID)
        {
            IList<TypeConsultationInstanceDetail> item = null;
            return item = (from occ in db.TypeConsultationInstances
                           join c in db.Organizations on occ.OrganizationID equals c.OrganizationID into x
                           from z in x.DefaultIfEmpty()
                           where occ.TypeConsultationID == typeConsultationID
                           select new
                           {
                               TypeConsultationInstanceTable = occ,
                               OrganizationTable = z
                           })
                           .Select(list => new TypeConsultationInstanceDetail
                           {
                               TypeConsultationInstanceID = list.TypeConsultationInstanceTable.TypeConsultationInstanceID,
                               TypeConsultationID = list.TypeConsultationInstanceTable.TypeConsultationID,
                               OrganizationID = list.TypeConsultationInstanceTable.OrganizationID,
                               OrganizationName = list.OrganizationTable.OrganizationName
                           }).ToList();
        }
        private IList<TypeConsultationDeclarationTypeDetail> GetTypeConsultationDeclarationTypeDetail(int? typeConsultationID)
        {
            IList<TypeConsultationDeclarationTypeDetail> item = null;
            return item = (from target in db.TypeConsultationDeclarationTypes
                           join t1 in db.DeclarationTypes on target.DeclarationTypeID equals t1.DeclarationTypeID into r1
                           from declarationtype in r1.DefaultIfEmpty()
                           join t2 in db.Organizations on target.OrganizationID equals t2.OrganizationID into r2
                           from organization in r2.DefaultIfEmpty()
                           join t3 in db.ResponseTypes on target.ResponseTypeID equals t3.ResponseTypeID into r3
                           from responsetype in r3.DefaultIfEmpty()
                           //join t4 in db.ResponseContents on target.ResponseContentID equals t4.ResponseContentID into r4
                           //from responsecontent in r4.DefaultIfEmpty()
                           join t5 in db.ResponseQualities on target.ResponseQualityID equals t5.ResponseQualityID into r5
                           from responsequality in r5.DefaultIfEmpty()
                           where target.TypeConsultationID == typeConsultationID
                           select new
                           {
                               TargetTable = target,
                               DeclarationTypeTable = declarationtype,
                               OrganizationTable = organization,
                               ResponseTypeTable = responsetype,
                               //ResponseContentTable = responsecontent,
                               ResponseQualityTable = responsequality
                           })
                           .Select(list => new TypeConsultationDeclarationTypeDetail
                           {
                               TypeConsultationDeclarationTypeID = list.TargetTable.TypeConsultationDeclarationTypeID,
                               TypeConsultationID = list.TargetTable.TypeConsultationID,
                               DeclarationTypeID = list.TargetTable.DeclarationTypeID,
                               OrganizationID = list.TargetTable.OrganizationID,
                               ResponseTypeID = list.TargetTable.ResponseTypeID,
                               //ResponseContentID = list.TargetTable.ResponseContentID,
                               ResponseQualityID = list.TargetTable.ResponseQualityID,
                               DeclarationURL = list.TargetTable.DeclarationURL,
                               DeclarationDeadline = list.TargetTable.DeclarationDeadline,
                               DeclarationDate = list.TargetTable.DeclarationDate,
                               ResponseDate = list.TargetTable.ResponseDate,
                               DeclarationTypeName = list.DeclarationTypeTable.DeclarationTypeName,
                               OrganizationName = list.OrganizationTable.OrganizationName,
                               ResponseTypeName = list.ResponseTypeTable.ResponseTypeName,
                               ResponseContentName = list.TargetTable.ResponseContent,
                               ResponseQualityName = list.ResponseQualityTable.ResponseQualityName
                           }).ToList();
        }
        private IList<TypeConsultationRecipientDetail> GetTypeConsultationRecipientDetail(int? typeConsultationID)
        {
            IList<TypeConsultationRecipientDetail> item = null;
            return item = (from occ in db.TypeConsultationRecipients
                           join c in db.Organizations on occ.OrganizationID equals c.OrganizationID into x
                           from z in x.DefaultIfEmpty()
                           where occ.TypeConsultationID == typeConsultationID
                           select new
                           {
                               TypeConsultationRecipientTable = occ,
                               OrganizationTable = z
                           })
                           .Select(list => new TypeConsultationRecipientDetail
                           {
                               TypeConsultationRecipientID = list.TypeConsultationRecipientTable.TypeConsultationRecipientID,
                               TypeConsultationID = list.TypeConsultationRecipientTable.TypeConsultationID,
                               RecipientDate = list.TypeConsultationRecipientTable.RecipientDate,
                               OrganizationID = list.TypeConsultationRecipientTable.OrganizationID,
                               OrganizationName = list.OrganizationTable.OrganizationName
                           }).ToList();
        }
        private IList<TypeConsultationRightDetail> GetTypeConsultationRightDetail(int? typeConsultationID)
        {
            IList<TypeConsultationRightDetail> item = null;
            return item = (from occ in db.TypeConsultationRights
                           join c in db.HumanRights on occ.HumanRightID equals c.HumanRightID into x
                           from z in x.DefaultIfEmpty()
                           where occ.TypeConsultationID == typeConsultationID
                           select new
                           {
                               TypeConsultationRightTable = occ,
                               OrganizationTable = z
                           })
                           .Select(list => new TypeConsultationRightDetail
                           {
                               TypeConsultationRightID = list.TypeConsultationRightTable.TypeConsultationRightID,
                               TypeConsultationID = list.TypeConsultationRightTable.TypeConsultationID,
                               HumanRightID = list.TypeConsultationRightTable.HumanRightID,
                               HumanRightName = list.OrganizationTable.HumanRightName
                           }).ToList();
        }

    }
}
