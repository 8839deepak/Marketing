using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketing.Models;
using Newtonsoft.Json.Linq;

namespace Marketing.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index( DateTime dateTime)
        {
            Ragistation ObjRagistation = new Ragistation();
            //List<Ragistation> ragistations = ObjRagistation.GetAll();
            List<NewOrders> listneworder = new NewOrders().GroupbyRagisID();
            var myDate = new DateTime(dateTime.Year, dateTime.Day, dateTime.Month);
            listneworder = listneworder.FindAll(x => x.Create_Date == myDate);

            return View(listneworder);
        }
        public ActionResult NewOrderIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEdit([System.Web.Http.FromBody] Orders ObjItems )
        {
            int ID = int.Parse(Session["RagisID"].ToString());
            Orders ObjItem = ObjItems;
            //int d = ObjItem.Save();
            var dateTime = DateTime.Today;
            var myDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            ObjItem.RagisID = ID;
            int d = ObjItem.Save();
            List<Orders> orderlist = new Orders().GetAll();
            Orders Objorder = orderlist.Find(x => x.Create_Date == myDate);
            //if (d!=0)
            //{
            //    getOrdersession(Objorder.Create_Date);
            //}
            List<NewOrders> listorder =  ObjItem.NewOrders;
            foreach(var order in listorder )
            {
               //order.OID = ID ;
                order.Save();
            }
            return Json(new { url = "/Home/ItemLoadFunction" });
        }
        //public ActionResult getOrdersession(System.DateTime Createdate)
        //{
        //    List<Orders> listOrders = new Orders().GetAll();
        //    listOrders = listOrders.FindAll(x => x.Create_Date == Createdate);
        //    foreach (var hh in listOrders)
        //    {
        //        var getragistation = listOrders.FindAll(x => x.OID == hh.OID);
        //        Session["OID"] = hh.OID;
        //    }
        //    return View(listOrders);
        //}
    }
}