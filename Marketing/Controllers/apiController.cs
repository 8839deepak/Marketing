using Marketing.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marketing.Controllers
{
    public class apiController : ApiController
    {
        [HttpPost]
        public JObject CreateEdit([System.Web.Http.FromBody] Orders ObjItems)
        {
            Orders ObjItem = new Orders();
            List<Orders> listorder = ObjItem.GetAll();
            foreach (var order in listorder)
            {

                order.Save();
            }
            return JObject.FromObject(ObjItem);

        }
        [HttpPost]
        public JObject QuamtityList(int QuntID)
        {
            List<Quantity> listquantity = Quantity.GetAll();
            var AllQuantityLst = listquantity.FindAll(x=>x.QunID==QuntID);
            return JObject.FromObject(AllQuantityLst);
        }
        public JObject Itemslist(int itemid)
        {
            List<Items> listitems = Items.GetAll();
            var allItems = listitems.FindAll(x=>x.ItemID==itemid);
            return JObject.FromObject(allItems);
        }
    }
}
