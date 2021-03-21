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
    public class SalesorderController : ApiController
    {
        public HttpResponseMessage Post([FromBody] Sales sales)
        {
            try
            {

                int  _referenceNumber = Convert.ToInt32(sales.ReferenceNumber);
                string _customerName = sales.CustomerName.ToString();
                string _DocDate = sales.DocDate.ToString();
                string _postingDate = sales.PostingDate.ToString();
                string _address = sales.Address.ToString();
                int _docTotal = Convert.ToInt32(sales.DocTotal);
                string _state = sales.State.ToString();
                long _zipcode = Convert.ToInt64(sales.Zipcode);
                string _street = sales.Street.ToString();
                string _country = sales.Country.ToString();
                string _salesPerson = sales.SalesPerson.ToString();
                int _itemNo = Convert.ToInt32(sales.ItemNo);
                int _quantityordered = Convert.ToInt32(sales.Quantityordered);
                decimal _price = Convert.ToDecimal(sales.Price);
                decimal _linetotal = Convert.ToDecimal(sales.linetotal);
                bool _response = CGeneralBOFactory.CreateGeneralDataBO().AddSalesOrderDetails(_referenceNumber,_customerName,_DocDate,_postingDate,_address,_docTotal
                    ,_state,_zipcode,_street,_country,_salesPerson,_itemNo,_quantityordered,_price,_linetotal);
                if (_response)
                {
                    var response = Request.CreateResponse(HttpStatusCode.Created, sales);
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
