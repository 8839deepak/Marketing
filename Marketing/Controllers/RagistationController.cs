using Marketing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketing.Controllers
{
    public class RagistationController : Controller
    {
        // GET: Ragistation
        public ActionResult Index()
        {
            return View(new Ragistation().GetAll());
        }
        public ActionResult Delete(int ID)
        {
            Ragistation ObjUser = new Ragistation();
            int d = ObjUser.Dell(ID);
            if (d > 0)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }/*string Mobile, string Name, string City, string Address*/
        [HttpPost]
        public ActionResult RagisterSave(string Mobile, string Name, string City, string Address,DateTime today)
        {
            Ragistation ragistation = new Ragistation();
            ragistation.Mobile = Mobile;
            ragistation.Name = Name;
            ragistation.City = City;
            ragistation.Address = Address;
            ragistation.Create_Date = today;
            int d = ragistation.Save();
            if(d!=0)
            {
                getsession(ragistation.Create_Date);
               

            }
            return RedirectToAction("ItemLoadFunction","Home");
        }
        public ActionResult getsession(System.DateTime Createdate)
        {
            List<Ragistation> listragistation = new Ragistation().GetAll();
            listragistation = listragistation.FindAll(x=>x.Create_Date==Createdate);
            foreach(var hh in listragistation)
            {
              var getragistation = listragistation.FindAll(x=>x.RagisID==hh.RagisID);
                Session["RagisID"] = hh.RagisID;
                Session["Name"] = hh.Name;
            }
            return View(listragistation);
        }
    }
}