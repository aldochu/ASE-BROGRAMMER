using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brogrammer.Entity
{
    public class post
    {
            public string id { get; set; }
            public string uid { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public string file { get; set; }
            public DateTime date { get; set; }
            public string mod { get; set; }

    }
}