using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketing.Models;
namespace Marketing.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        public ActionResult Index()
        {
            return View(Items.GetAll());
        }
        public ActionResult CreateEdit(int ItemID)
        {
            Items ObjItem = new Items();
            if(ItemID>0)
            {
                ObjItem = ObjItem.GetOne(ItemID);
            }
            return View(ObjItem);
        }
        [HttpPost]
        public ActionResult CreateEdit(Items ObjItem,HttpPostedFileBase Photo_File)
        {
            string location = "";
            if (Photo_File != null)
            {
                string pic = Path.GetFileName(Photo_File.FileName);
                location = @"\Image\" + pic;
                string path = Path.Combine(Server.MapPath("~/Image"), pic);
                Photo_File.SaveAs(path);
            }
            ObjItem.Photo_File = location;
            int r = ObjItem.Save();
            if (r > 0)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
        public ActionResult OrderItem(int ItemID ,int UserID)
        {
                int  id = ItemID;
                var list = Session["Cart"] as List<Cart>;
                list.RemoveAll(x => x.ItemID == ItemID);
                Cart ObjCart = new Cart();
                 ObjCart.ItemID = ItemID;
                 ObjCart.RagisID = UserID;
                list.Add(ObjCart);
                Session["Cart"] = list;
            return View(Session["Cart"] as List<Cart>);
        }
         public ActionResult RemoveQty(int ItemID)
        {
            int UserID = (int)System.Web.HttpContext.Current.Session["RagisID"];
            int id = ItemID;
            //List<OrderItems> orderItems = OrderItems.GetAll();
            //orderItems = orderItems.FindAll(x=>x.RagisID== UserID);
            var list = Session["Cart"] as List<Cart>;
            list.RemoveAll(x => x.ItemID == ItemID);
            //orderItems.RemoveAll(x => x.ItemID == ItemID);
            return RedirectToAction("OrderItem");
        }
        public ActionResult UpdateQty(int ItemID, int Inputvalue, int Prize, int Qty)
        {
            int UserID = (int)System.Web.HttpContext.Current.Session["RagisID"];
            int Id = ItemID;
            int Count = Inputvalue;
            int UnitPrize = Prize;
            int UnitQty = Qty;
             OrderItems ObjOrderitems = new OrderItems().GetOne(Id); ;
            if (Inputvalue >= 0)
            {
                 
                ObjOrderitems.Count = Count;
                ObjOrderitems.Save();

            }
            return RedirectToAction("OrderItem", new { ItemID=Id  ,UserID=UserID });
        }
    }
}