using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Customerservice.DataAccessLayer;

namespace Customerservice.Businessobject
{
    public class GeneralBO : IGeneralDataBO
    {
        public DataTable GetCustomerDetails(int id)
        {
            CGeneralDAC _daclayer = new CGeneralDAC();

            return _daclayer.GetCustomerDetails(id);
        }
        public bool AddCustomerDetails(string _customername, string _address, string _street, string _country, string _email, long _phone, int _zipcode)

        {

            CGeneralDAC _daclayer = new CGeneralDAC();

            return _daclayer.AddCustomerDetails(_customername, _address, _street, _country, _email, _phone, _zipcode);
        }
        public DataTable GetItemDetails()
        {
            CGeneralDAC _daclayer = new CGeneralDAC();

            return _daclayer.GetItemDetails();
        }

        public bool Removeitems(int id)
        {
            CGeneralDAC _daclayer = new CGeneralDAC();

            return _daclayer.Removeitems(id);
        }

        public bool AddItemDetails(string _itemname, int _quantity, decimal _price, bool _webenabled)
        {
            CGeneralDAC _daclayer = new CGeneralDAC();

            return _daclayer.AddItemDetails(_itemname, _quantity, _price, _webenabled);
        }

        public bool AddSalesOrderDetails(int _referenceNumber, string _customerName, string _DocDate, string _postingDate, string _address, int _docTotal
                    , string _state, Int64 _zipcode, string _street, string _country, string _salesPerson, int _itemNo, int _quantityordered, decimal _price, decimal _linetotal)
        {
            CGeneralDAC _daclayer = new CGeneralDAC();

            return _daclayer.AddSalesOrderDetails(_referenceNumber, _customerName, _DocDate, _postingDate, _address, _docTotal
                    , _state, _zipcode, _street, _country, _salesPerson, _itemNo, _quantityordered, _price, _linetotal);

        }

    }
}