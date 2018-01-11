using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationPermissionService
    {
        private StoreContext db;
        private Exception exception;

        public TypeConsultationPermissionService(StoreContext context)
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
        public IList<TypeConsultationPermissionItem> SelectPermissions(string prmGUID)
        {
            IList<TypeConsultationPermissionItem> result = new List<TypeConsultationPermissionItem>();
            result = db.TmpTypeConsultationPermissions.Join
                (db.AspNetUsers, c => c.UserID, cm => cm.Id,
                    (c, cm) => new { TmpTypeConsultationPermission = c, AspNetUsers = cm }
                )
                .Where(c => c.TmpTypeConsultationPermission.GUID == new Guid(prmGUID))
                .Select(list => new TypeConsultationPermissionItem
                {
                    ID = list.TmpTypeConsultationPermission.ID,
                    GUID = new Guid(prmGUID),
                    TypeConsultationPermissionID = list.TmpTypeConsultationPermission.TypeConsultationPermissionID,
                    TypeConsultationID = list.TmpTypeConsultationPermission.TypeConsultationID,
                    UserID = list.TmpTypeConsultationPermission.UserID,
                    IsRead = list.TmpTypeConsultationPermission.IsRead,
                    IsChange = list.TmpTypeConsultationPermission.IsChange,
                    UserName = list.AspNetUsers.FirstName + " " + list.AspNetUsers.LastName,
                }).ToList();
            return result;
        }

        public TypeConsultationPermissionItem InsertPermission(TypeConsultationPermissionItem item)
        {
            try
            {
                TmpTypeConsultationPermission entity = new TmpTypeConsultationPermission
                {
                    TypeConsultationPermissionID = 0,
                    TypeConsultationID = item.TypeConsultationID,
                    UserID = item.UserID,
                    IsRead = item.IsRead,
                    IsChange = item.IsChange,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationPermissions.Add(entity);

                db.SaveChanges();

                item.ID = entity.ID;
                item.TypeConsultationPermissionID = entity.TypeConsultationPermissionID;
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

        public TypeConsultationPermissionItem UpdatePermission(TypeConsultationPermissionItem item)
        {
            try
            {
                TmpTypeConsultationPermission entity = new TmpTypeConsultationPermission
                {
                    ID = item.ID,
                    TypeConsultationPermissionID = item.TypeConsultationPermissionID,
                    TypeConsultationID = item.TypeConsultationID,
                    UserID = item.UserID,
                    IsRead = item.IsRead,
                    IsChange = item.IsChange,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationPermissions.Attach(entity);
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

        public TypeConsultationPermissionItem DeletePermission(TypeConsultationPermissionItem item)
        {
            try
            {
                TmpTypeConsultationPermission entity = new TmpTypeConsultationPermission
                {
                    ID = item.ID,
                    TypeConsultationPermissionID = item.TypeConsultationPermissionID,
                    TypeConsultationID = item.TypeConsultationID,
                    UserID = item.UserID,
                    IsRead = item.IsRead,
                    IsChange = item.IsChange,
                    GUID = item.GUID
                };

                db.TmpTypeConsultationPermissions.Attach(entity);
                db.TmpTypeConsultationPermissions.Remove(entity);

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
