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
    public class CountryController : ApiController
    {
        private CountryHandler _countryHandler;
        public CountryController()
        {
            _countryHandler = new CountryHandler();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            HttpResponseMessage response = null;
            try
            {
                var countries = _countryHandler.Retrieve();
                return Ok(new ReturnData(DataList.CodeStatus.Ok, "Countries extracted", countries));
            }
            catch (CException e)
            {
                response = Request.CreateResponse((HttpStatusCode)510, new ReturnData(e.Status, e.Message));
            }
            return new ResponseMessageResult(response);
        }
    }
}
