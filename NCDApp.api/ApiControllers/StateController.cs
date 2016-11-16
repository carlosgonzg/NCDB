using NCDApp.dal;
using NCDApp.bll;
using NCDApp.api.Providers;
using NCDApp.bll.Helpers;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace NCDApp.api.ApiControllers
{
    public class StateController : ApiController
    {
        private StateHandler _stateHandler;
        public StateController()
        {
            _stateHandler = new StateHandler();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            HttpResponseMessage response = null;
            try
            {
                var countries = _stateHandler.Retrieve();
                return Ok(new ReturnData(DataList.CodeStatus.Ok, "States extracted", countries));
            }
            catch (CException e)
            {
                response = Request.CreateResponse((HttpStatusCode)510, new ReturnData(e.Status, e.Message));
            }
            return new ResponseMessageResult(response);
        }
        [HttpGet]
        public IHttpActionResult Get(int countryId)
        {
            HttpResponseMessage response = null;
            try
            {
                var countries = _stateHandler.GetByCountry(countryId);
                return Ok(new ReturnData(DataList.CodeStatus.Ok, "States extracted", countries));
            }
            catch (CException e)
            {
                response = Request.CreateResponse((HttpStatusCode)510, new ReturnData(e.Status, e.Message));
            }
            return new ResponseMessageResult(response);
        }
    }
}
