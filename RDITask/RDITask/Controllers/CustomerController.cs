using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RDITask.Models;
using RDITask.Models.Context;
using RDITask.Services.Interfaces;

namespace RDITask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lists all customers
        /// </summary>
        /// <returns>Customers</returns>
        /// <response code="200">Operation successful</response>
        /// <response code="500">Operation failed</response>
        [HttpGet("index")]
        public IActionResult Index()
        {
            var result = _service.ListAll();
            return result != null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Show one customer
        /// </summary>
        /// <returns>Customer</returns>
        /// <response code="200">Operation successful</response>
        /// <response code="500">Operation failed</response>
        [HttpGet("details")]
        public IActionResult Details(int? id = 0)
        {
            var result = _service.Find(id.Value);
            return result != null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Create a customer on database
        /// </summary>
        /// <returns>Customer</returns>
        /// <response code="200">Operation successful</response>
        /// <response code="500">Operation failed</response>
        /// <response code="406">Invalid data</response>
        [HttpPost("create")]
        public IActionResult Create([Bind("Id,Name")] CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                var result = _service.Create(customer);
                return result ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, "Invalid Data!");
        }

        /// <summary>
        /// Update a customer on database
        /// </summary>
        /// <returns>Nothing</returns>
        /// <response code="200">Operation successful</response>
        /// <response code="500">Operation failed</response>
        /// <response code="406">Invalid data</response>
        [HttpPut("edit")]
        public IActionResult Edit([Bind("Id,Name")] CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                var result = _service.Edit(customer);
                return result ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, "Invalid Data!");
        }

        /// <summary>
        /// Delete one customer from database
        /// </summary>
        /// <returns>Nothing</returns>
        /// <response code="200">Operation successful</response>
        /// <response code="500">Operation failed</response>
        [HttpDelete("delete")]
        public IActionResult Delete(int? id = 0)
        {
            var result = _service.Delete(id.Value);
            return result ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
