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
        public void upvote(int termId, int userId = 1)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString))
            {
                string readSp = "upvote";
                db.Query<int>(readSp, new { termId = termId, userId = userId }, commandType: CommandType.StoredProcedure);
            }
        }

        [HttpGet]
        [Route("api/values/downvote")]
        public void downvote(int termId, string feedback, int userId = 1)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString))
            {
                string readSp = "downvote";
                db.Query<int>(readSp, new { termId = termId, userId = userId, feedback = feedback }, commandType: CommandType.StoredProcedure);
                //return db.Execute(string.Format("EXEC downvote {0}, {1}, '{2}'", termId, userId, feedback.Replace("'","''")));
            }
        }

        [HttpGet]
        [Route("api/values/addView")]
        public List<Term> addView(int termId)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString))
            {
                string readSp = "addview";
                return db.Query<Term>(readSp, new { termId = termId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        [HttpGet]
        [Route("api/values/submitterm")]
        public void submitterm(string question, string definition, string department) {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString)) {
                string readSp = "ins_term_basic";
                db.Query(readSp, new { term_name = question, definition = definition, author = 1, dept = department }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
