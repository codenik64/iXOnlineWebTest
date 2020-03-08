﻿using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnline.Core.Interfaces
{
    public interface IGenericBook
    {
        IQueryable<Book> GetBooks();
        IQueryable<Book> GetAllBooks();
        Book FindById(int id);
        void InsertBook(Book bookEntity);
        void UpdateBook(Book bookEntity);
        void RemoveBook(int Id);
    }
}
