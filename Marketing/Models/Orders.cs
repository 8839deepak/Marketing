using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marketing.Models
{
    public class Orders
    {
        public int OID { get; set; }
        public List<NewOrders> NewOrders { get; set; }
        //public string ProductName { get; set; }
        //public int ProductPrize { get; set; }
        //public string Qty { get; set; }
        //public int TotalQty { get; set; }
        //public int PrizeTotal { get; set; }
         public int RagisID { get; set; }
         public  DateTime Create_Date { get; set; }
        public int Save()
        {
            int Row = 0;
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            try
            {
                string Quary = "";
                if (this.OID == 0)
                {
                    Quary = "insert into Orders  values(@Create_Date,@RagisID)";
                }
                cmd = new SqlCommand(Quary, dBCon.Con);
                cmd.Parameters.AddWithValue("@OID", this.OID);
                cmd.Parameters.AddWithValue("@Create_Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@RagisID", this. RagisID );
                    Row = cmd.ExecuteNonQuery();
            }
            catch (Exception e) { e.ToString(); }
            finally { cmd.Dispose(); dBCon.Con.Close(); }
            return Row;
        }
        public List<Orders> GetAll()
        {
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            List<Orders> listItem = new List<Orders>();
            try
            {
                string Quary = "Select * From Orders   ORDER BY  OID DESC";
                cmd = new SqlCommand(Quary, dBCon.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    listItem.Add(new Orders()
                    {
                        OID = SDR.GetInt32(0),
                        Create_Date = SDR.GetDateTime(1),
                        RagisID = SDR.GetInt32(2),
                    });

                }
            }
            catch (Exception e) { e.ToString(); }
            finally { cmd.Dispose(); dBCon.Con.Close(); }
            return (listItem);
        }
    }
    public class NewOrders
    {
        public int NID { get; set; }
        public int OID { get; set; }
        public string ProductName { get; set; }
        public int ProductPrize { get; set; }
        public int Qty { get; set; }
        public int TotalQty { get; set; }
        public int PrizeTotal { get; set; }
        public int RagisID { get; set; }
        public DateTime Create_Date { get; set; }
        public int Save()
        {
            int Row = 0;
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            try
            {
                string Quary = "";
                if (this.NID == 0)
                {
                    Quary = "insert into NewOrders values(@OID,@ProductName,@ProductPrize,@Qty,@TotalQty,@PrizeTotal,@RagisID,@Create_Date);";
                }
                cmd = new SqlCommand(Quary, dBCon.Con);
                cmd.Parameters.AddWithValue("@NID", this.NID);
                cmd.Parameters.AddWithValue("@OID", this.OID);
                cmd.Parameters.AddWithValue("@ProductName", this.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrize", this.ProductPrize);
                cmd.Parameters.AddWithValue("@Qty", this.Qty);
                cmd.Parameters.AddWithValue("@TotalQty", this.TotalQty);
                cmd.Parameters.AddWithValue("@PrizeTotal", this.PrizeTotal);
                cmd.Parameters.AddWithValue("@RagisID", this.RagisID);
                cmd.Parameters.AddWithValue("@Create_Date", DateTime.Now);
                    Row = cmd.ExecuteNonQuery();
            }
            catch (Exception e) { e.ToString(); }
            finally { cmd.Dispose(); dBCon.Con.Close(); }
            return Row;
        }
        public List<NewOrders> GetAll()
        {
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            List<NewOrders> listItem = new List<NewOrders>();
            try
            {
                string Quary = "Select *From NewOrders ORDER BY  NID DESC";
                cmd = new SqlCommand(Quary, dBCon.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    listItem.Add(new NewOrders()
                    {
                        NID = SDR.GetInt32(0),
                        OID = SDR.GetInt32(1),
                        ProductName = SDR.GetString(2),
                        ProductPrize = SDR.GetInt32(3),
                        Qty = SDR.GetInt32(4),
                        TotalQty = SDR.GetInt32(5),
                        PrizeTotal = SDR.GetInt32(6),
                        RagisID = SDR.GetInt32(7),
                        Create_Date = SDR.GetDateTime(8),
                    });

                }
            }
            catch (Exception e) { e.ToString(); }
            finally { cmd.Dispose(); dBCon.Con.Close(); }
            return (listItem);
        }
        
        public List<NewOrders>GroupbyRagisID()
        {
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            List<NewOrders> listItem = new List<NewOrders>();
            try
            {
                string Quary = "Select RagisID From NewOrders  group by RagisID";
                cmd = new SqlCommand(Quary, dBCon.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    listItem.Add(new NewOrders()
                    {
                        
                        RagisID = SDR.GetInt32(0),
                        //Create_Date = SDR.GetDateTime(0),
                    });

                }
            }
            catch (IndexOutOfRangeException e) { e.ToString(); }
            finally { cmd.Dispose(); dBCon.Con.Close(); }
            return (listItem);
        }
    }
    
   
}