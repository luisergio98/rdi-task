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
    public class CreditCardController : Controller
    {
        private readonly ICreditCardService _service;
        private readonly ITokenService _tokenService;

        public CreditCardController(ICreditCardService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Lists all credit cards
        /// </summary>
        /// <returns>Credit Cards</returns>
        /// <response code="200">Operation successful</response>
        /// <response code="500">Operation failed</response>
        [HttpGet("index")]
        public IActionResult Index()
        {
            var result = _service.ListAll();
            return result != null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Show one credit card
        /// </summary>
        /// <returns>Credit Card</returns>
        /// <response code="200">Operation successful</response>
        /// <response code="500">Operation failed</response>
        [HttpGet("details")]
        public IActionResult Details(int? id)
        {
            var result = _service.Find(id.Value);
            return result != null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Create a credit card on database
        /// </summary>
        /// <returns>Nothing</returns>
        /// <response code="200">Operation successful</response>
        /// <response code="500">Operation failed</response>
        /// <response code="406">Invalid data</response>
        [HttpPost("create")]
        public IActionResult Create([Bind("Id,CostumerId,CardNumber,CVV")] CreditCardModel card)
        {
            if (ModelState.IsValid)
            {
                var result = _service.Create(card);
                return result != null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, "Invalid Data!");
        }

        /// <summary>
        /// Update a credit card on database
        /// </summary>
        /// <returns>Nothing</returns>
        /// <response code="200">Operation successful</response>
        /// <response code="500">Operation failed</response>
        /// <response code="406">Invalid data</response>
        [HttpPut("edit")]
        public IActionResult Edit([Bind("Id,CostumerId,CardNumber,CVV")] CreditCardModel card)
        {
            if (ModelState.IsValid)
            {
                var result = _service.Edit(card);
                return result ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, "Invalid Data!");
        }

        /// <summary>
        /// Delete one credit card from database
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

        /// <summary>
        /// Validate a token
        /// </summary>
        /// <returns>Boolean</returns>
        /// <response code="200">Operation successful</response>
        /// <response code="500">Operation failed</response>
        [HttpPost("validate")]
        public IActionResult ValidateToken(int customerId, int cardId, int tokenNumber, int cvv)
        {
            return Ok(_tokenService.Validate(customerId, cardId, tokenNumber, cvv));
        }
    }
}
