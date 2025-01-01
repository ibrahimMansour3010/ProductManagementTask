using ProductManagementTask.Applications.Account.Commands.Login;
using ProductManagementTask.Applications.Account.Commands.Login.Dtos;
using ProductManagementTask.Applications.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(contentType: "application/json", Type = typeof(IResult<LoginOutput>))]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
