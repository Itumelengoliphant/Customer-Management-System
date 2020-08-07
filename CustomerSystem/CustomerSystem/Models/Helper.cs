using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerSystem.Models
{
    public static class Helper
    {
        public static void PopulateDataTable(CustomerModel customerModel, DataTable dtblCustomer)
        {
            customerModel.ID = Convert.ToInt32(dtblCustomer.Rows[0][0].ToString());
            customerModel.Name = dtblCustomer.Rows[0][1].ToString();
            customerModel.Surname = dtblCustomer.Rows[0][2].ToString();
            customerModel.Address = dtblCustomer.Rows[0][3].ToString();
            customerModel.Town = dtblCustomer.Rows[0][4].ToString();
            customerModel.Country = dtblCustomer.Rows[0][5].ToString();
            customerModel.Mail = dtblCustomer.Rows[0][6].ToString();
            customerModel.Date_of_birth = Convert.ToDateTime(dtblCustomer.Rows[0][7].ToString());
            customerModel.IsActive = Convert.ToBoolean(dtblCustomer.Rows[0][8].ToString());
            customerModel.Username = dtblCustomer.Rows[0][9].ToString();
            customerModel.Password = dtblCustomer.Rows[0][10].ToString();
            customerModel.Rating = Convert.ToInt32(dtblCustomer.Rows[0][11].ToString());
        }

        public static void CustomerSetup(CustomerModel customer, SqlCommand sqlCmd)
        {
            sqlCmd.Parameters.AddWithValue("@id", customer.ID);
            sqlCmd.Parameters.AddWithValue("@Name", customer.Name);
            sqlCmd.Parameters.AddWithValue("@Surname", customer.Surname);
            sqlCmd.Parameters.AddWithValue("@Address", customer.Address);
            sqlCmd.Parameters.AddWithValue("@Town", customer.Town);
            sqlCmd.Parameters.AddWithValue("@Country", customer.Country);
            sqlCmd.Parameters.AddWithValue("@Mail", customer.Mail);
            sqlCmd.Parameters.AddWithValue("@DOB", customer.Date_of_birth);
            sqlCmd.Parameters.AddWithValue("@IsActive", customer.IsActive);
            sqlCmd.Parameters.AddWithValue("@Username", customer.Username);
            sqlCmd.Parameters.AddWithValue("@Password", customer.Password);
            sqlCmd.Parameters.AddWithValue("@Rating", customer.Rating);
        }
    }
}