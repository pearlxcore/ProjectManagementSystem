using Mapster;
using ProjectManagementSystem.Application.Authentication.Command.Register;
using ProjectManagementSystem.Application.Authentication.Common;
using ProjectManagementSystem.Contracts.Authentication;

namespace ProjectManagementSystem.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>()
                .Map(dest => dest.UserContact, src => src.RegisterContact);

            config.NewConfig<RegisterContactRequest, UserContactCommand>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .MapWith(dest => new AuthenticationResponse()
                {
                    Id = dest.User.Id.Value,
                    FirstName = dest.User.FirstName,
                    LastName = dest.User.LastName,
                    Email = dest.User.Email,
                    Token = dest.Token
                });
        }
    }
}
