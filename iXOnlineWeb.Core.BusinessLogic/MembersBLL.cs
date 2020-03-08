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
    public class MembersBLL : IMember
    {
        readonly iXOnlineWebEntities dbContext;
        ErrorLogBLL Error;
        CRUDRepository<Members> MemberRepo;
    
        public MembersBLL()
        {
            dbContext = new iXOnlineWebEntities();
            Error = new ErrorLogBLL();
            MemberRepo = new CRUDRepository<Members>();
      
        }

        public IQueryable<Members> GetData()
        {
            return MemberRepo.GetAll();
        }

        public IQueryable<Members> GetAll()
        {
            return GetData().Select(x => new Members
            {
                MemberId = x.MemberId,
                MemberName = x.MemberName,
                MemberSurname = x.MemberSurname,
                EmailAddress = x.EmailAddress,
                ContactNumber =x.ContactNumber,
                Gender = x.Gender,
                IsActive = x.IsActive
               
            }).ToList().AsQueryable();
        }

        public void Insert(Members Member)
        {
            try
            {

                #region Creating the Object
                Members User = new Members
                {
                    MemberId = Member.MemberId,
                    MemberName = Member.MemberName,
                    MemberSurname = Member.MemberSurname,
                    EmailAddress = Member.EmailAddress,
                    ContactNumber = Member.ContactNumber,
                    Gender = Member.Gender,
                    IsActive = Member.IsActive
                };
                var EmailAddress = Member.EmailAddress;
                var Password = "Passw0rd123*";
                #endregion

                IdentityHelper.AddIdentityUser(EmailAddress, Password);
                MemberRepo.Insert(User);
                MemberRepo.Save();

            }
            catch (Exception e) 
            {

                Error.InsertError(e);
            }
        }

        public void UpdateMember(Members members)
        {
            try
            {
                MemberRepo.Update(members);
                MemberRepo.Save();
            }

            catch (Exception ex)
            {
                Error.InsertError(ex);
            }
        }

        public void RemoveMember (int Id)
        {
            try
            {
                MemberRepo.Delete(Id);
                MemberRepo.Save();
            }
            catch (Exception ex)
            {
                Error.InsertError(ex);
            }
        }

        public Members FindById(int Id)
        {
            var FindMember = MemberRepo.GetById(Id);
            return FindMember;
        }

    }
}
