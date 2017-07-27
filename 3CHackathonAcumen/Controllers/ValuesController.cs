using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using _3CHackathonAcumen.Classes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _3CHackathonAcumen.Controllers
{
    public class ValuesController : ApiController
    {

        [HttpGet]
        [Route("api/values/searchTerm")]
        public List<Fact> getFacts(string search)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString))
            {
                return db.Query<Fact>("select fact_text from factoids").ToList();
            }
        }
    }
}
