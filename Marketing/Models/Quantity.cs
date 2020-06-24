using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marketing.Models
{
    public class Quantity
    {
        public int QunID { get; set; }
        public string Name { get; set; }
        
        //public int Save()
        //{
        //    int Row = 0;
        //    DBCon ObjDbCon = new DBCon();
        //    SqlCommand cmd = null;
        //    try
        //    {
        //        string Quary = "";
        //        if (this.QunID == 0)
        //        {
        //            Quary = "Insert Into Quantity values(@Name); ";
        //        }
        //        else
        //        {
        //            Quary = "Update Quantity Set Name=@Name, ItemID=@ItemID,CatID=@CatID Where QunID=@QunID";
        //        }
        //        cmd = new SqlCommand(Quary, ObjDbCon.Con);
        //        cmd.Parameters.AddWithValue("@QunID", this.QunID);
        //        cmd.Parameters.AddWithValue("@Name", this.Name);
        //        cmd.Parameters.AddWithValue("@ItemID", this.ItemID);
        //        cmd.Parameters.AddWithValue("@CatID", this.CatID);

        //        if (this.QunID == 0)
        //        {
        //            Row = Convert.ToInt32(cmd.ExecuteScalar());
        //            this.QunID = Row;
        //        }
        //        else
        //        {
        //            Row = cmd.ExecuteNonQuery();
        //            //this.QuantityQunID = Row;
        //        }

        //    }
        //    catch (Exception e) { e.ToString(); }
        //    finally { cmd.Dispose(); ObjDbCon.Con.Close(); }
        //    return Row;
        //}
        public static List<Quantity> GetAll()
        {
            DBCon ObjDbCon = new DBCon();

            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            List<Quantity> Quantitylist = new List<Quantity>();
            try
            {
                string Query = "Select *From Quantity ORDER BY  QunID DESC";
                cmd = new SqlCommand(Query, ObjDbCon.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    Quantitylist.Add(new Quantity() { QunID = SDR.GetInt32(0), Name = SDR.GetString(1) });
                }
            }
            catch (System.Exception e) { e.ToString(); }
            finally { cmd.Dispose(); ObjDbCon.Con.Close(); }
            return (Quantitylist);
        }
        //public Quantity GetOne(int QunID)
        //{
        //    SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Con"].ToString());
        //    Con.Open();
        //    SqlCommand cmd = null;
        //    SqlDataReader SDR = null;
        //    Quantity ObjTmp = new Quantity();
        //    try
        //    {
        //        string Query = "SELECT * FROM  Quantity where  QunID=" + QunID;
        //        cmd = new SqlCommand(Query, Con);
        //        cmd.Parameters.AddWithValue("@QunID", QunID);
        //        SDR = cmd.ExecuteReader();
        //        while (SDR.Read())
        //        {
        //            ObjTmp.QunID = SDR.GetInt32(0);
        //            ObjTmp.Name = SDR.GetString(1);
        //            ObjTmp.ItemID = SDR.GetInt32(2);
        //            ObjTmp.CatID = SDR.GetInt32(3);
        //        }
        //    }
        //    catch (System.Exception e) { e.ToString(); }
        //    finally { cmd.Dispose(); Con.Close(); }

        //    return (ObjTmp);
        //}
        //public int Dell(int QunID)
        //{
        //    int R = 0;
        //    SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Con"].ToString());
        //    Con.Open();
        //    SqlCommand cmd = null;
        //    try
        //    {
        //        string Query = "Delete FROM  Quantity where QunID=" + QunID;
        //        cmd = new SqlCommand(Query, Con);
        //        R = cmd.ExecuteNonQuery();
        //    }
        //    catch (System.Exception e)
        //    { e.ToString(); }

        //    finally
        //    {
        //        Con.Close();
        //    }
        //    return R;

        //}
    }
}