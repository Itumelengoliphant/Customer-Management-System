using CustomerSystem.Models;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.BusinessLogic;
using System.Collections.Generic;
using System;
using DataLib.Model;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CustomerSystem.Queries;

namespace CustomerSystem.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCustomer()
        {
            ViewBag.Message = "Create a customer";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerBL.CreateCustomer(model.ID, model.Name, model.Surname, model.Address,
                                          model.Town, model.Country, model.Mail, model.Date_of_birth,
                                          model.IsActive, model.Username, model.Password, model.Rating);

                return RedirectToAction("ViewCustomer");
            }

            return View();
        }
        public ActionResult ViewCustomer(string searchBy, string search)
        {

            ViewBag.Message = "View all customer";

            var data = CustomerBL.ListAllCustomers();

            List<CustomerModel> customers = new List<CustomerModel>();

            foreach (var cust in data)
            {
                customers.Add(new CustomerModel
                {
                    ID = cust.CustomerID,
                    Name = cust.Name,
                    Surname = cust.Surname,
                    Address = cust.Address,
                    Town = cust.Town,
                    Country = cust.Country,
                    Mail = cust.Mail,
                    Date_of_birth = cust.DOB,
                    IsActive = cust.IsActive,
                    Username = cust.Username,
                    Password = cust.Password,
                    Rating = cust.Rating

                });
            }

            return View(customers);
        }

        public ActionResult RemoveCustomer(int id)
        {

            ViewBag.Message = "Remove customer";

            try
            {
                if (CustomerBL.RemoveItem(id))
                {
                    ViewBag.Message = "Removed a customer";
                }

                return RedirectToAction("ViewCustomer");

            }
            catch
            {
                return RedirectToAction("ViewCustomer");
            }
        }


        public ActionResult CustomerUpdate(int id)
        {
            CustomerModel customerModel = new CustomerModel();

            using (DataTable dtblCustomer = new DataTable())
            {
                CustomerBL.UpdateItem(id, dtblCustomer);

                if (dtblCustomer.Rows.Count == 1)
                {
                    Helper.PopulateDataTable(customerModel, dtblCustomer);

                    return View(customerModel);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public ActionResult CustomerUpdate(CustomerModel customer)
        {
            string connections = ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString;

            using (SqlConnection sqlCon = new SqlConnection(connections))

            {
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand(QueryRepository.UpdateCustomer(), sqlCon);

                Helper.CustomerSetup(customer, sqlCmd);

                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("ViewCustomer");
        }

        public ActionResult CustomerDetails(int id)
        {
            CustomerModel customerModel = new CustomerModel();

            using (DataTable dtblCustomer = new DataTable())
            {
                CustomerBL.UserDetail(id, dtblCustomer);

                if (dtblCustomer.Rows.Count == 1)
                {
                    Helper.PopulateDataTable(customerModel, dtblCustomer);

                    return View(customerModel);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }
    }
}
