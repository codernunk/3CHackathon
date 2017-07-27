using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3CHackathonAcumen.Classes
{
    public class Tag
    {
        public int tag_id { get; set; }
        public string tag_name { get; set; }
        public int tag_type { get; set; }
        public int relevance { get; set; }
    }
}