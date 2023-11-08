using Mapster;
using ProjectManagementSystem.Application.Clients.Command.AddClient;
using ProjectManagementSystem.Application.Clients.Command.UpdateClient;
using ProjectManagementSystem.Contracts.Client;
using ProjectManagementSystem.Domain.Aggregates.Clients;

namespace ProjectManagementSystem.Api.Common.Mapping
{
    public class ClientMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // add client request
            config.NewConfig<ClientRequest, AddClientCommand>()
                .Map(dest => dest.ClientContact, src => src.ClientContact);

            // update client request
            config.NewConfig<(ClientRequest request, Guid id), UpdateClientCommand>()
                .Map(dest => dest.Id, src => src.id)
                .Map(dest => dest.Name, src => src.request.Name)
                .Map(dest => dest.Email, src => src.request.Email)
                .Map(dest => dest.ClientContact, src => src.request.ClientContact);

            // response
            config.NewConfig<Client, ClientResponse>()
                .MapWith(dest => new ClientResponse(
                    dest.Id.Value,
                    dest.Name,
                    dest.Email,
                    dest.ClientContact != null
                        ? new ClientContactResponse(
                            dest.ClientContact.Phone,
                            dest.ClientContact.Address)
                        : null,
                    dest.ProjectIds.Select(x => x.Value).ToList()
                        ));


        }
    }
}
