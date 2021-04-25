using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoticeBoard.Models;
using System.Data.OleDb;
using System.Configuration;

namespace NoticeBoard.Context
{

    public class UserContext
    {


        //   userTB
        private string cs = ConfigurationManager.ConnectionStrings["MYDB"].ConnectionString;




        public void Edituser(UserModel userEdit)
        {
            string cms = @"UPDATE userTB SET zdepartment = @zdepartment , zclass = @zclass, zfirstname = @zfirstname, zlastname = @zlastname, zmatricNumber = @zmatricNumber, zpassword = @zpassword, zsex = @zsex  WHERE ID = @ID";

            using (OleDbConnection con = new OleDbConnection(cs))
            {
                OleDbCommand cmd = new OleDbCommand(cms, con);

                cmd.Parameters.AddWithValue("zdepartment", "@zdepartment").Value = userEdit.zdepartment;

                cmd.Parameters.AddWithValue("zclass", "@zclass").Value = userEdit.zclass;

                cmd.Parameters.AddWithValue("zfirstname", "@zfirstname").Value = userEdit.zfirstname;

                cmd.Parameters.AddWithValue("zlastname", "@zlastname").Value = userEdit.zlastname;

                cmd.Parameters.AddWithValue("zmatricNumber", "@zmatricNumber").Value = userEdit.zmatricNumber;

                cmd.Parameters.AddWithValue("zpassword", "@zpassword").Value = userEdit.zpassword;

                cmd.Parameters.AddWithValue("zsex", "@zsex").Value = userEdit.zsex;

                cmd.Parameters.AddWithValue("ID", "@ID").Value = userEdit.ID;


                con.Open();
                cmd.ExecuteNonQuery();

            }



        }




        public void Deleteuser(UserModel userDelete)
        {
            string cms = @"DELETE FROM userTB  WHERE ID = @ID";

            using (OleDbConnection con = new OleDbConnection(cs))
            {
                OleDbCommand cmd = new OleDbCommand(cms, con);

                cmd.Parameters.AddWithValue("ID", "@ID").Value = userDelete.ID;

                con.Open();
                cmd.ExecuteNonQuery();

            }

        }





        public void AddUser(UserModel USERadd)
        {
            string cms = @"insert into userTB(zdepartment, zclass, zfirstname, zlastname, zmatricNumber, zpassword, zsex ) VALUES(@zdepartment, @zclass, @zfirstname, @zlastname, @zmatricNumber, @zpassword, @zsex )";
            using (OleDbConnection con = new OleDbConnection(cs))
            {
                OleDbCommand cmd = new OleDbCommand(cms, con);

                cmd.Parameters.AddWithValue("Message_ns", "@Message_ns").Value = USERadd.zdepartment;
                cmd.Parameters.AddWithValue("Title_ns", "@Title_ns").Value = USERadd.zclass;
                cmd.Parameters.AddWithValue("Message_ns", "@Message_ns").Value = USERadd.zfirstname;
                cmd.Parameters.AddWithValue("Title_ns", "@Title_ns").Value = USERadd.zlastname;
                cmd.Parameters.AddWithValue("Message_ns", "@Message_ns").Value = USERadd.zmatricNumber;
                cmd.Parameters.AddWithValue("Title_ns", "@Title_ns").Value = USERadd.zpassword;
                cmd.Parameters.AddWithValue("Date_ns", "@Date_ns").Value = USERadd.zsex;

                con.Open();
                cmd.ExecuteNonQuery();
            }


        }




        public IEnumerable<UserModel> allUser
        {

            get
            {
                string cms = "select * from userTB";

                List<UserModel> users = new List<UserModel>();

                using (OleDbConnection con = new OleDbConnection(cs))
                {
                    OleDbCommand cmd = new OleDbCommand(cms, con);

                    con.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UserModel user = new UserModel()
                        {
                            ID = Convert.ToInt16(dr["ID"]),

                            zdepartment = dr["zdepartment"].ToString(),

                            zclass = dr["zclass"].ToString(),

                            zfirstname = dr["zfirstname"].ToString(),

                            zlastname = dr["zlastname"].ToString(),

                            zmatricNumber = dr["zmatricNumber"].ToString(),

                            zpassword = dr["zpassword"].ToString(),

                            zsex = dr["zsex"].ToString(),




                            //  Date_ns = Convert.ToDateTime(dr["Date_ns"]),
                        };

                        users.Add(user);
                    }


                }



                return users;
            }
        }




    }

}