using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Application.Clients.Command.AddClient;
using ProjectManagementSystem.Application.Clients.Command.UpdateClient;
using ProjectManagementSystem.Application.Clients.Query.GetClient;
using ProjectManagementSystem.Contracts.Client;

namespace ProjectManagementSystem.Api.Controllers
{
    [Route("client")]
    public class ClientController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public ClientController(IMapper mapper, ISender mediator)
        {
            _mapper=mapper;
            _mediator=mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddClient(ClientRequest request)
        {
            // create command
            var command = _mapper.Map<AddClientCommand>(request);

            // send command
            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<ClientResponse>(result)),
                errors => Problem(errors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(Guid id)
        {
            // create query
            var query = new GetClientQuery { Id = id };

            // send query
            var getClientResult = await _mediator.Send(query);

            return getClientResult.Match(
                getClientResult => Ok(_mapper.Map<ClientResponse>(getClientResult)),
                errors => Problem(errors));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(ClientRequest request, Guid id)
        {
            // create command
            var command = _mapper.Map<UpdateClientCommand>((request, id));

            // send command
            var updateClientResult = await _mediator.Send(command);

            return updateClientResult.Match(
                updateClientResult => Ok(_mapper.Map<ClientResponse>(updateClientResult)),
                errors => Problem(errors));
        }
    }

}
