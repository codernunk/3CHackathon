using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3CHackathonAcumen.Classes
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string dpt { get; set; }
        public int level { get; set; }
        public string avatar { get; set; }
        public string title { get; set; }
        public double exp { get; set; }
        public DateTime lastLogin { get; set; }
    }
}