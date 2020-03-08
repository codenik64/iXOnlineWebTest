using iXOnline.Core.Interfaces;
using iXOnline.Core.Utilities.Helpers;
using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnlineWeb.Core.BusinessLogic
{
    public class BookBLL : IGenericBook
    {
        iXOnlineWebEntities dbContext;
        CRUDRepository<Book> BookRepo;
        ErrorLogBLL Error;

        public BookBLL()
        {
            dbContext = new iXOnlineWebEntities();
            BookRepo = new CRUDRepository<Book>();
            Error = new ErrorLogBLL();
        }

        public IQueryable<Book> GetBooks()
        {
            return dbContext.Database.SqlQuery<Book>("BookList").ToList().AsQueryable();
        }

        public IQueryable<Book> GetAllBooks()
        {
            var AllBooks = GetBooks().Select(x => new Book
            {
                BookId = x.BookId,
                BookTitle = x.BookTitle,
                BookDescription = x.BookTitle,
                Author = x.Author,
                ISBN = x.ISBN,
                Edition = x.Edition,
                Language = x.Language,
                DaysAvailable = x.DaysAvailable,
                MemberId = x.MemberId,
                PublishedDate = x.PublishedDate,
                IsBookActive = x.IsBookActive,
                AverageRating = x.AverageRating
            }).ToList();

            return AllBooks.AsQueryable();
        }

        public int ReturnDaysAvailable(Book bookEntity)
        {
            var DateToday = DateTime.Now;
            var PublishedDate = bookEntity.PublishedDate;

            var CalculateDays = (DateToday - PublishedDate).Days;
            return CalculateDays;
        }

        public void InsertBook(Book bookEntity)
        {
            try
            {
                Book BookRepoEntity = new Book
                {
                    BookTitle = bookEntity.BookTitle,
                    BookDescription = bookEntity.BookDescription,
                    ISBN = bookEntity.ISBN,
                    Author = bookEntity.Author,
                    Edition = bookEntity.Edition,
                    Language = bookEntity.Language,
                    MemberId = GlobalIXHelper.GetMemberId(),
                    PublishedDate = DateTime.Parse(DateTime.Now.ToLongDateString()),
                    DaysAvailable = ReturnDaysAvailable(bookEntity) ,
                    IsBookActive = true,
                };
                BookRepo.Insert(BookRepoEntity);
                BookRepo.Save();
            }
            catch (Exception ex)
            {
                Error.InsertError(ex);
            }

        }

        public  void UpdateBook (Book bookEntity)
        {
            try
            {
                BookRepo.Update(bookEntity);
                BookRepo.Save();
            }
            catch (Exception ex)
             {
                Error.InsertError(ex);
            }
        }

        public void RemoveBook(int Id)
        {
            try
            {
                BookRepo.Delete(Id);
                BookRepo.Save();
            }
            catch (Exception ex)
            {

                Error.InsertError(ex);
            }
        }

        public Book FindById(int id)
        {
            return BookRepo.GetById(id);
        }
    }
}
