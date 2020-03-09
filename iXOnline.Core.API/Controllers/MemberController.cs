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
    public class MemberController : ApiController
    {
        IMember genericMember = MemberFactory.CreateMemberLibrary();


        public IHttpActionResult Get()
        {
            return Ok(new { results = genericMember.GetAll() });
        }


        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, genericMember.FindById(id));
        }



        public HttpResponseMessage Insert(Members member)
        {
            try
            {
                genericMember.Insert(member);
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully inserted member");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message.ToString());
            }
        }


        public HttpResponseMessage Update(Members member)
        {
            try
            {
                genericMember.UpdateMember(member);
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully updated member");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message.ToString());
            }
        }
    }
}
