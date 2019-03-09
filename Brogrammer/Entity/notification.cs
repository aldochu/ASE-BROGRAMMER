using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brogrammer.Entity
{
    public class notification
    {
        public string commentid { get; set; }
        public string postid { get; set; }
        public string title { get; set; }
        public string userid { get; set; }
        public string content { get; set; }
        public int flaggednotified { get; set; }
    }
}