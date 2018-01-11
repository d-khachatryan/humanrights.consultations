using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationPermissionService
    {
        private StoreContext db;
        private Exception exception;

        public OralConsultationPermissionService(StoreContext context)
        {
            db = context;
        }

        public IList<AspNetUsers> UserList()
        {
            using (var db = new StoreContext())
            {
                IList<AspNetUsers> list = db.AspNetUsers.ToList();
                return list;
            }
        }
        public IList<OralConsultationPermissionItem> SelectPermissions(string prmGUID)
        {
            IList<OralConsultationPermissionItem> result = new List<OralConsultationPermissionItem>();
            result = db.TmpOralConsultationPermissions.Join
                (db.AspNetUsers, c => c.UserID, cm => cm.Id,
                    (c, cm) => new { TmpOralConsultationPermission = c, AspNetUsers = cm }
                )
                .Where(c => c.TmpOralConsultationPermission.GUID == new Guid(prmGUID))
                .Select(list => new OralConsultationPermissionItem
                {
                    ID = list.TmpOralConsultationPermission.ID,
                    GUID = new Guid(prmGUID),
                    OralConsultationPermissionID = list.TmpOralConsultationPermission.OralConsultationPermissionID,
                    OralConsultationID = list.TmpOralConsultationPermission.OralConsultationID,
                    UserID = list.TmpOralConsultationPermission.UserID,
                    UserName = list.AspNetUsers.FirstName + " " + list.AspNetUsers.LastName,
                    IsRead = list.TmpOralConsultationPermission.IsRead,
                    IsChange = list.TmpOralConsultationPermission.IsChange
                }).ToList();
            return result;
        }

        public OralConsultationPermissionItem InsertPermission(OralConsultationPermissionItem item)
        {
            try
            {
                TmpOralConsultationPermission entity = new TmpOralConsultationPermission
                {
                    OralConsultationPermissionID = 0,
                    OralConsultationID = item.OralConsultationID,
                    UserID = item.UserID,
                    IsRead = item.IsRead,
                    IsChange = item.IsChange,
                    GUID = item.GUID
                };

                db.TmpOralConsultationPermissions.Add(entity);

                db.SaveChanges();

                item.ID = entity.ID;
                item.OralConsultationPermissionID = entity.OralConsultationPermissionID;
                AspNetUsers user = db.AspNetUsers.Find(item.UserID);
                item.UserName = user.FirstName + " " + user.LastName;

                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public OralConsultationPermissionItem UpdatePermission(OralConsultationPermissionItem item)
        {
            try
            {
                TmpOralConsultationPermission entity = new TmpOralConsultationPermission
                {
                    ID = item.ID,
                    OralConsultationPermissionID = item.OralConsultationPermissionID,
                    OralConsultationID = item.OralConsultationID,
                    UserID = item.UserID,
                    IsRead = item.IsRead,
                    IsChange = item.IsChange,
                    GUID = item.GUID
                };

                db.TmpOralConsultationPermissions.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;

                db.SaveChanges();

                AspNetUsers user = db.AspNetUsers.Find(item.UserID);
                item.UserName = user.FirstName + " " + user.LastName;
                return item;
            }
            catch (Exception ex)
            {
                exception = ex;
                return null;
            }
        }

        public OralConsultationPermissionItem DeletePermission(OralConsultationPermissionItem item)
        {
            try
            {
                TmpOralConsultationPermission entity = new TmpOralConsultationPermission
                {
                    ID = item.ID,
                    OralConsultationPermissionID = item.OralConsultationPermissionID,
                    OralConsultationID = item.OralConsultationID,
                    UserID = item.UserID,
                    IsRead = item.IsRead,
                    IsChange = item.IsChange,
                    GUID = item.GUID
                };

                db.TmpOralConsultationPermissions.Attach(entity);
                db.TmpOralConsultationPermissions.Remove(entity);

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
