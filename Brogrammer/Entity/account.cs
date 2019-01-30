using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brogrammer.Entity
{
    public class account
    {
        public string id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public int warning { get; set; }
    }
}