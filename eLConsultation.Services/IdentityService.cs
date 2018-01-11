using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using eLConsultation.Data;

namespace eLConsultation.Data
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            //return Task.FromResult(0);

            // Credentials:
            //string credentialUserName = "postmaster@dv-solutions.com";
            //string sentFrom = "postmaster@dv-solutions.com";
            //string pwd = "Temp`123";
            var db = new StoreContext();
            var smtpSettingService = new SmtpSettingService();
            var smtpSetting = smtpSettingService.GetSmtpSetting();
            string credentialUserName = smtpSetting.Email;
            string sentFrom = smtpSetting.Email;
            string pwd = smtpSetting.Password;
            //string credentialUserName = "hcav_databaze@hcav.am";
            //string sentFrom = "hcav_databaze@hcav.am";
            //string pwd = "HCAV123456";

            // Configure the client:
            //var client = new System.Net.Mail.SmtpClient("mail.dv-solutions.com");
            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(smtpSetting.Server);

            //client.Port = 8889;
            //client.Port = 587;
            client.Port = Int32.Parse(smtpSetting.Port);
            //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.DeliveryMethod = (System.Net.Mail.SmtpDeliveryMethod)smtpSetting.DeliveryMethod;

            //client.UseDefaultCredentials = false;
            client.UseDefaultCredentials = smtpSetting.UseDefaultCredentials;

            // Create the credentials:
            //var credentials = new System.Net.NetworkCredential(credentialUserName, pwd);
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(credentialUserName, pwd);

            //client.EnableSsl = false;
            //client.EnableSsl = true;
            client.EnableSsl = smtpSetting.EnableSsl;
            client.Credentials = credentials;

            // Create the message:
            var mail = new System.Net.Mail.MailMessage(sentFrom, message.Destination);

            mail.Subject = message.Subject;
            mail.Body = message.Body;

            // Send:
            await client.SendMailAsync(mail);

        }

    }

     // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class InstanceUserManager : UserManager<IdentityUserItem>
    {
        public InstanceUserManager(IUserStore<IdentityUserItem> store)
            : base(store)
        {
        }

        public static InstanceUserManager Create(IdentityFactoryOptions<InstanceUserManager> options, IOwinContext context)
        {
            var manager = new InstanceUserManager(new UserStore<IdentityUserItem>(context.Get<UserContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<IdentityUserItem>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<IdentityUserItem>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<IdentityUserItem>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<IdentityUserItem>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class InstanceSignInManager : SignInManager<IdentityUserItem, string>
    {
        public InstanceSignInManager(InstanceUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        //public override Task<ClaimsIdentity> CreateUserIdentityAsync(IdentityUserItem user)
        //{
        //    return user.GenerateUserIdentityAsync((InstanceUserManager)UserManager);
        //}

        public static InstanceSignInManager Create(IdentityFactoryOptions<InstanceSignInManager> options, IOwinContext context)
        {
            return new InstanceSignInManager(context.GetUserManager<InstanceUserManager>(), context.Authentication);
        }
    }
}
