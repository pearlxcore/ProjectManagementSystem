using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Application.Projects.Command.AssignTask;
using ProjectManagementSystem.Application.Projects.Command.CreateProject;
using ProjectManagementSystem.Application.Projects.Query.GetProject;
using ProjectManagementSystem.Contracts.Project;
using ProjectManagementSystem.Contracts.Projects;

namespace ProjectManagementSystem.Api.Controllers
{
    [Route("project")]
    public class ProjectController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;
        private readonly ITaskRepository _taskRepository;
        public ProjectController(IMapper mapper, ISender mediator, ITaskRepository taskRepository)
        {
            _mapper=mapper;
            _mediator=mediator;
            _taskRepository=taskRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(CreateProjectRequest request)
        {
            // create command
            var command = _mapper.Map<CreateProjectCommand>(request);

            // send command
            var createProjectResult = await _mediator.Send(command);

            return createProjectResult.Match(
                createProjectResult => Ok(_mapper.Map<ProjectResponse>(createProjectResult)),
                errors => Problem(errors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetProjectQuery { Id = id };

            // send query
            var result = await _mediator.Send(query);


            var mappedResult = result.Match(
                result => Ok(_mapper.Map<ProjectResponse>(result)),
                errors => Problem(errors));

            return mappedResult;
        }

        [HttpPut("{projectId}/assignTask/{taskId}")]
        public async Task<IActionResult> AssignTask(Guid projectId, Guid taskId)
        {
            var command = new AssignProjectTaskCommand()
            {
                ProjectId = projectId,
                TaskId =  taskId
            };

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<ProjectResponse>(result)),
                errors => Problem(errors));
        }
    }
}