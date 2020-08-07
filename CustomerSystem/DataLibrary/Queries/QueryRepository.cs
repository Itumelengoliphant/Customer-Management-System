using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSystem.Queries
{
    public static class QueryRepository
    {
        public static string SingleSelect()
        {
            return @"SELECT *
                FROM [Customer_SysDB].[dbo].[CustomerDB] where [CustomerID] =@id";
        }
        public static string UpdateCustomer()
        {
            return @"UPDATE[dbo].[CustomerDB] SET[Name] = @Name, [Surname]= @Surname,
                                [Address] = @Address, [Town] = @Town, [Country] = @Country,[Mail] = @Mail,
                                [DOB] = @DOB,[IsActive] = @IsActive,[Password] = @Password,
                                [Username] = @Username,[Rating] = @Rating
                                WHERE[CustomerID] = @id";

            
        }
    }
}