using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Account.Command.CreateCommand;
using Application.Features.Address.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
       

        // POST api/<AddressController>
       
        [HttpPost(Name = "AddAddress")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Post([FromBody] CreateAddressCommand createAddressCommand)
        {
            var result = await _mediator.Send(createAddressCommand);
            return StatusCode(201, result);
        }

       /* // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {

        }*/
    }
}
