using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
             
        }


        [HttpGet("getAll")]
       public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result is null)
            {
                return BadRequest(result);
            }

            return Ok(result);


        }

    }
}