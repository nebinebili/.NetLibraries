using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateLimit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(new { Id = 1, Name = "Kitab", Price = 20 });
        }

        //api/product/kitap/20
        // islemesi ucun appsetingsjson da "Endpoint": "*:/api/product/*" bu cur yazilir

        [HttpGet("{name}/{price}")]
        public IActionResult GetProduct(string name,int price)
        {
            return Ok(name);
        }

        [HttpPost]
        public IActionResult SaveProduct()
        {
            return Ok(new {Status="Success"});
        }

        [HttpPut]

        public IActionResult UpdateProduct()
        {
            return Ok();
        }
    }
}
