using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mohashan.UserManager.Application.Features.Users.Commands.CreateUser;
using Mohashan.UserManager.Application.Features.Users.Queries.GetGroupUsers;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUserDetails;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUsersList;

namespace Mohashan.UserManager.API.Controllers
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

        [HttpGet("all",Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UsersListVm>>> GetAllUsers()
        {
            var dtos = await _mediator.Send(new GetUsersListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetUserDetails/{id}", Name = "GetUsersDetails")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDetailVm>> GetUserDetails(Guid id)
        {
            var dtos = await _mediator.Send(new GetUserDetailQuery {Id = id });
            return Ok(dtos);
        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<CreateUserCommandResponse>> GetUserDetails([FromBody] CreateUserCommand createUserCommand)
        {

            var response = await _mediator.Send(createUserCommand);
            return Ok(response);
        }
    }
}
