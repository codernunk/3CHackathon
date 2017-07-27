using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _3CHackathonAcumen.Controllers
{
    [Authorize]
    public class FactoidController : ApiController
    {
        // GET api/factoid
        public IEnumerable<string> Get()
        {
            // Connect to the database

            // Query

            // Get data
            return new string[] { "value1", "value2" };
        }

        // GET api/factoid/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/factoid
        public void Post([FromBody]string value)
        {
        }

        // PUT api/factoid/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/factoid/5
        public void Delete(int id)
        {
        }
    }
}
