using iXOnline.Core.Interfaces;
using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnlineWeb.Core.BusinessLogic
{
    public class BookReviewBLL : IBookReview
    {
        iXOnlineWebEntities dbContext;
        CRUDRepository<BookReview> bookReviewRepo;
        ErrorLogBLL Error;

        public BookReviewBLL()
        {
            dbContext = new iXOnlineWebEntities();
            bookReviewRepo = new CRUDRepository<BookReview>();
            Error = new ErrorLogBLL();
        }

        public IQueryable<BookReview> GetBookReview()
        {
            var review = bookReviewRepo.GetAll();
            return review;
        }

        public IQueryable<BookReview> GetAllBookReviews()
        {
            var getReview = GetBookReview().Select(x => new BookReview
            {
                ReviewId =x.ReviewId,
                ReviewDescription = x.ReviewDescription,
                MemberId = x.MemberId,
                BookId = x.BookId
            }).ToList();

            return getReview.AsQueryable();


        }

        public void InsertReview (BookReview bookReview)
        {
            try
            {
                bookReviewRepo.Insert(bookReview);
                bookReviewRepo.Save();
            }
            catch (Exception ex )
            {
                Error.InsertError(ex);
            }
        }

        public void UpdateReview(BookReview bookReview)
        {
            try
            {
                bookReviewRepo.Update(bookReview);
                bookReviewRepo.Save();
            }
            catch (Exception ex)
            {
                Error.InsertError(ex);
            }
        }

        public void RemoveReview (int Id)
        {
            try
            {
                bookReviewRepo.Delete(Id);
                bookReviewRepo.Save();
            }
            catch (Exception ex)
            {
                Error.InsertError(ex);
            }
           
        }

        public BookReview FindById (int Id)
        {
            var FindReview = bookReviewRepo.GetById(Id);
            return FindReview;
        }

    }
}
