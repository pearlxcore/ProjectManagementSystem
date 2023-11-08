using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Application.Users.Command.UpdateUser;
using ProjectManagementSystem.Application.Users.Query.GetUser;
using ProjectManagementSystem.Contracts.User;
using ProjectManagementSystem.Contracts.User;

namespace ProjectManagementSystem.Api.Controllers
{
    [Route("user")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public UserController(IMapper mapper, ISender mediator)
        {
            _mapper=mapper;
            _mediator=mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            // create query
            var query = new GetUserQuery { Id = id };

            // send query
            var getUserResult = await _mediator.Send(query);

            return getUserResult.Match(
                getUserResult => Ok(_mapper.Map<UserResponse>(getUserResult)),
                errors => Problem(errors));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(UserRequest request, Guid id)
        {
            // create command
            var command = _mapper.Map<UpdateUserCommand>((request, id));

            // send command
            var updateUserResult = await _mediator.Send(command);

            return updateUserResult.Match(
                updateUserResult => Ok(_mapper.Map<UserResponse>(updateUserResult)),
                errors => Problem(errors));
        }
    }
}
