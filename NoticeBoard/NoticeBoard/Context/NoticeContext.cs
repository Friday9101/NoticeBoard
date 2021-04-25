using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Configuration;
using NoticeBoard.Models;

namespace NoticeBoard.Context
{
    public class NoticeContext
    {




        // NewsTB
        private string cs = ConfigurationManager.ConnectionStrings["MYDB"].ConnectionString;




        public void Delete_Notice(NoticeModel NoticeDelete)
        {
            string cms = @"DELETE FROM NewsTB  WHERE ID = @ID";

            using (OleDbConnection con = new OleDbConnection(cs))
            {
                OleDbCommand cmd = new OleDbCommand(cms, con);

                cmd.Parameters.AddWithValue("ID", "@ID").Value = NoticeDelete.ID;

                con.Open();
                cmd.ExecuteNonQuery();

            }

        }



        public void EditNotice(NoticeModel noticeEdit)
        {
            string cms = @"UPDATE NewsTB SET Title_ns = @Title_ns, Date_ns = @Date_ns, Message_ns = @Message_ns  WHERE ID = @ID";

            using (OleDbConnection con = new OleDbConnection(cs))
            {
                OleDbCommand cmd = new OleDbCommand(cms, con);

                cmd.Parameters.AddWithValue("Title_ns", "@Title_ns").Value = noticeEdit.Title_ns;
                cmd.Parameters.AddWithValue("Date_ns", "@Date_ns").Value = noticeEdit.Date_ns;
                cmd.Parameters.AddWithValue("Message_ns", "@Message_ns").Value = noticeEdit.Message_ns;
                cmd.Parameters.AddWithValue("ID", "@ID").Value = noticeEdit.ID;

                con.Open();
                cmd.ExecuteNonQuery();

            }



        }

        // NewsTB


        public IEnumerable<NoticeModel> allNotice
        {

            get
            {
                string cms = "select * from newsTb";

                List<NoticeModel> notices = new List<NoticeModel>();

                using (OleDbConnection con = new OleDbConnection(cs))
                {
                    OleDbCommand cmd = new OleDbCommand(cms, con);

                    con.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        NoticeModel notice = new NoticeModel()
                        {
                            ID = Convert.ToInt16(dr["ID"]),
                            Message_ns = dr["Message_ns"].ToString(),
                            Title_ns = dr["Title_ns"].ToString(),
                            Date_ns = Convert.ToDateTime(dr["Date_ns"]),
                        };

                        notices.Add(notice);
                    }


                }



                return notices;
            }
        }


        public void AddNotice(NoticeModel noticeadd)
        {
            string cms = @"insert into NewsTB(Message_ns, Title_ns, Date_ns) VALUES(@Message_ns, @Title_ns, @Date_ns)";

            using (OleDbConnection con = new OleDbConnection(cs))
            {
                OleDbCommand cmd = new OleDbCommand(cms, con);


                cmd.Parameters.AddWithValue("Message_ns", "@Message_ns").Value = noticeadd.Message_ns;
                cmd.Parameters.AddWithValue("Title_ns", "@Title_ns").Value = noticeadd.Title_ns;
                cmd.Parameters.AddWithValue("Date_ns", "@Date_ns").Value = noticeadd.Date_ns;
                con.Open();
                cmd.ExecuteNonQuery();
            }





        }




















    }

}