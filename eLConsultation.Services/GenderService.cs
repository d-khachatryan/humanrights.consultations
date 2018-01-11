using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class GenderService : ServiceBase
    {
        public GenderService()
            : base()
        {

        }
        public IList<GenderItem> GetGenders()
        {
            IList<GenderItem> result = new List<GenderItem>();

            result = db.Genders.Select(product => new GenderItem
            {
                GenderID = product.GenderID,
                GenderName = product.GenderName
            }).ToList();
            return result;
        }

        public void CreateGender(GenderItem genderItem)
        {
            var entity = new Gender
            {
                GenderName = genderItem.GenderName
            };
            db.Genders.Add(entity);
            db.SaveChanges();
            genderItem.GenderID = entity.GenderID;
        }

        public void UpdateGender(GenderItem genderItem)
        {
            var entity = new Gender
            {
                GenderID = genderItem.GenderID,
                GenderName = genderItem.GenderName
            };
            db.Genders.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteGender(GenderItem genderItem)
        {
            var entity = new Gender
            {
                GenderID = genderItem.GenderID
            };
            db.Genders.Attach(entity);
            db.Genders.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
