using NCDApp.dal;
using NCDApp.bll;
using NCDApp.api.Providers;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System;
using System.Net;
using NCDApp.bll.Helpers;

namespace NCDApp.api.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private UserHandler _userHandler;
        public UserController()
        {
            _userHandler = new UserHandler();
        }
       
        [HttpGet]
        public IHttpActionResult Get()
        {
            HttpResponseMessage response = null;
            try
            {
                var user = _userHandler.GetActualUser();
                return Ok(new ReturnData(DataList.CodeStatus.Ok, "User extracted", user));
            }
            catch(CException e)
            {
                response = Request.CreateResponse((HttpStatusCode)510, new ReturnData(e.Status, e.Message));
            }
            return new ResponseMessageResult(response);
        }

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Register(User user)
        {
            HttpResponseMessage response = null;
            try
            {
                var nUser = _userHandler.Register(user);
                return Ok(new ReturnData(DataList.CodeStatus.Ok, "User registered succesfully", nUser));
            }
            catch (CException e)
            {
                response = Request.CreateResponse((HttpStatusCode)510, new ReturnData(e.Status, e.Message));
            }
            return new ResponseMessageResult(response);
        }
    }
}
