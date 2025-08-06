using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MomoHolix.DataAccessLayer;
using System.Collections.Generic;
using MomoHolix.DataAccessLayer.Models;
using System.Xml.Schema;
using System;

namespace MomoHolixServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : Controller
    {
        MomoHolixRepository repository;

        public CartController(MomoHolixRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public JsonResult GetCartItems(decimal custId)
        {
            List<Cart> cartlist = new List<Cart>();
            try
            {
                cartlist = repository.GetCart(custId);

                
            }
            catch (Exception ex)
            {
                cartlist= null;
            }

            return Json(cartlist);
        }

        [HttpPost]

        public bool AddtoCart(decimal custId, string menuId)
        {
            bool status = false;
            try
            {
                status = repository.AddtoCart(custId, menuId);

            }
            catch(Exception ex)
            {
                status = false;
            }

            return status;
        }

    }
}
