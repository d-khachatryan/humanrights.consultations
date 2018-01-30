using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class TypeConsultationDeclarationTypeService : ServiceBase
    {

        public TypeConsultationDeclarationTypeService()
            : base()
        {

        }

        public List<SelectListItem> GetDeclarationTypeDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            DeclarationTypeService listItem = new DeclarationTypeService();
            selectedListItem = listItem.GetDeclarationTypes().Select(x => new SelectListItem { Text = x.DeclarationTypeName, Value = x.DeclarationTypeID.ToString() }).ToList();
            return selectedListItem;
        }
        public List<SelectListItem> GetOrganizationDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            OrganizationService listItem = new OrganizationService();
            selectedListItem = listItem.GetOrganizations().Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationID.ToString() }).ToList();
            return selectedListItem;
        }
        public List<SelectListItem> GetResponseTypeDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            ResponseTypeService listItem = new ResponseTypeService();
            selectedListItem = listItem.GetResponseTypes().Select(x => new SelectListItem { Text = x.ResponseTypeName, Value = x.ResponseTypeID.ToString() }).ToList();
            return selectedListItem;
        }
        public List<SelectListItem> GetResponseContentDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            ResponseContentService listItem = new ResponseContentService();
            selectedListItem = listItem.GetResponseContents().Select(x => new SelectListItem { Text = x.ResponseContentName, Value = x.ResponseContentID.ToString() }).ToList();
            return selectedListItem;
        }
        public List<SelectListItem> GetResponseQuantityDropDownItems()
        {
            var selectedListItem = new List<SelectListItem>();
            ResponseQualityService listItem = new ResponseQualityService();
            selectedListItem = listItem.GetResponseQualities().Select(x => new SelectListItem { Text = x.ResponseQualityName, Value = x.ResponseQualityID.ToString() }).ToList();
            return selectedListItem;
        }

        //public IList<DeclarationType> DeclarationTypeList()
        //{
        //    using (var db = new StoreContext())
        //    {
        //        IList<DeclarationType> list = db.DeclarationTypes.ToList();
        //        return list;
        //    }
        //}

        public IList<TypeConsultationDeclarationTypeItem> SelectDeclarationTypes(string prmGUID)
        {
            IList<TypeConsultationDeclarationTypeItem> result = new List<TypeConsultationDeclarationTypeItem>();

            result = (from target in db.TmpTypeConsultationDeclarationTypes
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
                      .Where(c => target.GUID == new Guid(prmGUID))
                      select new
                      {
                          TargetTable = target,
                          DeclarationTypeTable = declarationtype,
                          OrganizationTable = organization,
                          ResponseTypeTable = responsetype,
                          //ResponseContentTable = responsecontent,
                          ResponseQualityTable = responsequality
                      })
                .Select(list => new TypeConsultationDeclarationTypeItem
                {
                    ID = list.TargetTable.ID,
                    GUID = new Guid(prmGUID),
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
            return result;
        }

        public TypeConsultationDeclarationTypeItem InsertDeclarationType(TypeConsultationDeclarationTypeItem item)
        {
            try
            {
                TmpTypeConsultationDeclarationType entity = new TmpTypeConsultationDeclarationType
                {
                    TypeConsultationDeclarationTypeID = 0,
                    TypeConsultationID = item.TypeConsultationID,
                    DeclarationTypeID = item.DeclarationTypeID,
                    DeclarationURL = item.DeclarationURL,
                    DeclarationDeadline = item.DeclarationDeadline,
                    DeclarationDate = item.DeclarationDate,
                    OrganizationID = item.OrganizationID,
                    ResponseDate = item.ResponseDate,
                    ResponseTypeID = item.ResponseTypeID,
                    ResponseContent = item.ResponseContentName,
                    ResponseQualityID = item.ResponseQualityID,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationDeclarationTypes.Add(entity);

                db.SaveChanges();

                item.ID = entity.ID;
                item.TypeConsultationDeclarationTypeID = entity.TypeConsultationDeclarationTypeID;

                DeclarationType declarationType = db.DeclarationTypes.Find(item.DeclarationTypeID);
                Organization organization = db.Organizations.Find(item.OrganizationID);
                ResponseType responseType = db.ResponseTypes.Find(item.ResponseTypeID);
                ResponseContent responseContent = db.ResponseContents.Find(item.ResponseContentID);
                ResponseQuality responseQuality = db.ResponseQualities.Find(item.ResponseQualityID);

                //item.DeclarationTypeName = declarationType.DeclarationTypeName;
                //item.OrganizationName = organization.OrganizationName;
                //item.ResponseTypeName = responseType.ResponseTypeName;
                //item.ResponseContentName = responseContent.ResponseContentName;
                //item.ResponseQualityName = responseQuality.ResponseQualityName;

                if (item.DeclarationTypeID != null)
                {
                    item.DeclarationTypeName = declarationType.DeclarationTypeName;
                }
                if (item.OrganizationID != null)
                {
                    item.OrganizationName = organization.OrganizationName;
                }
                if (item.ResponseTypeID != null)
                {
                    item.ResponseTypeName = responseType.ResponseTypeName;
                }
                if (item.ResponseContentID != null)
                {
                    item.ResponseContentName = responseContent.ResponseContentName;
                }
                if (item.ResponseQualityID != null)
                {
                    item.ResponseQualityName = responseQuality.ResponseQualityName;
                }


                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public TypeConsultationDeclarationTypeItem UpdateDeclarationType(TypeConsultationDeclarationTypeItem item)
        {
            try
            {
                TmpTypeConsultationDeclarationType entity = new TmpTypeConsultationDeclarationType
                {
                    ID = item.ID,
                    TypeConsultationDeclarationTypeID = item.TypeConsultationDeclarationTypeID,
                    TypeConsultationID = item.TypeConsultationID,
                    DeclarationTypeID = item.DeclarationTypeID,
                    DeclarationURL = item.DeclarationURL,
                    DeclarationDeadline = item.DeclarationDeadline,
                    DeclarationDate = item.DeclarationDate,
                    OrganizationID = item.OrganizationID,
                    ResponseDate = item.ResponseDate,
                    ResponseTypeID = item.ResponseTypeID,
                    ResponseContent = item.ResponseContentName,
                    ResponseQualityID = item.ResponseQualityID,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationDeclarationTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;

                db.SaveChanges();

                DeclarationType declarationType = db.DeclarationTypes.Find(item.DeclarationTypeID);
                Organization organization = db.Organizations.Find(item.OrganizationID);
                ResponseType responseType = db.ResponseTypes.Find(item.ResponseTypeID);
                ResponseContent responseContent = db.ResponseContents.Find(item.ResponseContentID);
                ResponseQuality responseQuality = db.ResponseQualities.Find(item.ResponseQualityID);

                item.DeclarationTypeName = declarationType.DeclarationTypeName;
                item.OrganizationName = organization.OrganizationName;
                item.ResponseTypeName = responseType.ResponseTypeName;
                item.ResponseContentName = responseContent.ResponseContentName;
                item.ResponseQualityName = responseQuality.ResponseQualityName;

                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public TypeConsultationDeclarationTypeItem DeleteDeclarationType(TypeConsultationDeclarationTypeItem item)
        {
            try
            {
                TmpTypeConsultationDeclarationType entity = new TmpTypeConsultationDeclarationType
                {
                    ID = item.ID,
                    TypeConsultationDeclarationTypeID = item.TypeConsultationDeclarationTypeID,
                    TypeConsultationID = item.TypeConsultationID,
                    DeclarationTypeID = item.DeclarationTypeID,
                    DeclarationURL = item.DeclarationURL,
                    DeclarationDeadline = item.DeclarationDeadline,
                    DeclarationDate = item.DeclarationDate,
                    OrganizationID = item.OrganizationID,
                    ResponseDate = item.ResponseDate,
                    ResponseTypeID = item.ResponseTypeID,
                    ResponseContent = item.ResponseContentName,
                    ResponseQualityID = item.ResponseQualityID,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationDeclarationTypes.Attach(entity);
                db.TmpTypeConsultationDeclarationTypes.Remove(entity);

                db.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }
    }
}
