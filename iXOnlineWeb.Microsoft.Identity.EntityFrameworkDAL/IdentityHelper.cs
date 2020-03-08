using iXOnlineWeb.Data.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnlineWeb.Microsoft.Identity.EntityFrameworkDAL
{
    public static class IdentityHelper
    {
        public static void AddIdentityUser(string EmailAddress , string MemberPassword)
        {
            try
            {
                #region Declare Manager
                var IdentityManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IXOnlineDbContext()));
                #endregion

                var UserAccount = EmailAddress;
                var ExistingUser = IdentityManager.FindByName(UserAccount);
                if (ExistingUser == null)
                {
                    #region instance of AspNetUser
                    var Member = new ApplicationUser();

                    Member.Email = EmailAddress;
                    Member.UserName = EmailAddress;
                    string Password = MemberPassword;
                    #endregion

                    var IdentityUser = IdentityManager.Create(Member, Password);

                }
            }
            catch (Exception identityException)

            {
                var Exception = identityException.Message;
                string CustomError = "the user being  created already exists in the database";
                Exception = CustomError.ToString();


            }
        }


        public static void CreateUserPermission(string UserRole, string GlobalId)
        {

            using (iXOnlineWebEntities dbContext = new iXOnlineWebEntities())
            {
                AspNetRole permission = new AspNetRole
                {
                    Id = GlobalId.ToString(),
                    Name = UserRole
                };

                dbContext.AspNetRoles.Add(permission);
                dbContext.SaveChanges();
            }
        }


        public static void AddUserToRole(string UserGuid, string RoleGuid)
        {
            using (iXOnlineWebEntities dbContext = new iXOnlineWebEntities())
            {
                var IdentityManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IXOnlineDbContext()));
                IdentityManager.AddToRole(UserGuid, RoleGuid);

            }
        }
    }
}
