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
            List<NewOrders> listneworder = new NewOrders().GetAll();
            var myDate = new DateTime(dateTime.Year, dateTime.Day, dateTime.Month);
            listneworder = listneworder.FindAll(x => x.Create_Date == myDate);
            return View(listneworder);
        }
        public ActionResult NewOrderIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEdit([System.Web.Http.FromBody] Orders ObjItems)
        {
            Orders ObjItem = ObjItems;
            ObjItem.Save();
            List<NewOrders> listorder =  ObjItem.NewOrders;
            foreach(var order in listorder )
            {
                ObjItem.OID = order.OID;
                order.Save();
            }
            return Json(new { url = "/Home/ItemLoadFunction" });
        }
    }
}