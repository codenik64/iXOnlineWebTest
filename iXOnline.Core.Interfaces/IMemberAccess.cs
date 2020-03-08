using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnline.Core.Interfaces
{
    public interface IMemberAccess
    {
        IQueryable<UserAccessTable> GetUserAccess();
        IQueryable<UserAccessTable> GetAllUserAccess();

        void EnableUserAccess(UserAccessTable AccessTable);
    }
}
