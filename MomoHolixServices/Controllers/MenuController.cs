using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MomoHolix.DataAccessLayer;
using MomoHolix.DataAccessLayer.Models;

namespace MomoHolixServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : Controller
    {
        MomoHolixRepository repository;

        public MenuController(MomoHolixRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public JsonResult GetAllMenus()
        {
            List<Menu> menuList = new List<Menu>();
            try
            {
                menuList = repository.GetAllMenus();
            }
            catch(Exception ex)
            {
                menuList = null;
            }

            return Json(menuList);

            
        }

        [HttpGet]
        public JsonResult GetMenusByCategory(string categoryId)
        {
            List<Menu> menuList = new List<Menu>();
            try
            {
                menuList = repository.GetMenusbyCategory(categoryId);
            }
            catch(Exception ex)
            {
                menuList = null;
            }
            return Json(menuList);
        }

        [HttpPost]
        public JsonResult AddMenu(Menu menu)
        {
            bool status = false;
            string message;
            try
            {
                status = repository.AddMenu(menu);

                if (status == true)
                {
                    message = "Product inserted in the dish" + " And THEEEEEEEN it's" + menu.MenuItems;
                }
                else
                {
                    message = "Nope nope, cook first !";
                }
            }
            catch(Exception ex)
            {
                message = "Nope nope";
            }

            return Json(message);
        }
    }
}
