using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Data
{
    public class DeclarationTypeService : ServiceBase
    {
        public DeclarationTypeService()
            : base()
        {

        }
        public IList<DeclarationTypeItem> GetDeclarationTypes()
        {
            IList<DeclarationTypeItem> result = new List<DeclarationTypeItem>();

            result = db.DeclarationTypes.Select(product => new DeclarationTypeItem
            {
                DeclarationTypeID = product.DeclarationTypeID,
                DeclarationTypeName = product.DeclarationTypeName
            }).ToList();
            return result;
        }

        public void CreateDeclarationType(DeclarationTypeItem declarationTypeItem)
        {
            var entity = new DeclarationType
            {
                DeclarationTypeName = declarationTypeItem.DeclarationTypeName
            };
            db.DeclarationTypes.Add(entity);
            db.SaveChanges();
            declarationTypeItem.DeclarationTypeID = entity.DeclarationTypeID;
        }

        public void UpdateDeclarationType(DeclarationTypeItem declarationTypeItem)
        {
            var entity = new DeclarationType
            {
                DeclarationTypeID = declarationTypeItem.DeclarationTypeID,
                DeclarationTypeName = declarationTypeItem.DeclarationTypeName
            };
            db.DeclarationTypes.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteDeclarationType(DeclarationTypeItem declarationTypeItem)
        {
            var entity = new DeclarationType
            {
                DeclarationTypeID = declarationTypeItem.DeclarationTypeID
            };
            db.DeclarationTypes.Attach(entity);
            db.DeclarationTypes.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}