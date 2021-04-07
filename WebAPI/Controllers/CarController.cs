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
    public class CarController : ControllerBase
    {
        ICarService _carService;


        public CarController(ICarService carService)
        {
            _carService = carService;

        }


        [HttpGet("getAll")]

        public IActionResult GetAll()
        {
            var result=_carService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
            
            
        }


        [HttpGet("getCarDetails")]
       public IActionResult GetAllDetails()
        {
            var result = _carService.GetCarDetails();

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }


        [HttpGet("getbyid")]
         
        public IActionResult GetById(int carId)
        {
            var result = _carService.GetById(carId);

            if (result.Success)
            {

                return Ok(result);

            }

            return BadRequest(result);



            
        }

        //[HttpGet("getcarbrandid")]
        // public IActionResult GetCarBrandId(int brandId)
        //{
        //    var result = _carService.GetCarsByBrandId(brandId);

        //    if (result.Success)
        //    {
        //        return Ok(result);

        //    }

        //    return BadRequest(result.Message);





        //}

        [HttpGet("getcarscolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getcarsdetail")]
        public IActionResult GetCarsDetail()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }



        //RentACar projesinde;

        //Brand listesinde herhangi bir marka seçildiğinde, o markaya ait arabaları listeleyiniz.

        //Color listesinde herhangi bir renk seçildiğinde, o renge ait arabaları listeleyiniz.

        //Car listesinde bir arabaya tıklandığında o arabaya ait detay sayfası oluşturunuz.Bu sayfada bu araca ait resimleri de gösteriniz.



        [HttpGet("getforcardetail/{id}")]
        public IActionResult GetForCarDetails(int id)
        {
            var result = _carService.GetForCarDetails(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }






        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);
           
            



        }


        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result.Message);

            }

            return BadRequest(result.Message);





        }

        [HttpGet("getcarbrandId")]

        public IActionResult GetByBrandId(int brandId)
        {
            var result = _carService.GetAllBrandId(brandId);
            if (result.Success)
            {

                return Ok(result);

            }

            return BadRequest(result.Message);
        }




        [HttpPost("delete")]

      public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }












    }
}