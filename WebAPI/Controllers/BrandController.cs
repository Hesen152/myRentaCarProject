using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;

        }
        //Brand listesinde herhangi bir marka seçildiğinde, o markaya ait arabaları listeleyiniz.






        [HttpGet("getAll")]
         public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {

                return Ok(result);

            }

            return BadRequest(result);



        }

             
      










    }
}