using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace eLConsultation.Data
{
    public class SettingService: ServiceBase
    {
        protected StoreContext db;
        public SettingService()
        {
            db = new StoreContext();
        }
        public SettingService(StoreContext context)
        {
            db = context;
        }

        public Setting GetSettingByItem(string settingItem)
        {
            if (String.IsNullOrEmpty(settingItem))
            {
                throw new ArgumentException(String.Format("{0} is not valid setting name", settingItem), "settingItem");
            }

            var setting = db.Settings.Find(settingItem);

            if (setting == null)
            {
                throw new NullReferenceException(String.Format("There is no setting with provided {0} name", settingItem));
            }

            return setting;
        }

        protected Setting SetSetting(string settingItem, string settingGroup, string settingValue)
        {
            var setting = db.Settings.Find(settingItem);
            
            if (setting == null)
            {
                Setting item = new Setting
                {
                    SettingItem = settingItem,
                    SettingGroup = settingGroup,
                    SettingValue = settingValue
                };
                db.Settings.Add(item);
                db.SaveChanges();
                return item;            }
            else
            {
                setting.SettingGroup = settingGroup;
                setting.SettingItem = settingItem;
                setting.SettingValue = settingValue;
                db.Settings.Attach(setting);
                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();
                return setting;
            }
        }

    }
}
