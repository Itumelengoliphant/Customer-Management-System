using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Model
{
   public class CustModel
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public string Mail { get; set; }
        public DateTime DOB { get; set; }
        public bool IsActive { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Rating { get; set; }


    }
}
