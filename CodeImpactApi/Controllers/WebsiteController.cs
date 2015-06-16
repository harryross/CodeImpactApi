using System.Web.Http;
using CodeImpactApi.Queries;
using Newtonsoft.Json;

namespace CodeImpactApi.Controllers
{
    public class WebsiteController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string className)
        {
            var query = new GetWebpageAffected();
            var response = query.GetFinalNodesAffected(className);
            var result = JsonConvert.SerializeObject(response);
            return Ok(response);
        }
    }
}