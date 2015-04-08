namespace PayStuffWeb.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;

    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            throw new HttpResponseException(HttpStatusCode.NotImplemented);
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
