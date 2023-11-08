using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Application.Tasks.Command.AddTask;
using ProjectManagementSystem.Application.Tasks.Command.AssignUser;
using ProjectManagementSystem.Application.Tasks.Query.GetTask;
using ProjectManagementSystem.Contracts.Task;

namespace ProjectManagementSystem.Api.Controllers
{
    [Route("task")]
    public class TaskController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public TaskController(IMapper mapper, ISender mediator)
        {
            _mapper=mapper;
            _mediator=mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTask(TaskRequest request)
        {
            // command
            var command = _mapper.Map<AddTaskCommand>(request);

            // send command
            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<TaskResponse>(result)),
                errors => Problem(errors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var query = new GetTaskQuery() { Id = id };

            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(_mapper.Map<TaskResponse>(result)),
                errors => Problem(errors));
        }

        [HttpPut("{taskId}/assignUser/{userId}")]
        public async Task<IActionResult> AssignuserAsync(Guid taskId, Guid userId)
        {
            // command 
            var command = new AssignTaskUserCommand { TaskId=taskId, UserId=userId };

            // send command
            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<TaskResponse>(result)),
                errors => Problem(errors));
        }
    }
}
