using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marketing.Models
{
    public class Ragistation
    {
        public int RagisID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime Create_Date { get; set; }
        public int Save()
        {
            int Row = 0;
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            try
            {
                string Quary = "";
                if (this.RagisID == 0)
                    Quary = "Insert Into Ragistation values (@Name,@Mobile,@Address,@City,@Create_Date)";
                cmd = new SqlCommand(Quary, dBCon.Con);
                cmd.Parameters.AddWithValue("@RagisID", this.RagisID);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@Mobile", this.Mobile);
                cmd.Parameters.AddWithValue("@Address", this.Address);
                cmd.Parameters.AddWithValue("@City", this.City);
                cmd.Parameters.AddWithValue("@Create_Date", DateTime.Now);
                Row = cmd.ExecuteNonQuery();
            }
            catch (Exception e) { e.ToString(); }
            finally { cmd.Dispose(); dBCon.Con.Close(); }
            return Row;
        }
        public   List<Ragistation> GetAll()
        {
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            SqlDataReader SDR = null;
            List<Ragistation> listRagistation = new List<Ragistation>();
            try
            {
                string Quary = "Select * From Ragistation ";
                cmd = new SqlCommand(Quary, dBCon.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    listRagistation.Add(new Ragistation()
                    {
                        RagisID = SDR.GetInt32(0),
                        Name = SDR.GetString(1),
                        Mobile = SDR.GetString(2),
                        Address = SDR.GetString(3),
                        City = SDR.GetString(4),
                        Create_Date=SDR.GetDateTime(5)
                    });

                }
            }
            catch (Exception e) { e.ToString(); }
            finally { cmd.Dispose(); dBCon.Con.Close(); }
            return (listRagistation);
        }
        public int Dell(int ID)
        {
            int R = 0;
            DBCon dBCon = new DBCon();
            SqlCommand cmd = null;
            try
            {
                string Query = "Delete FROM  Ragistation where RagisID=" + ID;
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