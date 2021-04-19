using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Account.Query.GetAllAccounts;
using Application.Features.Users.Queries.GetUserAccounts;
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
        public async Task<ActionResult<List<AccountsDto>>> GetAllAccounts()
        {
            var userList = await _mediator.Send(new GetAllAccountsQuery());
            return Ok(userList);
        }
    }
}
