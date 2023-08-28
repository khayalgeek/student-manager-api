﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Business.Abstract;
using Student.Entity.Student;

namespace Student.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressesService _addressService;
        private readonly IStudentService _studentService;

        public AddressesController(IAddressesService addressService, IStudentService studentService)
        {
            _addressService = addressService;
            _studentService = studentService;
        }


        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {

            if (id == null || id == 0) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var address = await _addressService.GetFirst(id ?? 0);
            if (address == null) return NotFound();
            return Ok(address);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _addressService.GetAll();
            return Ok(addresses);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Address address)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status422UnprocessableEntity);
            if (!(await _studentService.IsAlreadyAdded(address.Id))) return NotFound("No student with the same id was found");
            await _addressService.Add(address);
            if (address == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok((address));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Address address)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status422UnprocessableEntity);
            if (!(await _studentService.IsAlreadyAdded(address.Id))) return NotFound("No student with the same id was found");
            await _addressService.Update(address);
            if (address == null) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(address);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status422UnprocessableEntity);

            var address = await _addressService.GetFirst(id ?? 0);
            if (address == null) return NotFound("Address not found");

            await _addressService.Delete(address.Id);
            if (address == null) return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(address);
        }
    }
}
