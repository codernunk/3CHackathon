using _3CHackathonAcumen.Classes;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _3CHackathonAcumen.Controllers
{
    public class TermController : ApiController
    {

        [HttpGet]
        [Route("api/values/upvote")]
        public List<Term> upvote(int termId)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString))
            {
                //vulnerable to sql injection :) 
                return db.Query<Term>("update terms set upvotes = upvotes + 1 where term_id =" + termId).ToList();
            }
        }

        [HttpGet]
        [Route("api/values/downvote")]
        public List<Term> downvote(int termId)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString))
            {
                //vulnerable to sql injection :) 
                return db.Query<Term>("update terms set views = views + 1 where term_id =" + termId).ToList();
            }
        }

        [HttpGet]
        [Route("api/values/addView")]
        public List<Term> addView(int termId)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString))
            {
                //vulnerable to sql injection :) 
                return db.Query<Term>("update terms set upvotes = upvotes - 1 where term_id =" + termId).ToList();
            }
        }
    }
}
