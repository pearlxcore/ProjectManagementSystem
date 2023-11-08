using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Application.Common.Interfaces.Providers;
using ProjectManagementSystem.Domain.Aggregates.Projects;
using ProjectManagementSystem.Domain.Aggregates.Users.ValueObjects;
using ProjectManagementSystem.Domain.Common.Errors;

namespace ProjectManagementSystem.Application.Projects.Command.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ErrorOr<Project>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IDateTimeProvider _dateProvider;
        public CreateProjectCommandHandler(IProjectRepository repository, IUserRepository userRepository, IClientRepository clientRepository, IDateTimeProvider dateProvider)
        {
            _projectRepository=repository;
            _userRepository=userRepository;
            _clientRepository=clientRepository;
            _dateProvider=dateProvider;
        }

        public async Task<ErrorOr<Project>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (_projectRepository.CheckProjectExists(request.Name, request.ClientId) is not null)
            {
                return Errors.Project.DuplicateName;
            }

            var userIdList = new List<Guid>();
            foreach (var item in request.TeamMembers)
            {
                var user = _userRepository.GetUserById(item);
                if (user is not null)
                {
                    userIdList.Add(user.Id.Value);
                }
                else
                {
                    return Errors.Project.NotFound;
                }
            }

            List<UserId> assignedUsers = userIdList.Select(guid => new UserId(guid)).ToList();


            var client = _clientRepository.GetClientById(request.ClientId);
            if (client is null)
            {
                return Errors.Client.NotFound;
            }

            // validate date
            if (!_dateProvider.ValidateDateTime(request.StartDate) || !_dateProvider.ValidateDateTime(request.EndDate))
            {
                return Errors.DateTime.InvalidDateTime;
            }

            var project = Project.Factory.Create(
            name: request.Name,
            description: request.Description,
            startDate: request.StartDate,
            endDate: request.EndDate,
            status: request.Status,
            priority: request.Priority,
            budget: request.Budget,
            assignedUsers: assignedUsers,
            clientId: client.Id.Value);

            // persistance
            _projectRepository.CreateProject(project);

            return project;
        }
    }
}
