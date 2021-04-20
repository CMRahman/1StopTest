using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Queries.GetUserAccounts;
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
        [HttpGet("{id}/details", Name = "GetUserWithAddress")]
        public async Task<ActionResult<UserDetailsDto>> GetUserWithAddress(Guid id)
        {
            var result = await _mediator.Send(new GetUserDetailsQuery() { UserId = id });
            return Ok(result);
        }

        [HttpGet("{id}/accounts", Name = "GetUserAccounts")]
        public async Task<ActionResult<List<AccountDto>>> GetUserAccounts(Guid id)
        {
            var result = await _mediator.Send(new GetUserAccountsQuery() { UserId = id });
            return result;

        }

        // POST api/<User>
        [HttpPost(Name = "AddUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Post([FromHeader] string userName, [FromBody] CreateUserCommand createUserCommand)
        {
            //TODO : In real project, this will be handled by Authorization filter
            if (userName != "Admin")
            {
                return Unauthorized("Authorization Error!! Only Administrators can create new Users");
            }

            var result = await _mediator.Send(createUserCommand);
            return StatusCode(201, result);


        }

        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            await _mediator.Send(updateUserCommand);
            return NoContent();
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
