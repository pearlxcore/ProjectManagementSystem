using Mapster;
using ProjectManagementSystem.Application.Users.Command.UpdateUser;
using ProjectManagementSystem.Contracts.User;
using ProjectManagementSystem.Contracts.User;
using ProjectManagementSystem.Domain.Aggregates.Users;

namespace ProjectManagementSystem.Api.Common.Mapping
{
    public class UserMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // user update request
            config.NewConfig<(UserRequest request, Guid id), UpdateUserCommand>()
                .Map(dest => dest.Id, src => src.id)
                .Map(dest => dest.FirstName, src => src.request.FirstName)
                .Map(dest => dest.LastName, src => src.request.LastName)
                .Map(dest => dest.Email, src => src.request.Email)
                .Map(dest => dest.Password, src => src.request.Password)
                .Map(dest => dest.Role, src => src.request.Role)
                .Map(dest => dest.UserContact, src => src.request.UserContact);

            // response
            config.NewConfig<User, UserResponse>()
                .MapWith(dest => new UserResponse(
                    dest.Id.Value,
                    dest.FirstName,
                    dest.LastName,
                    dest.Email,
                    dest.Role.ToString(),
                    dest.UserContact != null
                        ? new UserContactResponse(
                            dest.UserContact.Phone,
                            dest.UserContact.Address)
                        : null
                ));

        }
    }
}
