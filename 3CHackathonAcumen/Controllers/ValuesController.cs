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

        //[HttpGet]
        //[Route("api/values/searchTerm")]
        //public List<Fact> getFacts(string search=null)
        //{
        //    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString))
        //    {
        //        return db.Query<Fact>("select fact_text from factoids_old where fact_text like '%" + search +"%'").ToList();
        //    }
        //}

        [HttpGet]
        [Route("api/values/question")]
        public List<Term> getRandomQuestion()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString))
            {
                //get a random question from a database
                return db.Query<Term>("SELECT TOP 1 * FROM table ORDER BY NEWID()").ToList();
            }
        }


        [HttpGet]
        [Route("api/values/searchTerms")]
        public List<Term> SearchTerms(string search = null) {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["3CHackathon"].ConnectionString)) {
                // Get data
                List<TermTagResult> data = db.Query<TermTagResult>(string.Format("EXEC [SEL_TERMS_IMPLICIT] '{0}'", search)).ToList();

                List<Term> terms = new List<Term>();
                int lastId = -1;
                foreach (var d in data) {
                    if (d.term_id != lastId) {
                        Term t = d.ToTerm();
                        terms.Add(t);
                    } else {
                        terms[terms.Count - 1].tags.Add(new Tag() { tag_id = -1, tag_name = d.tag_name, tag_type = 1, relevance = d.relevance });
                    }
                    lastId = d.term_id;
                }

                return terms;
            }
        }
    }
}
