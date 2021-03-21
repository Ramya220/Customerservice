using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Customerservice.Businessobject
{
    public interface IGeneralDataBO
    {
        DataTable GetCustomerDetails(int id);
        bool AddCustomerDetails(string _customername, string _address, string _street, string _country, string _email, long _phone, int _zipcode);

        DataTable GetItemDetails();
        bool Removeitems(int id);

        bool AddItemDetails(string _itemname, int _quantity, decimal _price, bool _webenabled);

        bool  AddSalesOrderDetails(int  _referenceNumber, string _customerName, string _DocDate,string _postingDate,string _address,int _docTotal
                    ,string _state,Int64 _zipcode,string _street,string _country,string _salesPerson,int _itemNo,int _quantityordered,decimal _price,decimal _linetotal);
    }
}