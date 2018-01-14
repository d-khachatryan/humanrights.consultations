using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Transactions;
using System.Threading.Tasks;
using eLConsultation.Data;

namespace eLConsultation.Data
{
    public class UserService
    {
        private string strErrorMessage;
        private Exception serviceException;
        private readonly UserContext context = new UserContext();

        private const string _administrator = "administrator";
        private const string _reader = "reader";
        private const string _writer = "writer";
        private const string _reportspecialist = "reportspecialist";

        public string ErrorMessage
        {
            get
            {
                return strErrorMessage;
            }

        }

        public Exception ServiceException
        {
            get
            {
                return serviceException;
            }

        }

        public IQueryable<IdentityUserItem> SelectUsers()
        {
            return context.Users;
        }

        public UserItem InitInsert()
        {
            try
            {
                var item = new UserItem
                {
                    UserItemRoles = context.Roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList()
                };

                foreach (var itm in item.UserItemRoles)
                {
                    if (itm.Text == _administrator)
                    {
                        itm.Text = "Ադմինիստրատոր";
                    }
                    if (itm.Text == _reader)
                    {
                        itm.Text = "Դիտորդ";
                    }
                    if (itm.Text == _writer)
                    {
                        itm.Text = "Տվյալների մուտքագրող";
                    }
                    if (itm.Text == _reportspecialist)
                    {
                        itm.Text = "Հաշվետվությունների մասնագետ";
                    }
                }


                return item;
            }
            catch (Exception ex)
            {
                serviceException = ex;
                return null;
            }
        }

        public int Insert(UserItem userItem, IOwinContext owinContext, HttpRequestBase Request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    InstanceUserManager instanceUserManager = owinContext.GetUserManager<InstanceUserManager>();

                    var user = new IdentityUserItem
                    {
                        UserName = userItem.UserName,
                        Email = userItem.Email,
                        FirstName = userItem.FirstName,
                        LastName = userItem.LastName,
                    };

                    IdentityResult result = instanceUserManager.Create(user, userItem.Password);

                    if (result.Succeeded)
                    {
                        foreach (string item in userItem.UserItemSelectedRoles)
                        {
                            var roles = context.Roles.ToList();

                            if (roles.Count() > 0)
                            {
                                foreach (IdentityRole identityRole in roles)
                                {
                                    if (identityRole.Name == item)
                                    {
                                        instanceUserManager.AddToRole(user.Id, identityRole.Name);
                                    }
                                };
                            }
                        }

                        string code = instanceUserManager.GenerateEmailConfirmationToken(user.Id);
                        string callbackUrl = new UrlHelper(Request.RequestContext).Action("ConfirmEmail", "Login", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        instanceUserManager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking this link " + callbackUrl);
                        scope.Complete();
                        return 1;
                    }
                    else
                    {
                        userItem.UserItemRoles = context.Roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                        foreach (var error in result.Errors)
                        {
                            strErrorMessage = ErrorMessage + " " + error;
                        }
                        scope.Dispose();
                        return 0;
                    }

                }
                catch (Exception ex)
                {
                    serviceException = ex;
                    userItem.UserItemRoles = context.Roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                    if (ex.Message != null)
                    {
                        strErrorMessage = ex.Message;
                    }
                    else
                    {
                        strErrorMessage = ex.InnerException.Message;
                    }
                    scope.Dispose();
                    return -1;
                }
            }
        }

        public UpdateUserItem InitUpdate(string Id)
        {
            try
            {
                var item = new UpdateUserItem();
                IdentityUserItem applicationUser = context.Users.Find(Id);
                item.Id = applicationUser.Id;
                item.UserName = applicationUser.UserName;
                item.Email = applicationUser.Email;
                item.FirstName = applicationUser.FirstName;
                item.LastName = applicationUser.LastName;

                item.UserItemRoles = context.Roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

                foreach (IdentityUserRole itm in applicationUser.Roles)
                {
                    item.UserItemSelectedRoles.Add(itm.RoleId);
                }

                foreach (var role in item.UserItemRoles)
                {
                    if (role.Text == _administrator)
                    {
                        role.Text = "Ադմինիստրատոր";
                    }
                    if (role.Text == _reader)
                    {
                        role.Text = "Դիտորդ";
                    }
                    if (role.Text == _writer)
                    {
                        role.Text = "Տվյալների մուտքագրող";
                    }
                    if (role.Text == _reportspecialist)
                    {
                        role.Text = "Հաշվետվությունների մասնագետ";
                    }
                }

                if (item != null)
                {
                    return item;
                }
                else
                {
                    throw new System.NullReferenceException("Requested item is not found");
                }
            }
            catch (Exception ex)
            {
                serviceException = ex;
                return null;
            }
        }

        public int Update(UpdateUserItem updateUserItem, IOwinContext owinContext)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    InstanceUserManager instanceUserManager = owinContext.GetUserManager<InstanceUserManager>();

                    IdentityUserItem identityUserItem = instanceUserManager.FindById(updateUserItem.Id.ToString());

