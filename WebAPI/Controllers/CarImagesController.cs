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
    public class CarImagesController : ControllerBase
    {
        readonly ICarImagesService _carImageService;

        public CarImagesController(ICarImagesService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getlistbycarid")]
        public IActionResult GetListByCarId(int id)
        {
            var result = _carImageService.GetListByCardId(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImages carImage)
        {
            var result = _carImageService.Add(carImage);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] CarImages carImage)
        {
            var result = _carImageService.Update(carImage);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromForm] CarImages carImage)
        {
            var result = _carImageService.Delete(carImage);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}