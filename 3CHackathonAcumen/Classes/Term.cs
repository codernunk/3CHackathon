using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _3CHackathonAcumen.Classes;
namespace _3CHackathonAcumen.Classes
{
    public class Term
    {
        public int termId { get; set; }
        public string termName { get; set; }
        public string defintion { get; set; }
        public string termLink { get; set; } //assuming this is a URL
        public string author { get; set; }
        public DateTime createDate { get; set; }
        public int level { get; set; }
        public int upvotes { get; set; }
        public int downvotes { get; set; }
        public int views { get; set; }
        public string additionalDetails { get; set; }
        public List<Tag> tagList {get; set;}
    }
}