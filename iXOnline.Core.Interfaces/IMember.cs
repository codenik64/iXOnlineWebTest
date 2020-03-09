using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnline.Core.Interfaces
{
    public interface IMember
    {
        IQueryable<Members> GetData();
        IQueryable<Members> GetAll();
         void Insert(Members Member);
         void AccountViewModelInsert(Members Member);
         void UpdateMember(Members members);
         void RemoveMember(int Id);
         Members FindById(int Id);

    }
}
