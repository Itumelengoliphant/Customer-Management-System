using DataLib.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DataLib.BusinessLogic
{
    public class SQLDataAccess : ProviderBase<CustModel>
    {
        public CustModel Add(CustModel t)
        {
            throw new NotImplementedException();
        }

        public CustModel Remove(string id)
        {
            throw new NotImplementedException();
        }

        public List<CustModel> SelectAll()
        {
            throw new NotImplementedException();
        }

        public CustModel Update(CustModel t)
        {
            throw new NotImplementedException();
        }

        private string GetConnectionString()
        {
            return ConfigurationManager
        }
    }
}
