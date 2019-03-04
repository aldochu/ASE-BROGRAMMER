using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brogrammer.Entity
{
    public class comment
    {
        public string commentid { get; set; }
        public string postid { get; set; }
        public string userid { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public int upvote { get; set; }
        public int downvote { get; set; }
        public int flagged { get; set; }
        public int flaggednotified { get; set; }
        public string endorseby { get; set; }
        public int notified { get; set; }
        public DateTime date { get; set; }
    }
}