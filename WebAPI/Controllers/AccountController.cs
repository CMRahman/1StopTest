using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Account.Command.CreateCommand;
using Application.Features.Account.Command.DeleteAccount;
using Application.Features.Account.Command.DepositCommand;
using Application.Features.Account.Query.GetAccount;
using Application.Features.Account.Query.GetAllAccounts;
using Application.Features.Users.Queries.GetUserAccounts;
using Application.Features.Users.Queries.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AccountDto>>> GetAllAccounts()
        {
            var userList = await _mediator.Send(new GetAllAccountsQuery());
            return Ok(userList);
        }

        [HttpGet("{id}", Name = "GetAccountDetails")]
        public async Task<ActionResult<UserDetailsDto>> GetAccountDetails(Guid id)
        {
            var result = await _mediator.Send(new GetAccountDetailsQuery() { AccountId = id });
            return Ok(result);
        }


        [HttpPost(Name = "AddAccount")]
        public async Task<ActionResult<Guid>> Post([FromBody] CreateAccountCommand createAccountCommand)
        {
            var result = await _mediator.Send(createAccountCommand);
            return Ok(result);
        }


        [HttpPost("deposit", Name = "Deposit")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> Deposit([FromBody] DepositAccountCommand depositAccountCommand)
        {
            var result = await _mediator.Send(depositAccountCommand);
            return NoContent();
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}", Name = "DeleteAccount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteAccountCommand() { AccountId = id });
            return NoContent();

        }
    }
}
