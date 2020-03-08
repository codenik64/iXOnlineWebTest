using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnline.Core.Interfaces
{
    public interface IBookReview
    {
        IQueryable<BookReview> GetBookReview();
        IQueryable<BookReview> GetAllBookReviews();
        void InsertReview(BookReview bookReview);
        void UpdateReview(BookReview bookReview);
        void RemoveReview(int Id);
        BookReview FindById(int Id);
    }
}
