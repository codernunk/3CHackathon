using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _3CHackathonAcumen.Classes;
namespace _3CHackathonAcumen.Classes
{
    public class Term
    {
        public int term_id { get; set; }
        public string term_name { get; set; }
        public string definition { get; set; }
        public string term_link { get; set; } //assuming this is a URL
        public string author { get; set; }
        public DateTime create_date { get; set; }
        public int level { get; set; }
        public int upvotes { get; set; }
        public int downvotes { get; set; }
        public int views { get; set; }
        public string additional_details { get; set; }
        public List<Tag> tags { get; set; }

        public Term() {
            tags = new List<Tag>();
        }
    }

    public class TermTagResult {
        public int term_id { get; set; }
        public string term_name { get; set; }
        public string definition { get; set; }
        public string term_link { get; set; } //assuming this is a URL
        public string author { get; set; }
        public DateTime create_date { get; set; }
        public int level { get; set; }
        public int upvotes { get; set; }
        public int downvotes { get; set; }
        public int views { get; set; }
        public string additional_details { get; set; }
        public string tag_name { get; set; }
        public int relevance { get; set; }

        public Term ToTerm() {
            Term t = new Classes.Term();

            t.term_id = term_id;
            t.term_name = term_name;
            t.definition = definition;
            t.term_link = term_link;
            t.author = author;
            t.create_date = create_date;
            t.level = level;
            t.upvotes = upvotes;
            t.downvotes = downvotes;
            t.views = views;
            t.additional_details = additional_details;

            t.tags.Add(new Tag() { tag_id = -1, tag_name = this.tag_name, tag_type = 1, relevance = this.relevance });

            return t;
        }
    }

}