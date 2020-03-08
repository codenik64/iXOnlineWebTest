using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnline.Core.Interfaces
{
    public interface IBookRating
    {
        IQueryable<BookRating> GetBookRatings();
        IQueryable<BookRating> GetAllRatings();
        void InsertRating(BookRating bookRating);
        void UpdateRating(BookRating bookRating);
        BookRating FindById(int id);
    }
}
