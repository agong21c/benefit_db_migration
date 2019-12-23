using System;
using System.Collections.Generic;
using System.Text;

namespace benefit_db_migration.Model
{
    public class Cust_mig_posts
    {
        public string boardname { get; set; }
        public string sourceid { get; set; }
        public string parentid { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string createdat { get; set; }
        public string write_emailid { get; set; }
        public string target { get; set; }
    }
}
