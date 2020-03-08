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
    public class PermissionsBLL : IPermission
    {
         readonly iXOnlineWebEntities dbContext;
         CRUDRepository<Permission> PermissionRepo;
        ErrorLogBLL Error;

        public PermissionsBLL()
        {
            dbContext = new iXOnlineWebEntities();
            PermissionRepo = new CRUDRepository<Permission>();
            Error = new ErrorLogBLL();
        }

        public IQueryable<Permission> GetPermission()
        {
            var permission = PermissionRepo.GetAll();
            return permission;
        }

        public IQueryable<Permission> GetAllPermission()
        {
            var AllSelected = GetPermission().Select(x => new Permission
            {
                UserGuidId = x.UserGuidId,
                UserGuid = x.UserGuid,
                UserRole = x.UserRole,
                UserRoleId = x.UserRoleId,
                DateEnrolled = x.DateEnrolled,
                MemberEnrolled = x.MemberEnrolled
            }).ToList();

            return AllSelected.AsQueryable();
        }

        public void InsertPermission(Permission UserPermission)
        {
            try
            {
                Guid RandomGuid = Guid.NewGuid();
                Permission permit = new Permission
                {
                    UserGuid = RandomGuid.ToString(),
                    UserRole = UserPermission.UserRole,
                    UserRoleId = -999,
                    DateEnrolled = DateTime.Now,
                    MemberEnrolled = "Nick"
                };

                IdentityHelper.CreateUserPermission(permit.UserRole, permit.UserGuid);

                PermissionRepo.Insert(permit);
                PermissionRepo.Save();
            }
            catch (Exception ex)
            {
                Error.InsertError(ex);
            }
            
        }

    }
}
