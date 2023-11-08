using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Application.Authentication.Command.Register;
using ProjectManagementSystem.Application.Authentication.Query.Login;
using ProjectManagementSystem.Application.Users.Query.GetUser;
using ProjectManagementSystem.Contracts.Authentication;
using ProjectManagementSystem.Domain.Aggregates.Users;
using ProjectManagementSystem.Domain.Common.Errors;

namespace ProjectManagementSystem.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public AuthenticationController(IMapper mapper, ISender mediator)
        {
            _mapper=mapper;
            _mediator=mediator;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            // create command
            var command = _mapper.Map<RegisterCommand>(request);

            // send command
            var authResult = await _mediator.Send(command);

            var authenticationResponse = _mapper.Map<AuthenticationResponse>(authResult);


            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));

            //return authResult.Match(
            //   authResult => CreatedAtAction(nameof(GetUser), _mapper.Map<AuthenticationResponse>(authResult)),
            //   errors => Problem(errors));
        }

        public async Task<ErrorOr<User>> GetUser(Guid id)
        {
            var query = new GetUserQuery { Id = id };
            var user = await _mediator.Send(query);
            return user;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            // create command
            var query = _mapper.Map<LoginQuery>(request);

            // send query
            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredential)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }
    }
}
