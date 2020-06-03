using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marketing.Models
{
    public class Items
    {
        public int ItemID { get; set; }
        public string Photo_File { get; set; }
        public string Name { get; set; }
        public int Prize { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CatID { get; set; }
        public int QunID { get; set; }
        public List<Orders> listOrder { get; set; }
        public int Save()
        {
            int Row = 0;
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            try
            {
                string Quary = "";
                if (this.ItemID == 0)
                {
                    Quary = "Insert Into Items values (@Photo_File,@Name,@Prize,@CreateBy,@CreateDate,@UpdateBy,@UpdateDate,@CatID,@QunID)";
                }
                else
                {
                    Quary = "Update Items Set Photo_File=@Photo_File,Name=@Name,Prize=@Prize,CreateBy=@CreateBy,CreateDate=@CreateDate,UpdateBy=@UpdateBy,UpdateDate=@UpdateDate,CatID=@CatID,QunID=@QunID where ItemID=@ItemID";
                }
                cmd = new SqlCommand(Quary, dBCon.Con);
                cmd.Parameters.AddWithValue("@ItemID", this.ItemID);
                cmd.Parameters.AddWithValue("@Photo_File", this.Photo_File);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@Prize", this.Prize);
                cmd.Parameters.AddWithValue("@CreateBy", this.CreateBy);
                cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdateBy", this.UpdateBy);
                cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@CatID", this.CatID);
                cmd.Parameters.AddWithValue("@QunID", this.QunID);
                if (this.ItemID == 0)
                {
                    Row = Convert.ToInt32(cmd.ExecuteScalar());
                    this.ItemID = Row;
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
        public static List<Items> GetAll()
        {
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            List<Items> listItem = new List<Items>();
            try
            {
                string Quary = "Select * From Items  ORDER BY  ItemID DESC";
                cmd = new SqlCommand(Quary, dBCon.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    listItem.Add(new Items()
                    {
                        ItemID = SDR.GetInt32(0),
                        Photo_File = SDR.GetString(1),
                        Name = SDR.GetString(2),
                        Prize = SDR.GetInt32(3),
                        CatID = SDR.GetInt32(8),
                        QunID = SDR.GetInt32(9)
                    });

                }
            }
            catch (Exception e) { e.ToString(); }
            finally { cmd.Dispose(); dBCon.Con.Close(); }
            return (listItem);
        }
        public Items GetOne(int ID)
        {
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            Items ObjTmp = new Items();
            try
            {
                string Query = "SELECT * FROM  Items where  ItemID=" + ID;
                cmd = new SqlCommand(Query, dBCon.Con);
                cmd.Parameters.AddWithValue("@ItemID", ID);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    ObjTmp.ItemID = SDR.GetInt32(0);
                    ObjTmp.Photo_File = SDR.GetString(1);
                    ObjTmp.Name = SDR.GetString(2);
                    ObjTmp.Prize = SDR.GetInt32(3);
                    ObjTmp.CatID = SDR.GetInt32(8);
                    ObjTmp.QunID = SDR.GetInt32(9);
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
                string Query = "Delete FROM  Items where ItemID=" + ID;
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