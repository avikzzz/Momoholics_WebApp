using System;
using MomoHolix.DataAccessLayer;
using MomoHolix.DataAccessLayer.Models;

namespace MomoHolixConsoleApp
{
    public class Program
    {
        
        static MomoHolixRepository repository;
        static MomoHolixContext context;
        static Program()
        {
            context = new MomoHolixContext();
            repository = new MomoHolixRepository(context);

        }
        static void Main(string[] args)
        {

            var catList = repository.GetAllCategories();
            var menuList = repository.GetAllMenus();
            var menus = repository.GetMenusbyCategory("SZ");

            Console.WriteLine("{0}\t\t\t{1}", "CATENUM", "CatENAME");
            Console.WriteLine("=====================================");

            //foreach (var cat in catList)

            //{

            //    Console.WriteLine("");
            //    Console.WriteLine("{0}\t\t\t{1}",cat.CatId, cat.CatName);
            //}

            //foreach (var menu in menuList)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}\t{3}", menu.MenuId,menu.MenuItems,menu.QtyAvailable,menu.Type);
            //}

            //foreach(var menu in menus)
            //{
            //    Console.WriteLine(menu.MenuItems);
            //}


            Customer customer = new Customer();

            customer.EmailId = "chin@gmail.com";
            customer.CustAddress = "china";
            customer.CustName = "chinchun";
            customer.Gender = "M";
            customer.Password = "chinchun@123";
            customer.PhoneNumber = 9876789836;
            customer.Age = 35;

            bool result = repository.RegisterNewUser(customer);
            if (result == true)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("failed");
            }


            //Customer customer = new Customer();

            //bool result = repository.UpdateBalanceinCustomer(1003,2000);

            //if (result == true)
            //{
            //    Console.WriteLine("success, added successfully ");
            //}
            //else
            //{
            //    Console.WriteLine("failed");
            //}
        }
    }
}
