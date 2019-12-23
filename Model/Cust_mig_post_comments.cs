using System;
using System.Collections.Generic;
using System.Text;

namespace benefit_db_migration.Model
{
    public class Cust_mig_post_comments
    {
        public string boardname { get; set; }
        public string commentid { get; set; }
        public string sourceid { get; set; }
        public string parentcommentid { get; set; }
        public string seq { get; set; }
        public string content { get; set; }
        public string createdat { get; set; }
        public string write_emailid { get; set; }
    }
}
