using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marketing.Models
{
    public class Login
    {
        public int LoginID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public int Save()
        {
            int Row = 0;
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            try
            {
                string Quary = "";
                if (this.LoginID == 0)
                {
                    Quary = "Insert Into Login values (@UserName,@Password,@UserID,@CreateBy,@CreateDate,@UpdateBy,@UpdateDate)";
                }
                else
                {
                    Quary = "Update Login Set UserName=@UserName,Password=@Password,UserID=@UserID,CreateBy=@CreateBy,CreateDate=@CreateDate,UpdateBy=@UpdateBy,UpdateDate=@UpdateDate where LoginID=@LoginID";
                }
                cmd = new SqlCommand(Quary, dBCon.Con);
                cmd.Parameters.AddWithValue("@LoginID", this.LoginID);
                cmd.Parameters.AddWithValue("@UserName", this.UserName);
                cmd.Parameters.AddWithValue("@Password", this.Password);
                cmd.Parameters.AddWithValue("@UserID", this.UserID);
                if (this.LoginID == 0)
                {
                    Row = Convert.ToInt32(cmd.ExecuteScalar());
                    this.LoginID = Row;
                }
                else
                {
                    Row = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e) { e.ToString(); }
            finally { cmd.Dispose(); dBCon.Con.Close(); }
            return Row;
        }
        public List<Login> GetAll()
        {
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            List<Login> listlogin = new List<Login>();
            try
            {
                string Quary = "Select * From Login Where ORDER BY  LoginID DESC";
                cmd = new SqlCommand(Quary, dBCon.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    listlogin.Add(new Login()
                    {
                        LoginID = SDR.GetInt32(0),
                        UserName = SDR.GetString(1),
                        Password = SDR.GetString(2),
                        UserID = SDR.GetInt32(3)
                    });

                }
            }
            catch (Exception e) { e.ToString(); }
            finally { cmd.Dispose(); dBCon.Con.Close(); }
            return (listlogin);
        }
        public Login GetOne(int ID)
        {
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            Login ObjTmp = new Login();
            try
            {
                string Query = "SELECT * FROM  Login where  LoginID=" + ID;
                cmd = new SqlCommand(Query, dBCon.Con);
                cmd.Parameters.AddWithValue("@LoginID", ID);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    ObjTmp.LoginID = SDR.GetInt32(0);
                    ObjTmp.UserName = SDR.GetString(1);
                    ObjTmp.Password = SDR.GetString(2);
                    ObjTmp.UserID = SDR.GetInt32(3);
                }
            }
            catch (System.Exception e) { e.ToString(); }
            finally { cmd.Dispose(); dBCon.Con.Close(); }

            return (ObjTmp);
        }
        public int Dell(int ID)
        {
            int R = 0;
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            try
            {
                string Query = "Delete FROM  Login where id=" + ID;
                cmd = new SqlCommand(Query, dBCon.Con);
                R = cmd.ExecuteNonQuery();
            }
            catch (System.Exception e)
            { e.ToString(); }

            finally
            {
                dBCon.Con.Close();
            }
            return R;

        }
    }
}