                    if (updateUserItem != null)
                    {
                        identityUserItem.Email = updateUserItem.Email;
                        identityUserItem.UserName = updateUserItem.UserName;
                        identityUserItem.FirstName = updateUserItem.FirstName;
                        identityUserItem.LastName = updateUserItem.LastName;

                        IdentityResult result = instanceUserManager.Update(identityUserItem);

                        if (result.Succeeded)
                        {
                            //this part is not similar to create need more investigation
                            foreach (string item in updateUserItem.UserItemSelectedRoles)
                            {
                                string roleName = context.Roles.Find(item).Name; //sometimes this part not works, may be the context is not initialized?
                                instanceUserManager.AddToRole(identityUserItem.Id, roleName);
                            }

                            List<IdentityUserRole> listIdentityUserRole = instanceUserManager.FindById(identityUserItem.Id).Roles.ToList();

                            foreach (IdentityUserRole item in listIdentityUserRole)
                            {
                                if (!updateUserItem.UserItemSelectedRoles.Contains(item.RoleId))
                                {
                                    string roleToRemove = context.Roles.Find(item.RoleId).Name;
                                    instanceUserManager.RemoveFromRole(identityUserItem.Id, roleToRemove);
                                }
                            }
                            scope.Complete();
                            return 1;
                        }
                        else
                        {
                            updateUserItem.UserItemRoles = context.Roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                            foreach (var error in result.Errors)
                            {
                                strErrorMessage = ErrorMessage + " " + error;
                            }
                            scope.Dispose();
                            return 0;
                        }
                    }
                    else
                    {
                        updateUserItem.UserItemRoles = context.Roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                        strErrorMessage = "There is no user with provided ID";
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    serviceException = ex;
                    updateUserItem.UserItemRoles = context.Roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                    if (ex.Message != null)
                    {
                        strErrorMessage = ex.Message;
                    }
                    else
                    {
                        strErrorMessage = ex.InnerException.Message;
                    }
                    scope.Dispose();
                    return -1;
                }
            }
        }

        public int Delete(string Id, IOwinContext owinContext)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    InstanceUserManager instanceUsermanager = owinContext.GetUserManager<InstanceUserManager>();

                    IdentityUserItem identityUserItem = instanceUsermanager.FindById(Id);

                    ICollection<IdentityUserLogin> logins = identityUserItem.Logins;
                    foreach (var login in logins.ToList())
                    {
                        instanceUsermanager.RemoveLogin(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                    }

                    IList<string> rolesForUser = instanceUsermanager.GetRoles(Id);
                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            IdentityResult result = instanceUsermanager.RemoveFromRole(identityUserItem.Id, item);
                        }
                    }

                    IdentityResult userResult = instanceUsermanager.Delete(identityUserItem);

                    if (userResult.Succeeded)
                    {
                        scope.Complete();
                        return 1;
                    }
                    else
                    {
                        scope.Dispose();
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    serviceException = ex;
                    scope.Dispose();
                    return -1;
                }
            }
        }

        public async Task<LoginStatus> Login(IOwinContext owinContext, HttpRequestBase Request, LoginItem model)
        {
            try
            {
                InstanceUserManager instanceUserManager = owinContext.GetUserManager<InstanceUserManager>();
                InstanceSignInManager instanceSignInManager = owinContext.GetUserManager<InstanceSignInManager>();
                IdentityUserItem signedUser = instanceUserManager.FindByEmail(model.Email);
                var result = await instanceSignInManager.PasswordSignInAsync(signedUser.UserName, model.Password, model.RememberMe, shouldLockout: true);
                switch (result)
                {
                    case SignInStatus.Success:
                        var currentUser = await instanceUserManager.FindByNameAsync(signedUser.UserName);
                        if (!await instanceUserManager.IsEmailConfirmedAsync(currentUser.Id))
                        {
                            var code = await instanceUserManager.GenerateEmailConfirmationTokenAsync(currentUser.Id);
                            var callbackUrl = new UrlHelper(Request.RequestContext).Action("ConfirmEmail", "Login", new { userId = currentUser.Id, code = code }, protocol: Request.Url.Scheme);
                            instanceUserManager.SendEmail(currentUser.Id, "Confirm your account", "Please confirm your account by clicking this link " + callbackUrl);
                            return LoginStatus.RequireConfirmation;
                        }
                        else
                        {
                            return LoginStatus.Success;
                        }
                    case SignInStatus.LockedOut:
                        return LoginStatus.LockedOut;
                    case SignInStatus.Failure:
                        return LoginStatus.Failure;
                    default:
                        return LoginStatus.Failure;
                }
            }
            catch (Exception ex)
            {
                serviceException = ex;
                return LoginStatus.SystemFailure;
            }
        }

        public async Task<int> ForgotPassword(IOwinContext owinContext, HttpRequestBase Request, ForgotPasswordItem model)
        {
            try
            {
                InstanceUserManager instanceUserManager = owinContext.GetUserManager<InstanceUserManager>();
                var user = await instanceUserManager.FindByEmailAsync(model.Email);
                if (user == null || !(await instanceUserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    //return View("ForgotPasswordConfirmation");
                    return 0;
                }
                string code = await instanceUserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = new UrlHelper(Request.RequestContext).Action("ResetPassword", "Login", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                //var callbackUrl = Url.Action("ResetPassword", "Login", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await instanceUserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking this link " + callbackUrl);
                //return RedirectToAction("ForgotPasswordConfirmation", "Login");
                return 1;
            }
            catch (Exception ex)
            {
                serviceException = ex;
                //return LoginStatus.SystemFailure;
                return -1;
            }
        }

        public async Task<int> ResetPassword(IOwinContext owinContext, HttpRequestBase Request, ResetPasswordItem model)
        {
            try
            {
                InstanceUserManager instanceUserManager = owinContext.GetUserManager<InstanceUserManager>();
                IdentityUserItem user = await instanceUserManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    IdentityResult result = await instanceUserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
                    if (result.Succeeded)
                    {
                        return 1;
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            strErrorMessage = strErrorMessage + " " + error;
                        }
                        return 2;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                serviceException = ex;
                return -1;
            }
        }

        public bool IsUserInRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var role = roleManager.FindByName(roleName);
            if (role.Users.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
