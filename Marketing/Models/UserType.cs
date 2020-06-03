using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

 namespace Marketing.Models
{
    public class UserType
    {
        public int UserID { get; set; }
        public string Type { get; set; }

        public int Save()
        {
            int Row = 0;
            DBCon ObjDbCon = new DBCon();
            SqlCommand cmd = null;
            try
            {
                string Quary = "";
                if (this.UserID == 0)
                {
                    Quary = "Insert Into UserType values(@Type); SELECT SCOPE_UserIDENTITY();";
                }
                else
                {
                    Quary = "Update UserType Set Type=@Type Where UserID=@UserID";
                }
                cmd = new SqlCommand(Quary, ObjDbCon.Con);
                cmd.Parameters.AddWithValue("@UserID", this.UserID);
                cmd.Parameters.AddWithValue("@Type", this.Type);

                if (this.UserID == 0)
                {
                    Row = Convert.ToInt32(cmd.ExecuteScalar());
                    this.UserID = Row;
                }
                else
                {
                    Row = cmd.ExecuteNonQuery();
                    //this.CategoryUserID = Row;
                }

            }
            catch (Exception e) { e.ToString(); }
            finally { cmd.Dispose(); ObjDbCon.Con.Close(); }
            return Row;
        }
        public static List<UserType> GetAll()
        {
            DBCon ObjDbCon = new DBCon();

            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            List<UserType> UserTypelist = new List<UserType>();
            try
            {
                string Query = "Select *From UserType ORDER BY  UserID DESC";
                cmd = new SqlCommand(Query, ObjDbCon.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    UserTypelist.Add(new UserType() { UserID = SDR.GetInt32(0), Type = SDR.GetString(1) });
                }
            }
            catch (System.Exception e) { e.ToString(); }
            finally { cmd.Dispose(); ObjDbCon.Con.Close(); }
            return (UserTypelist);
        }
        public UserType GetOne(int UserID)
        {
            SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Con"].ToString());
            Con.Open();
            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            UserType ObjTmp = new UserType();
            try
            {
                string Query = "SELECT * FROM  UserType where  UserID=" + UserID;
                cmd = new SqlCommand(Query, Con);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    ObjTmp.UserID = SDR.GetInt32(0);
                    ObjTmp.Type = SDR.GetString(1);
                }
            }
            catch (System.Exception e) { e.ToString(); }
            finally { cmd.Dispose(); Con.Close(); }

            return (ObjTmp);
        }
        public int Dell(int UserID)
        {
            int R = 0;
            SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Con"].ToString());
            Con.Open();
            SqlCommand cmd = null;
            try
            {
                string Query = "Delete FROM  UserType where UserID=" + UserID;
                cmd = new SqlCommand(Query, Con);
                R = cmd.ExecuteNonQuery();
            }
            catch (System.Exception e)
            { e.ToString(); }

            finally
            {
                Con.Close();
            }
            return R;

        }
    }
}