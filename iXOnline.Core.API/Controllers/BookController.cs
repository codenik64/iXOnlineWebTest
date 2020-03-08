using iXOnline.Core.Interfaces;
using iXOnlineWeb.Core.FactoryLayer;
using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iXOnline.Core.API.Controllers
{
    [Authorize]
    public class BookController : ApiController
    {
        IGenericBook genericBook = BookFactory.CreateBooksLibrary();

        // GET: api/Book
        public IHttpActionResult Get()
        {
            return Ok(new { results = genericBook.GetAllBooks() });
        }

        // GET: api/Book/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, genericBook.FindById(id));
        }


        // POST: api/Book
        public HttpResponseMessage Insert(Book book)
        {
            try
            {
             genericBook.InsertBook(book);
             return Request.CreateResponse(HttpStatusCode.OK, "Successfully added a book");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message.ToString());
            }
        }

        // PUT: api/Book/5
        public HttpResponseMessage Update(Book book)
        {
            try
            {
                genericBook.UpdateBook(book);
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully updated Book");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message.ToString());
            }
        }

        // DELETE: api/Book/5
        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                genericBook.RemoveBook(Id);
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully removed book");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message.ToString());
            }
        }
    }
}
