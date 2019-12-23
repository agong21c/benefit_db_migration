using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using benefit_db_migration.Model;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace benefit_db_migration
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

            List<String> boardList = new List<string>();
            boardList.Add("noticeall");
            boardList.Add("event");
            boardList.Add("calendar");
            boardList.Add("2016dmstraining");
            boardList.Add("dpnotice");
            boardList.Add("dealer_1_D3_1");
            boardList.Add("dealer_1_D3_2");
            boardList.Add("dealer_1_D3_3");
            boardList.Add("dealer_1_D3_4");
            boardList.Add("dealer_2_D3_1");
            boardList.Add("dealer_2_D3_2");
            boardList.Add("dealer_2_D3_3");
            boardList.Add("dealer_2_D3_4");
            boardList.Add("dealer_3_D3_1");
            boardList.Add("dealer_3_D3_2");
            boardList.Add("dealer_3_D3_3");
            boardList.Add("dealer_3_D3_4");
            boardList.Add("dealer_4_D3_1");
            boardList.Add("dealer_4_D3_2");
            boardList.Add("dealer_4_D3_3");
            boardList.Add("dealer_4_D3_4");
            boardList.Add("dealer_5_D3_1");
            boardList.Add("dealer_5_D3_2");
            boardList.Add("dealer_5_D3_3");
            boardList.Add("dealer_5_D3_4");
            boardList.Add("dealer_6_D3_1");
            boardList.Add("dealer_6_D3_2");
            boardList.Add("dealer_6_D3_3");
            boardList.Add("dealer_6_D3_4");
            boardList.Add("dealer_7_D3_1");
            boardList.Add("dealer_7_D3_2");
            boardList.Add("dealer_7_D3_3");
            boardList.Add("dealer_7_D3_4");
            boardList.Add("dealer_8_D3_1");
            boardList.Add("dealer_8_D3_2");
            boardList.Add("dealer_8_D3_3");
            boardList.Add("dealer_8_D3_4");
            boardList.Add("dealer_9_D3_1");
            boardList.Add("dealer_9_D3_2");
            boardList.Add("dealer_9_D3_3");
            boardList.Add("dealer_9_D3_4");
            boardList.Add("dealer_10_D3_1");
            boardList.Add("dealer_10_D3_2");
            boardList.Add("dealer_10_D3_3");
            boardList.Add("dealer_10_D3_4");
            boardList.Add("dealer_11_D3_1");
            boardList.Add("dealer_11_D3_2");
            boardList.Add("dealer_11_D3_3");
            boardList.Add("dealer_11_D3_4");
            boardList.Add("amnotice");
            boardList.Add("dealer_1_D2_0");
            boardList.Add("dealer_2_D2_0");
            boardList.Add("dealer_3_D2_0");
            boardList.Add("dealer_4_D2_0");
            boardList.Add("dealer_5_D2_0");
            boardList.Add("dealer_6_D2_0");
            boardList.Add("dealer_7_D2_0");
            boardList.Add("dealer_8_D2_0");
            boardList.Add("dealer_9_D2_0");
            boardList.Add("dealer_10_D2_0");
            boardList.Add("dealer_11_D2_0");
            boardList.Add("amdealer");
            boardList.Add("amservice");
            boardList.Add("amcun");
            boardList.Add("ammarketing");
            boardList.Add("spcockpit");
            boardList.Add("reman");
            boardList.Add("mbmerchan");
            boardList.Add("mbtechnical");
            boardList.Add("sinotice");
            boardList.Add("sisdflash");
            boardList.Add("techinfo");
            boardList.Add("techequip");
            boardList.Add("techdealer");
            boardList.Add("techtech");
            boardList.Add("techffv");
            boardList.Add("techrepaircaseshare");
            boardList.Add("xentryportal");
            boardList.Add("warrantynotice");
            boardList.Add("warrantywarr");
            boardList.Add("warrantycontrol");
            boardList.Add("warrantywic");
            boardList.Add("warrantyclaim");
            boardList.Add("dealer_1_D1_2");
            boardList.Add("dealer_2_D1_2");
            boardList.Add("dealer_3_D1_2");
            boardList.Add("dealer_4_D1_2");
            boardList.Add("dealer_5_D1_2");
            boardList.Add("dealer_6_D1_2");
            boardList.Add("dealer_7_D1_2");
            boardList.Add("dealer_8_D1_2");
            boardList.Add("dealer_9_D1_2");
            boardList.Add("dealer_10_D1_2");
            boardList.Add("dealer_11_D1_2");
            boardList.Add("crmservice");
            boardList.Add("crmcall");
            boardList.Add("crmnotice");
            boardList.Add("crmbbs");
            boardList.Add("bakuppartsnotice");
            boardList.Add("bakupparts");
            boardList.Add("bakuppartsbbs");
            boardList.Add("bakuppartswork");
            boardList.Add("bakuppartsfqa");
            boardList.Add("bakupaspds");
            boardList.Add("bakupasreport");
            boardList.Add("bakupsistyle");
            boardList.Add("bakupsinotice");
            boardList.Add("bakupsipatch");
            boardList.Add("bakuptech");
            boardList.Add("bankuptechequip");
            boardList.Add("bakuptechdealer");
            boardList.Add("bakupwarrnotice");
            boardList.Add("bakupwarrstyle");
            boardList.Add("partsnotice");
            boardList.Add("partsdealer");
            boardList.Add("partsinfo");
            boardList.Add("partsnot");
            boardList.Add("partsupdate");
            boardList.Add("partsdelivery");
            boardList.Add("partstrp");
            boardList.Add("corenotice");
            boardList.Add("corereturn");
            boardList.Add("coreresult");
            boardList.Add("partsqna");
            boardList.Add("mbtire");
            boardList.Add("manurulenotice");
            boardList.Add("techservice");
            boardList.Add("manuqna");
            boardList.Add("manunotimpl");
            boardList.Add("manunotice");
            boardList.Add("carqnq");
            boardList.Add("trainoperationfaq");
            boardList.Add("trainqna");
            boardList.Add("trainguidesales");
            boardList.Add("trainsalesqna");
            boardList.Add("trainguide");
            boardList.Add("trainafterqna");
            boardList.Add("trainmanageguide");
            boardList.Add("trainmanageqna");
            boardList.Add("trainamtguide");
            boardList.Add("trainamtqna");
            boardList.Add("trainausdealer");
            boardList.Add("trainausrecord");
            boardList.Add("pdscsi");
            boardList.Add("pdsdealer");
            boardList.Add("pdscicd");
            boardList.Add("pdsretail");
            boardList.Add("pdsuseful");
            boardList.Add("pdsguide");
            boardList.Add("pdsetc");
            boardList.Add("spmonthly");
            boardList.Add("spspecial");
            boardList.Add("spwhole");
            boardList.Add("spmarket");
            boardList.Add("noticemonthly");
            boardList.Add("noticefinance");
            boardList.Add("noticeprocess");
            boardList.Add("noticeinsurance");
            boardList.Add("itannouncement");
            boardList.Add("smretailbulletin");
            boardList.Add("smretailtech");
            boardList.Add("smretailscore");
            boardList.Add("smretailweekly");
            boardList.Add("smretaildaily");
            boardList.Add("smretailsales");
            boardList.Add("smretailpos");
            boardList.Add("demoreport");
            boardList.Add("smorderbulletin");
            boardList.Add("smppsdealer");
            boardList.Add("smmysteryagree");
            boardList.Add("smmysterybulletin");
            boardList.Add("smmysteryqa");
            boardList.Add("mmcpresource");
            boardList.Add("mmcpmainboard");
            boardList.Add("mmcpreport");
            boardList.Add("smfleetbulletin");
            boardList.Add("smfleetcomp");
            boardList.Add("smusedothers");
            boardList.Add("smfleetpos1");
            boardList.Add("smfleetpos2");
            boardList.Add("smusedbulletin");
            boardList.Add("smusedmarket");
            boardList.Add("smusedcomp");
            boardList.Add("smtrade");
            boardList.Add("smwarexten");
            boardList.Add("smamgbulletin");
            boardList.Add("smamgorder");
            boardList.Add("smamgmr");
            boardList.Add("smmarbulletin");
            boardList.Add("smmarmedia");
            boardList.Add("smmarguide");
            boardList.Add("smmarlink");
            boardList.Add("crmccc");
            boardList.Add("brmcccresource");
            boardList.Add("bceit");
            boardList.Add("bceitresource");
            boardList.Add("bcepmo");
            boardList.Add("bcepmoresource");
            boardList.Add("BInotice");
            boardList.Add("BICboard");

            foreach (var item in boardList)
            {

                using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(config["PostgreSQL:ConnectionString"]))
                {
                    npgsqlConnection.Open();

                    using (SqlConnection sqlConnection = new SqlConnection(config["MSSql:ConnectionString"]))
                    {
                        sqlConnection.Open();
                        #region 게시물 코멘트
                        //List<Cust_mig_post_comments> li_cust_mig_post_attach = sqlConnection.Query<Cust_mig_post_comments>("SP_CUST_MIG_POST_COMMENTS_SELECT", new { BOARD_NAME = item }, commandType: CommandType.StoredProcedure).ToList();

                        //using (var writer = npgsqlConnection.BeginBinaryImport("COPY cust_mig_post_comments (boardname, commentid, sourceid, parentcommentid, seq, content, createdat, write_emailid) FROM STDIN (FORMAT BINARY)"))
                        //{
                        //    Console.WriteLine(String.Format("{0} table convert", item));

                        //    for (int i = 0; i < li_cust_mig_post_attach.Count; i++)
                        //    {
                        //        writer.StartRow();
                        //        writer.Write(li_cust_mig_post_attach[i].boardname);
                        //        writer.Write(li_cust_mig_post_attach[i].commentid);
                        //        writer.Write(li_cust_mig_post_attach[i].sourceid);
                        //        writer.Write(li_cust_mig_post_attach[i].parentcommentid);
                        //        writer.Write(li_cust_mig_post_attach[i].seq);
                        //        writer.Write(li_cust_mig_post_attach[i].content);
                        //        writer.Write(li_cust_mig_post_attach[i].createdat);
                        //        writer.Write(li_cust_mig_post_attach[i].write_emailid);
                        //    }

                        //    Console.WriteLine(String.Format("{0} row convert", li_cust_mig_post_attach.Count));

                        //    writer.Complete();
                        //}
                        #endregion

                        #region 게시물 첨부파일
                        //List<Cust_mig_post_attach> li_cust_mig_post_attach = sqlConnection.Query<Cust_mig_post_attach>("SP_CUST_MIG_POST_ATTACH_SELECT", new { BOARD_NAME = item }, commandType: CommandType.StoredProcedure).ToList();

                        //using (var writer = npgsqlConnection.BeginBinaryImport("COPY cust_mig_post_attach (boardname, sourceid, seq, path, fname, sname) FROM STDIN (FORMAT BINARY)"))
                        //{
                        //    Console.WriteLine(String.Format("{0} table convert", item));

                        //    for (int i = 0; i < li_cust_mig_post_attach.Count; i++)
                        //    {
                        //        writer.StartRow();
                        //        writer.Write(li_cust_mig_post_attach[i].boardname);
                        //        writer.Write(li_cust_mig_post_attach[i].sourceid);
                        //        writer.Write(li_cust_mig_post_attach[i].seq);
                        //        writer.Write(li_cust_mig_post_attach[i].path);
                        //        writer.Write(li_cust_mig_post_attach[i].fname);
                        //        writer.Write(li_cust_mig_post_attach[i].sname);
                        //    }

                        //    Console.WriteLine(String.Format("{0} row convert", li_cust_mig_post_attach.Count));

                        //    writer.Complete();
                        //}
                        #endregion

                        #region 게시물
                        List<Cust_mig_posts> li_cust_mig_posts = sqlConnection.Query<Cust_mig_posts>("SP_BOARD_WARRANTYQUEST_SELECT", new { BOARD_NAME = item }, commandType: CommandType.StoredProcedure).ToList();

                        using (var writer = npgsqlConnection.BeginBinaryImport("COPY cust_mig_posts (boardname, sourceid, parentid, title, content, createdat, write_emailid, target) FROM STDIN (FORMAT BINARY)"))
                        {
                            Console.WriteLine(String.Format("{0} table convert", item));

                            for (int i = 0; i < li_cust_mig_posts.Count; i++)
                            {
                                writer.StartRow();
                                writer.Write(li_cust_mig_posts[i].boardname);
                                writer.Write(li_cust_mig_posts[i].sourceid);
                                writer.Write(li_cust_mig_posts[i].parentid);
                                writer.Write(li_cust_mig_posts[i].title);
                                writer.Write(li_cust_mig_posts[i].content);
                                writer.Write(li_cust_mig_posts[i].createdat);
                                writer.Write(li_cust_mig_posts[i].write_emailid);
                                writer.Write(li_cust_mig_posts[i].target);
                            }

                            Console.WriteLine(String.Format("{0} row convert", li_cust_mig_posts.Count));

                            writer.Complete();
                        }
                        #endregion

                        sqlConnection.Close();
                    }

                    npgsqlConnection.Close();
                }
            }
        }
    }
}