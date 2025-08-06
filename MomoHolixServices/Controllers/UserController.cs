using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using MomoHolix.DataAccessLayer.Models;
using MomoHolix.DataAccessLayer;
using System.Threading.Tasks;

namespace MomoHolixServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        MomoHolixRepository repository;

        public UserController(MomoHolixRepository repository)
        {
            this.repository = repository;
             
        }
        [HttpGet]
        public JsonResult GetAllUsers()
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                customerList = repository.GetAllCustomers();

            }
            catch
            {
                customerList = null;
            }
            return Json(customerList);
        }


        [HttpPost]
        public JsonResult RegisterUser(Customer customer)
        {
            bool status = false;
            string message;
            try
            {
                status = repository.RegisterNewUser(customer);
                if (status == true)
                {
                    message = "Successfully Registered" + " ID : " + customer.CustId;
                }
                else
                {
                    message = "Nehi hua, firse karo !!!";
                }
            }
            catch (Exception)
            {
                message = "Bhaag";
            }
            return Json(message);

        }


        //[HttpPut]
        //public bool UpdateCustomerBalance(decimal cust_id, decimal? balance)
        //{
        //    Customer cust = new Customer();
        //    cust.CustId = cust_id;
        //    cust.Balance=balance;

        //    bool status = false;

        //    status = repository.UpdateBalanceinCustomer(cust_id, balance);
        //}


        [HttpPost]

        public JsonResult ValidateUserCredentials(Customer customer)
        {
            
            string message="";
            decimal userId = 0;
            try
            {
                (message,userId) = repository.ValidateLogin(customer.EmailId,customer.Password);
            }
            catch(Exception ex)
            {
                message = "OOPPSSSS... Something went wrong yaaar !!";
            }
            return Json(new { userId = userId, message = message });

        }

        /*

        [HttpPost]
        public JsonResult ValidateUserCredentials(Common.Models.User userObj)
        {
            string userRole = string.Empty;
            try
            {
                CustomerBL customerBLObj = new CustomerBL();
                userRole = customerBLObj.ValidateUserCredentials(userObj.EmailId, userObj.UserPassword);
            }
            catch (Exception)
            {
                userRole = "Invalid credentials";
            }
            return Json(userRole);
        }
        */

    }
}
