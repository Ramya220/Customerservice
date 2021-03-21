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
    [Authorize]
    public class CustomersalesController : ApiController
    {
        [HttpGet]
        [ActionName("GetCustomerByID")]
        public Customer Get(int id)
        {
            Customer cust = null;
            DataTable dt = CGeneralBOFactory.CreateGeneralDataBO().GetCustomerDetails(id);
            if (dt.Rows.Count > 0 && dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    cust = new Customer();
                    cust.id = Convert.ToInt32(row["id"]);
                    cust.Customername = row["Customername"].ToString();
                    cust.Address = row["Address"].ToString();
                    cust.street = row["street"].ToString();
                    cust.country = row["country"].ToString();
                    cust.email = row["email"].ToString();
                    cust.phone = Convert.ToInt64(row["phone"]);
                    cust.zipcode = Convert.ToInt32(row["zipcode"]);
                }

            }

           
            return cust;

        }

        //[HttpPost]
        //[ActionName("PostCustomer")]
        //public void AddCustomer(Customer customer)
        //{ 
        //}
        public HttpResponseMessage Post([FromBody] Customer customer)
        {
            try 
            {
                //int _id = Convert.ToInt32(customer.id);
                string _customername = customer.Customername.ToString();
                string _address = customer.Address.ToString();
                string _street = customer.street.ToString();
                string _country = customer.country.ToString();
                string _email = customer.email.ToString();
                long _phone = Convert.ToInt64(customer.phone);
                int _zipcode = Convert.ToInt32(customer.zipcode);
                bool _response = CGeneralBOFactory.CreateGeneralDataBO().AddCustomerDetails(_customername,_address,_street,_country,_email,_phone,_zipcode);
                if (_response)
                {
                    var response = Request.CreateResponse(HttpStatusCode.Created, customer);
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
