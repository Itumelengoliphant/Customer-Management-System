using DataLib.Model;
using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;

namespace DataLib.BusinessLogic
{
    public static class SQLDataAccess
    {
        public static int Add(CustModel customer)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                int result;

                using (SqlCommand command = new SqlCommand("", connection))
                {
                    command.Parameters.AddWithValue("@ID", customer.ID);
                    command.Parameters.AddWithValue("@CustID", customer.CustomerID);
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Surname", customer.Surname);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@Town", customer.Town);
                    command.Parameters.AddWithValue("@Mail", customer.Mail);
                    command.Parameters.AddWithValue("@IsActive", customer.IsActive);
                    command.Parameters.AddWithValue("@Rating", customer.Rating);
                    command.Parameters.AddWithValue("@Username", customer.Username);
                    command.Parameters.AddWithValue("@Password", customer.Password);
                    command.Parameters.AddWithValue("@Country", customer.Country);
                    command.Parameters.AddWithValue("@DOB", customer.DOB);

                    connection.Open();

                    result = command.ExecuteNonQuery();

                    connection.Close();
                }

                return result;
            }
        }

        public static List<T> GetData<T>(string sql)
        {
            using(IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Execute(sql, data);
            }
        }

        public static bool RemoveData<T>(string param,string storedProc, int id)
        {
            int rowsAffected;
            bool isOK = false;

            try
            {
                using (IDbConnection connection = new SqlConnection(GetConnectionString()))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add(param, id);
                    rowsAffected = connection.Execute(storedProc, parameters, commandType: CommandType.StoredProcedure);
                    isOK = true;
                }
            }

            catch(Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public static int UpdateData(string query, int id, DataTable dtblCustomer)
        {
            int count;
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    {
                        using(SqlDataAdapter sqlDa = new SqlDataAdapter(query, connection))
                        {
                            sqlDa.SelectCommand.Parameters.AddWithValue("@id", id);

                            count = sqlDa.Fill(dtblCustomer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }

        public static int UserDetails(string query, int id, DataTable dtblCustomer)
        {
            int count;
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    {
                        using (SqlDataAdapter sqlDa = new SqlDataAdapter(query, connection))
                        {
                            sqlDa.SelectCommand.Parameters.AddWithValue("@id", id);

                            count = sqlDa.Fill(dtblCustomer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString;
        }
    }
}
