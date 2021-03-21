using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Customerservice.DataAccessLayer
{
    public class CGeneralDAC
    {
        public DataTable GetCustomerDetails(int id)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt;
            string str = ConfigurationManager.ConnectionStrings["Customerorder"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Customer_Master where id=" + id + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            try
            {
                con.Open();
            }
            catch
            { }
            int i = cmd.ExecuteNonQuery();
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;



        }
        public bool AddCustomerDetails(string _customername, string _address, string _street, string _country, string _email, long _phone, int _zipcode)
        {
            SqlCommand cmd = new SqlCommand();

            string str = ConfigurationManager.ConnectionStrings["Customerorder"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AddCustomers";
            cmd.Parameters.AddWithValue("@Customername", _customername);
            cmd.Parameters.AddWithValue("@Address", _address);
            cmd.Parameters.AddWithValue("@Street", _street);
            cmd.Parameters.AddWithValue("@Country", _country);
            cmd.Parameters.AddWithValue("@Email", _email);
            cmd.Parameters.AddWithValue("@Phone", _phone);
            cmd.Parameters.AddWithValue("@Zipcode", _zipcode);
            SqlParameter _response = cmd.Parameters.Add("@Result", SqlDbType.Bit);
            _response.Direction = ParameterDirection.Output;
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                return (bool)_response.Value;
            }
            catch
            {

            }

            return (bool)_response.Value;

        }

        public DataTable GetItemDetails()
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt;
            string str = ConfigurationManager.ConnectionStrings["Customerorder"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from ItemMaster";
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            try
            {
                con.Open();
            }
            catch
            { }
            int i = cmd.ExecuteNonQuery();
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public bool Removeitems(int id)
        {
            SqlCommand cmd = new SqlCommand();

            string str = ConfigurationManager.ConnectionStrings["Customerorder"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteItems";
            cmd.Parameters.AddWithValue("@Itemno", id);


            SqlParameter _response = cmd.Parameters.Add("@Result", SqlDbType.Bit);
            _response.Direction = ParameterDirection.Output;
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                return (bool)_response.Value;
            }
            catch
            {

            }

            return (bool)_response.Value;

        }

        public bool AddItemDetails(string _itemname, int _quantity, decimal _price, bool _webenabled)
        {
            SqlCommand cmd = new SqlCommand();

            string str = ConfigurationManager.ConnectionStrings["Customerorder"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Additems";
            cmd.Parameters.AddWithValue("@Itemname", _itemname);
            cmd.Parameters.AddWithValue("@Quantity", _quantity);
            cmd.Parameters.AddWithValue("@Price", _price);
            cmd.Parameters.AddWithValue("@Webenabled", _webenabled);

            SqlParameter _response = cmd.Parameters.Add("@Result", SqlDbType.Bit);
            _response.Direction = ParameterDirection.Output;
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                return (bool)_response.Value;
            }
            catch
            {

            }

            return (bool)_response.Value;

        }

        public bool AddSalesOrderDetails(int _referenceNumber, string _customerName, string _DocDate, string _postingDate, string _address, int _docTotal
                    , string _state, Int64 _zipcode, string _street, string _country, string _salesPerson, int _itemNo, int _quantityordered, decimal _price, decimal _linetotal)
        {
            SqlCommand cmd = new SqlCommand();

            string str = ConfigurationManager.ConnectionStrings["Customerorder"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AddSalesDetails";
            cmd.Parameters.AddWithValue("@ReferenceNumber", _referenceNumber);
            cmd.Parameters.AddWithValue("@CustomerName", _customerName);
            cmd.Parameters.AddWithValue("@DocDate", _DocDate);
            cmd.Parameters.AddWithValue("@PostingDate", _postingDate);
            cmd.Parameters.AddWithValue("@Address", _address);
            cmd.Parameters.AddWithValue("@DocTotal", _docTotal);
            cmd.Parameters.AddWithValue("@State", _state);
            cmd.Parameters.AddWithValue("@Zipcode", _zipcode);
            cmd.Parameters.AddWithValue("@Street", _street);
            cmd.Parameters.AddWithValue("@Country", _country);
            cmd.Parameters.AddWithValue("@price", _price);
            cmd.Parameters.AddWithValue("@SalesPerson", _salesPerson);
            cmd.Parameters.AddWithValue("@ItemNo", _itemNo);
            cmd.Parameters.AddWithValue("@Quantityordered", _quantityordered);
            cmd.Parameters.AddWithValue("@linetotal", _linetotal);
            SqlParameter _response = cmd.Parameters.Add("@Result", SqlDbType.Bit);
            _response.Direction = ParameterDirection.Output;
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                return (bool)_response.Value;
            }
            catch
            {

            }

            return (bool)_response.Value;

        }

        public DataTable LoginByUsernamePassword(string usernameVal, string passwordVal)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt;
            string str = ConfigurationManager.ConnectionStrings["Customerorder"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoginByUsernamePassword";
            cmd.Parameters.AddWithValue("@username", usernameVal);
            cmd.Parameters.AddWithValue("@password", passwordVal);
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            try
            {
                con.Open();
            }
            catch
            { }
            int i = cmd.ExecuteNonQuery();
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}