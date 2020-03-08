using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnline.Core.Interfaces
{
    public interface IPermission
    {
        IQueryable<Permission> GetPermission();
        IQueryable<Permission> GetAllPermission();
        void InsertPermission(Permission UserPermission);
    }
}
