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
    public class CategoryController : Controller
    {

        MomoHolixRepository repository;

        public CategoryController(MomoHolixRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public JsonResult GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                categories=repository.GetAllCategories();
            }
            catch(Exception ex)
            {
                categories = null;
            }
            return Json(categories);

        }


    }
}
