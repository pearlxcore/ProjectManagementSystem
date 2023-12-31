﻿using ProjectManagementSystem.Domain.Aggregates.Clients;

namespace ProjectManagementSystem.Application.Common.Interfaces.Persistance
{
    public interface IClientRepository
    {
        Task AddClient(Client client);
        Client? GetClientByEmail(string email);
        Client? GetClientById(Guid id);
        Task<Client?> UpdateClient(Client clientUpdate);
    }
}
