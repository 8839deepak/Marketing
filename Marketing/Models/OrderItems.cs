using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Marketing.Models;
namespace Marketing.Models
{
    public class OrderItems
    {
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int QTY { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Prize { get; set; }
        public int RagisID { get; set; }
        public int Save()
        {
            int Row = 0;
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            try
            {
                string Quary = "";
                if (this.OrderID == 0)
                {
                    Quary = "Insert Into OrderItems values (@ItemID,@QTY,@Name,@Count,@Prize,@RagisID)";
                }
                else
                {
                    Quary = "Update OrderItems Set ItemID=@ItemID,QTY=@QTY,Name=@Name,Count=@Count,Prize=@Prize ,RagisID=@RagisID where OrderID=@OrderID";
                }
                cmd = new SqlCommand(Quary, dBCon.Con);
                cmd.Parameters.AddWithValue("@OrderID", this.OrderID);
                cmd.Parameters.AddWithValue("@ItemID", this.ItemID);
                cmd.Parameters.AddWithValue("@QTY", this.QTY);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@Count", this.Count);
                cmd.Parameters.AddWithValue("@Prize", this.Prize);
                cmd.Parameters.AddWithValue("@RagisID", this.RagisID);
                if (this.OrderID == 0)
                {
                    Row = Convert.ToInt32(cmd.ExecuteScalar());
                    this.OrderID = Row;
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
        public static List<OrderItems> GetAll()
        {
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            List<OrderItems> listItem = new List<OrderItems>();
            try
            {
                string Quary = "Select * From OrderItems  ORDER BY  OrderID DESC";
                cmd = new SqlCommand(Quary, dBCon.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    listItem.Add(new OrderItems()
                    {
                        OrderID = SDR.GetInt32(0),
                        ItemID = SDR.GetInt32(1),
                        QTY = SDR.GetInt32(2),
                        Name = SDR.GetString(3),
                        Count = SDR.GetInt32(4),
                        Prize = SDR.GetInt32(5),
                        RagisID = SDR.GetInt32(6),
                    });

                }
            }
            catch (Exception e) { e.ToString(); }
            finally { cmd.Dispose(); dBCon.Con.Close(); }
            return (listItem);
        }
        public OrderItems GetOne(int ID)
        {
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            OrderItems ObjTmp = new OrderItems();
            try
            {
                string Query = "SELECT * FROM  OrderItems where  ItemID=" + ID;
                cmd = new SqlCommand(Query, dBCon.Con);
                cmd.Parameters.AddWithValue("@ItemID", ID);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    ObjTmp.OrderID = SDR.GetInt32(0);
                    ObjTmp.ItemID = SDR.GetInt32(1);
                    ObjTmp.QTY = SDR.GetInt32(2);
                    ObjTmp.Name = SDR.GetString(3);
                    ObjTmp.Count = SDR.GetInt32(4);
                    ObjTmp.Prize = SDR.GetInt32(5);
                    ObjTmp.RagisID = SDR.GetInt32(6);
                  
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
                string Query = "Delete FROM  OrderItems where ItemID=" + ID;
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