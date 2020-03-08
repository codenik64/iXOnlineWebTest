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
    public class RatingController : ApiController
    {
        IBookRating genericRating = BookRatingFactory.CreateRatingLibrary();

  
        public IHttpActionResult Get()
        {
            return Ok(new { results = genericRating.GetAllRatings() });
        }

   
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, genericRating.FindById(id));
        }


       
        public HttpResponseMessage Insert(BookRating bookRating)
        {
            try
            {
                genericRating.InsertRating(bookRating);
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully rated book");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message.ToString());
            }
        }


        public HttpResponseMessage Update(BookRating bookRating)
        {
            try
            {
                genericRating.UpdateRating(bookRating);
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully updated book rating");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message.ToString());
            }
        }

       
        
}
