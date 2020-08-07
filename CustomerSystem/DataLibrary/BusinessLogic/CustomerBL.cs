using CustomerSystem.Queries;
using DataLib.BusinessLogic;
using DataLib.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
   public static class CustomerBL
    {
        public static int CreateCustomer(int id, string name, string surname, string address,
                                        string town, string country, string mail, DateTime dob, bool status,
                                        string username, string password, int rating)
        {
            CustModel customer = new CustModel
            {
                ID = id, Name = name, Surname = surname, Address = address,
                Town = town, Country = country, Mail = mail, DOB = dob,
                IsActive = status, Username = username, Password = password, Rating = rating
            };

            string sql = @"INSERT INTO [dbo].[CustomerDB]
           (
           [Name]
           ,[Surname]
           ,[Address]
           ,[Town]
           ,[Country]
           ,[Mail]
           ,[DOB]
           ,[IsActive]
           ,[Username]
           ,[Password]
           ,[Rating])
     VALUES
           (
           @Name,
           @Surname,
           @Address,
           @Town,
           @Country,
           @Mail,
           @DOB,
           @IsActive,
           @Username,
           @Password,
           @Rating)";

            return SQLDataAccess.SaveData<CustModel>(sql, customer);
        }

        public static List<CustModel> ListAllCustomers()
        {
            string sql = @"SELECT
                        [CustomerID]
                        ,[Name]
                        ,[Surname]
                        ,[Address]
                        ,[Town]
                        ,[Country]
                        ,[Mail]
                        ,[DOB]
                        ,[IsActive]
                        ,[Username]
                        ,[Password]
                        ,[Rating]
                        FROM [Customer_SysDB].[dbo].[CustomerDB]";

            return SQLDataAccess.GetData<CustModel>(sql);
        }

        public static bool RemoveItem(int id)
        {
            return SQLDataAccess.RemoveData<CustModel>("@CustomerID", "spRemoveCustomer", id);
        }

        public static int UpdateItem(int id,DataTable dt)
        {
            return SQLDataAccess.UpdateData(QueryRepository.SingleSelect(), id, dt);
        }

        public static int UserDetail(int id, DataTable dt)
        {
            return SQLDataAccess.UpdateData(QueryRepository.SingleSelect(), id, dt);
        }
    }
}
