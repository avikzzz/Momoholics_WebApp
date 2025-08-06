using System;
using System.Linq;
using System.Collections.Generic;
using MomoHolix.DataAccessLayer.Models;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MomoHolix.DataAccessLayer
{
    public class MomoHolixRepository
    {
        private MomoHolixContext context;

        public MomoHolixRepository(MomoHolixContext context)
        {
            this.context = context;
        }


        public List<Category> GetAllCategories()
        {
            var categoryList = (from cat in context.Category 
                                orderby cat.CatId descending
                                select cat).ToList();
            return categoryList;
        }
        
        public List<Menu> GetAllMenus()
        {
            var menuList = (from menu in context.Menu
                            orderby menu.MenuItems ascending
                            select menu).ToList();
            return menuList;
        }
        public List<Customer> GetAllCustomers()
        {
            var userList = (from user in context.Customer
                            orderby user.CustId
                            select user).ToList();

            return userList;
        }
        public List<Menu> GetMenusbyCategory(string categoryId)
        {
            List<Menu> menu = new List<Menu>();

            menu = (from menus in context.Menu
                    where menus.CatId == categoryId
                    orderby menus.MenuItems ascending
                    select menus
                   ).ToList();



            //menu = context.Menu.Where(m=>m.CatId==categoryId).ToList();




            return menu;
        }
       
        public bool AddMenu(params Menu[] menus)
        {
            bool status = false;

            try
            {
                context.Menu.AddRange(menus);
                context.SaveChanges();

                status = true;
                
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

    


        // ETA USER VALIDAAATIOOOON //


        public (string StatusMessage, decimal UserId) ValidateLogin(string emailId, string password)
        {

            string statusMessage = "";
            decimal userId = 0;
            try
            {
                var objUser = (from user in context.Customer
                               where user.EmailId == emailId && user.Password == password
                               select user).FirstOrDefault();

                if (objUser!=null)
                {
                    statusMessage = "Validated Successfully";
                    userId= objUser.CustId;
                    
                }
                else
                {
                    statusMessage = "Invalid Credentials";
                }

            }
              
            catch (Exception)
            {
                statusMessage = "Invalid credentials";
            }
            return (statusMessage,userId);
            
             
        }

        // ETA REGISTER USER //


        public bool RegisterNewUser(params Customer[] customer)
        {
            bool status;

            try
            {

                context.Customer.AddRange(customer);
                context.SaveChanges();

                status = true;

            }
            catch(Exception ex)
            {
                status = false;
            }

            return status;


            
        }
        
        public bool UpdateBalanceinCustomer(decimal cust_id, decimal amount)
        {
            bool status = false;

            Customer customer = context.Customer.Find(cust_id);
            try
            {
                if (customer != null) 
                {
                    Console.WriteLine("ok");
                    customer.Balance = amount;
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
                
            }
            catch(Exception ex)
            {
                status = false;
            }

            return status;
        }

        public List<Cart> GetCart(decimal custId)
        {

            var cartList = (from cart in context.Cart
                            where cart.CustId == custId
            
                            select cart).ToList();
            
            return cartList;
        }


        public bool AddtoCart(decimal custId, string menuId)
        {
            try
            {
                var result = context.Database.ExecuteSqlRaw(

                    "EXEC dbo.msp_AddToCart @p0, @p1",
                    custId, menuId);

                if (result == 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return false;
        }


       
    }
}
