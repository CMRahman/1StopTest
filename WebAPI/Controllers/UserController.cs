using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Queries.GetUserDetails;
using Application.Features.Users.Queries.GetUserList;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("all", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserListDto>>> GetAllUsers()
        {
            var userList = await _mediator.Send(new GetUserListQuery());
            return Ok(userList);
        }


        // GET api/<User>/5/details
        [HttpGet("{id}/details", Name = "GetUserWithDetails")]
        public async Task<ActionResult<UserDetailsDto>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetUserDetailsQuery() { UserId = id });
            return Ok(result);
        }

        // POST api/<User>
        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<Guid>> Post([FromHeader] string userName, [FromBody] CreateUserCommand createUserCommand)
        {
            //TODO : In real project, this will be handled by Authorization filter
            if (userName != "Admin")
            {
                return Unauthorized("Authorization Error!! Only Administrators can create new Users");
            }

            var result = await _mediator.Send(createUserCommand);
            return Ok(result);


        }

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete([FromHeader] string userName, Guid id)
        {
            if (userName != "Admin")
            {
                return Unauthorized("Authorization Error!! Only Administrators can delete Users");
            }
            await _mediator.Send(new DeleteUserCommand() { UserId = id });
            return NoContent();

        }
    }
}
