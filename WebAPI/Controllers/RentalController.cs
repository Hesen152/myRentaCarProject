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
    public class RentalController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;

        }

        [HttpGet("getRentalDetails")]
        public IActionResult GetRentalDetails()
        {
            var getrentalsdetails = _rentalService.GetRentalDetails();
            if (getrentalsdetails.Success)
            {
                return Ok(getrentalsdetails);

            }

            return BadRequest(getrentalsdetails);

        }



        


    }
}