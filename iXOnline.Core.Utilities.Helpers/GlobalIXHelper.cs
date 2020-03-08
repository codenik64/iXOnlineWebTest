using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace iXOnline.Core.Utilities.Helpers
{
    public static class GlobalIXHelper
    {
        public static string LoggedInUser()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        public static string Username()
        {
            var Getusername = UserNameHelper(LoggedInUser());
            return Getusername;
        }

        public static Members GenericUserIdentityHelper(string UserEmail)
        {
            using (iXOnlineWebEntities dbContext = new iXOnlineWebEntities())
            {


                var UserInfo = from user in dbContext.Members
                               join MSCIdentityUser in dbContext.AspNetUsers
                                on user.EmailAddress equals MSCIdentityUser.Email
                               where user.EmailAddress == UserEmail
                               select user;

                return (Members)UserInfo.FirstOrDefault();


            }
        }

        public static string UserNameHelper(string UserEmail)
        {

            var username = GenericUserIdentityHelper(UserEmail).MemberName;
            return username.ToString();


        }

        public static int FindMemberId (string EmailAddress)
        {
            using (iXOnlineWebEntities dbContext = new iXOnlineWebEntities())
            {
                var userLambda = dbContext.Members.Join(dbContext.AspNetUsers, Members => Members.EmailAddress, AspUser => AspUser.Email, (Members, AspUser) => 
                new { Members, AspUser }).Where(x => x.Members.EmailAddress == EmailAddress);

                var Memberuid = userLambda.FirstOrDefault().Members.MemberId;

                return Memberuid;
            }
        }

        public static int GetMemberId()
        {
            var MemberId = FindMemberId(LoggedInUser());
            return MemberId;
        }

    }
}
