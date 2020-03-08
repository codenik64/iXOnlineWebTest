using iXOnline.Core.Interfaces;
using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnlineWeb.Core.BusinessLogic
{
    public class ErrorLogBLL : IErrorLog
    {
        readonly iXOnlineWebEntities dbContext;
        CRUDRepository<ErrorLog> ErrorRepo;

        public ErrorLogBLL()
        {
            dbContext = new iXOnlineWebEntities();
            ErrorRepo = new CRUDRepository<ErrorLog>();
        }

        public void InsertError(Exception ErrorException)
        {
            ErrorLog Error = new ErrorLog
            {
                ErrorMessage = ErrorException.Message,
                ErrorSourceObject = ErrorException.Source,
                TargetSite = (ErrorException.TargetSite).Name,
                DateLogged = DateTime.Parse(DateTime.Now.ToLongDateString())
            };
            ErrorRepo.Insert(Error);
            ErrorRepo.Save();
        }
    }
}
