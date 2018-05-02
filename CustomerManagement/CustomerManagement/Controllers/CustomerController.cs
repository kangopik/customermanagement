using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerManagement.Models;
using CustomerManagement.Repository;
using System.Collections;

namespace CustomerManagement.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LoadCustomer()
        {
            CustomerRepositories clCustomer = new CustomerRepositories();
            var listData = clCustomer.GetAllCustomer();
            ArrayList data = new ArrayList();
            foreach (var item in listData)
            {
                ArrayList row = new ArrayList();
                row.Add(item.FirstName);
                row.Add(item.LastName);
                row.Add(item.CompanyName);
                row.Add("<a href='javascript:void(0);' title='Edit' onclick='edit(" + item.CustomerID.ToString() + ")'><i class='fa fa-pencil fa-fw' style='padding-left: 15px;'></i></a>");
                row.Add("<a href='javascript:void(0);' title='Delete' onclick='deletes(" + item.CustomerID.ToString() + ")'><i class='fa fa-trash fa-fw' style='padding-left: 15px;'></i></a>");
                data.Add(row);
            }

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult EditCustomer(int id)
        {
            CustomerRepositories clCustomer = new CustomerRepositories();
            var listData = clCustomer.GetCustomerById(id);
            var data = new
            {
                CustomerID = listData.FirstOrDefault().CustomerID,
                FirstName = listData.FirstOrDefault().FirstName,
                LastName = listData.FirstOrDefault().LastName,
                DOB = listData.FirstOrDefault().DOB,
                Gender = listData.FirstOrDefault().Gender,
                PhoneNumber = listData.FirstOrDefault().PhoneNumber,
                EmailAddress = listData.FirstOrDefault().EmailAddress,
                CompanyName = listData.FirstOrDefault().CompanyName,
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult AddCustomer(Customer customer)
        {
            var data = new { status = false };
            try
            {
                CustomerRepositories clCustomer = new CustomerRepositories();
                clCustomer.AddCustomer(customer);
                data = new { status = true };
            }
            catch (Exception)
            {
                data = new { status = false };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult UpdateCustomer(Customer customer)
        {
            var data = new { status = false };
            try
            {
                CustomerRepositories clCustomer = new CustomerRepositories();
                clCustomer.UpdateCustomer(customer);
                data = new { status = true };
            }
            catch (Exception)
            {
                data = new { status = false };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeleteCustomer(int id)
        {
            var data = new { status = false };
            try
            {
                CustomerRepositories clCustomer = new CustomerRepositories();
                if (clCustomer.DeleteCustomer(id))
                {
                    data = new { status = true };
                }
            }
            catch
            {
                data = new { status = false };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}