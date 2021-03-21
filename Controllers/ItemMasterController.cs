using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Customerservice.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Customerservice.Businessobject;

namespace Customerservice.Controllers
{
    public class ItemMasterController : ApiController
    {
        
        public HttpResponseMessage Get()
        {
            try
            {
                Item cust = null;
                DataTable dt = CGeneralBOFactory.CreateGeneralDataBO().GetItemDetails();
                List<Item> list = new List<Item>();
               
                
                if (dt.Rows.Count > 0 && dt != null)
                {
                 

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cust = new Item();
                        cust.itemcode = Convert.ToInt32(dt.Rows[i]["itemcode"]);
                        cust.itemname = dt.Rows[i]["itemname"].ToString();
                        cust.QuantityonHand = Convert.ToInt32(dt.Rows[i]["QuantityonHand"]);
                        cust.price = Convert.ToDecimal(dt.Rows[i]["price"]);
                        cust.webenabled = Convert.ToBoolean(dt.Rows[i]["webenabled"]);
                        
                        list.Add(cust);
                    }

                }
                return Request.CreateResponse(HttpStatusCode.Found, list.ToList());
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }
        }
        public HttpResponseMessage Delete(int itemcode)
        {
            try
            {
                bool _response = CGeneralBOFactory.CreateGeneralDataBO().Removeitems(itemcode);
                if (!_response)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product not found to delete");
               

                return Request.CreateResponse(HttpStatusCode.OK, "Product Deleted Successfully");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product not deleted");
            }
        }
        public HttpResponseMessage Post([FromBody] Item item)
        {
            try
            {
                
                string _itemname = item.itemname.ToString();
                int _quantity = Convert.ToInt32(item.QuantityonHand);
                decimal _price = Convert.ToDecimal(item.QuantityonHand);
                bool _webenabled = Convert.ToBoolean(item.webenabled);
                bool _response = CGeneralBOFactory.CreateGeneralDataBO().AddItemDetails(_itemname, _quantity, _price, _webenabled);
                if (_response)
                {
                    var response = Request.CreateResponse(HttpStatusCode.Created, item);
                    response.Headers.Location = Request.RequestUri;
                    return response;
                }
                else
                {
                    throw new Exception();

                }
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Data not inserted");
            }
        }
    }
}
