using System;
using System.Linq;

namespace eLConsultation.Data
{
    public class SmtpSettingService : SettingService
    {
        private const string SettingGroup = "email";
        private const string Server = "server";
        private const string Password = "password";
        private const string Email = "email";
        private const string Port = "port";
        private const string DeliveryMethod = "deliverymethod";
        private const string UseDefaultCredentials = "usedefaultcredentials";
        private const string EnableSsl = "enablessl";

        public SmtpSettingService()
            : base()
        {

        }

        public SmtpSetting GetSmtpSetting()
        {
            var setting = new SmtpSetting();
            
            var smtpSetting = db.Settings.Where(p => p.SettingGroup == SettingGroup);

            foreach (var item in smtpSetting)
            {
                switch (item.SettingItem)
                {
                    case Server:
                        setting.Server = item.SettingValue;
                        break;
                    case Password:
                        setting.Password = item.SettingValue;
                        break;
                    case Email:
                        setting.Email = item.SettingValue;
                        break;
                    case Port:
                        setting.Port = item.SettingValue;
                        break;
                    case DeliveryMethod:
                        setting.DeliveryMethod = Convert.ToInt32(item.SettingValue);
                        break;
                    case UseDefaultCredentials:
                        setting.UseDefaultCredentials = Convert.ToBoolean(item.SettingValue);
                        break;
                    case EnableSsl:
                        setting.EnableSsl = Convert.ToBoolean(item.SettingValue);
                        break;
                    default:
                        break;
                }
            }

            return setting;
        }

        public SmtpSetting SetSmtpSetting(SmtpSetting item)
        {
            this.SetSetting(Server, SettingGroup, item.Server);
            this.SetSetting(Password, SettingGroup, item.Password);
            this.SetSetting(Email, SettingGroup, item.Email);
            this.SetSetting(Port, SettingGroup, item.Port.ToString());
            this.SetSetting(DeliveryMethod, SettingGroup, item.DeliveryMethod.ToString());
            this.SetSetting(UseDefaultCredentials, SettingGroup, item.UseDefaultCredentials.ToString());
            this.SetSetting(EnableSsl, SettingGroup, item.EnableSsl.ToString());

            db.SaveChanges();

            var smtpSetting = GetSmtpSetting();

            return smtpSetting;
        }
    }
}
