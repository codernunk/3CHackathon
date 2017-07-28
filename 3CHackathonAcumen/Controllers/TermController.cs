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
        public int upvote(int termId, int userId = 1)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString))
            {
                //vulnerable to sql injection :) 
                return db.Execute(string.Format("EXEC upvote {0}, {1}", termId, userId));
            }
        }

        [HttpGet]
        [Route("api/values/downvote")]
        public int downvote(int termId, string feedback, int userId = 1)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString))
            {
                //vulnerable to sql injection :) 
                return db.Execute(string.Format("EXEC downvote {0}, {1}, '{2}'", termId, userId, feedback.Replace("'","''")));
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
