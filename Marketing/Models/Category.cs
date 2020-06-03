using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marketing.Models
{
    public class Category
    {
        public int CatID { get; set; }
        public string Name { get; set; }
        public int Save()
        {
            int Row = 0;
            DBCon ObjDbCon = new DBCon();
            SqlCommand cmd = null;
            try
            {
                string Quary = "";
                if (this.CatID == 0)
                {
                    Quary = "Insert Into Category values(@Name); ";
                }
                else
                {
                    Quary = "Update Category Set Name=@Name Where CatID=@CatID";
                }
                cmd = new SqlCommand(Quary, ObjDbCon.Con);
                cmd.Parameters.AddWithValue("@CatID", this.CatID);
                cmd.Parameters.AddWithValue("@Name", this.Name);

                if (this.CatID == 0)
                {
                    Row = Convert.ToInt32(cmd.ExecuteScalar());
                    this.CatID = Row;
                }
                else
                {
                    Row = cmd.ExecuteNonQuery();
                    //this.CategoryCatID = Row;
                }

            }
            catch (Exception e) { e.ToString(); }
            finally { cmd.Dispose(); ObjDbCon.Con.Close(); }
            return Row;
        }
        public static List<Category> GetAll()
        {
            DBCon ObjDbCon = new DBCon();

            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            List<Category> Categorylist = new List<Category>();
            try
            {
                string Query = "Select *From Category ORDER BY  CatID DESC";
                cmd = new SqlCommand(Query, ObjDbCon.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    Categorylist.Add(new Category() { CatID = SDR.GetInt32(0), Name = SDR.GetString(1) });
                }
            }
            catch (System.Exception e) { e.ToString(); }
            finally { cmd.Dispose(); ObjDbCon.Con.Close(); }
            return (Categorylist);
        }
        public Category GetOne(int CatID)
        {
            SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Con"].ToString());
            Con.Open();
            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            Category ObjTmp = new Category();
            try
            {
                string Query = "SELECT * FROM  Category where  CatID=" + CatID;
                cmd = new SqlCommand(Query, Con);
                cmd.Parameters.AddWithValue("@CatID", CatID);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    ObjTmp.CatID = SDR.GetInt32(0);
                    ObjTmp.Name = SDR.GetString(1);
                }
            }
            catch (System.Exception e) { e.ToString(); }
            finally { cmd.Dispose(); Con.Close(); }

            return (ObjTmp);
        }
        public int Dell(int CatID)
        {
            int R = 0;
            SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Con"].ToString());
            Con.Open();
            SqlCommand cmd = null;
            try
            {
                string Query = "Delete FROM  Category where CatID=" + CatID;
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