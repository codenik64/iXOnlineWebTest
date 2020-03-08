
using iXOnline.Core.Interfaces;
using iXOnline.Core.Utilities.Helpers;
using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnlineWeb.Core.BusinessLogic
{
    public class BookRatings : IBookRating
    {
        iXOnlineWebEntities dbContext;
        CRUDRepository<BookRating> bookRatingRepo;
        ErrorLogBLL Error;

        public BookRatings()
        {
            dbContext = new iXOnlineWebEntities();
            bookRatingRepo = new CRUDRepository<BookRating>();
            Error = new ErrorLogBLL();
        }

        public IQueryable<BookRating> GetBookRatings()
        {
            var bookRating = bookRatingRepo.GetAll();
            return bookRating;
        }

        public IQueryable<BookRating> GetAllRatings()
        {
            var getRating = GetBookRatings().Select(x => new BookRating
            {
               RatingId = x.RatingId,
               RatingNumber =x.RatingNumber,
               MemberId = x.MemberId,
               BookId = x.BookId
            }).ToList();

            return getRating.AsQueryable();
        }

        public void InsertRating(BookRating bookRating)
        {
            try
            {
                BookRating bookrating = new BookRating
                {
                    RatingNumber = bookRating.RatingNumber,
                    MemberId = GlobalIXHelper.GetMemberId(),
                    BookId = bookRating.BookId
                };
                bookRatingRepo.Insert(bookrating);
                bookRatingRepo.Save();
            }
            catch (Exception ex)
            {
                Error.InsertError(ex);
            }
        }

        public void UpdateRating(BookRating bookRating)
        {
            try
            {
                bookRatingRepo.Update(bookRating);
                bookRatingRepo.Save(); 
            }
            catch (Exception ex)
            {

                Error.InsertError(ex);
            }
        }

        public BookRating FindById (int id)
        {
            var bookrating = bookRatingRepo.GetById(id);
            return bookrating;
        }
    }
}
