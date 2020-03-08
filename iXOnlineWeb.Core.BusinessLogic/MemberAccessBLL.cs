using iXOnline.Core.Interfaces;
using iXOnlineWeb.Data.DataAccess;
using iXOnlineWeb.Microsoft.Identity.EntityFrameworkDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnlineWeb.Core.BusinessLogic
{
    public class MemberAccessBLL : IMemberAccess
    {
        iXOnlineWebEntities dbContext;
        ErrorLogBLL Error;

        public MemberAccessBLL()
        {
            dbContext = new iXOnlineWebEntities();
            Error = new ErrorLogBLL();
        }

        public IQueryable<UserAccessTable> GetUserAccess()
        {
            return dbContext.UserAccessTables.ToList().AsQueryable();
        }

        public IQueryable<UserAccessTable> GetAllUserAccess()
        {
            return GetUserAccess().Select(x => new UserAccessTable
            {
                AccessId = x.AccessId,
                UserGuidId = x.UserGuidId,
                RoleGuidId = x.RoleGuidId,
                DateEnrolled = x.DateEnrolled,
                FunctionId = x.FunctionId,
                UserName = x.UserName,
                UserRevoked = x.UserRevoked
            }).ToList().AsQueryable();
        }

        public void EnableUserAccess(UserAccessTable AccessTable)
        {
            try
            {
                var userName = from a in dbContext.Members
                               join b in dbContext.AspNetUsers on a.EmailAddress equals b.Email
                               join c in dbContext.UserAccessTables on b.Id equals c.UserGuidId
                               select a.MemberName;
                UserAccessTable table = new UserAccessTable
                {
                    UserGuidId = AccessTable.UserGuidId,
                    RoleGuidId = AccessTable.RoleGuidId,
                    DateEnrolled = DateTime.Now,
                    UserName = "Nick",
                    FunctionId = -999,
                    UserRevoked = false
                };

                IdentityHelper.AddUserToRole(table.UserGuidId, table.RoleGuidId);

                dbContext.UserAccessTables.Add(table);
                dbContext.SaveChanges();
            }
            catch (Exception userException)
            {
                Error.InsertError(userException);
            }
        }
    }
}
