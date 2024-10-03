using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class ClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper; 
        }
        
        public async Task CreateClient(ClientRequestDto clientRequestDto)
        {
            var client = mapper.Map<Client>(clientRequestDto);
            client.Status = true;
            await clientRepository.Insert(client);
        }

        public async Task UpdateClient(int id, ClientRequestDto clientRequestDto)
        {
            var existingClient = await clientRepository.GetById(id);
            if (existingClient == null)
            {
                throw new Exception("El cliente no existe");
            }
            else
            {
                mapper.Map(clientRequestDto, existingClient);
                await clientRepository.Update(existingClient);
            }            
        }

        public async Task<ActionResult<ClientResponseDto>> GetClientById(int id)
        {
            var client = await clientRepository.GetById(id);
            if (client == null)
            {
                throw new KeyNotFoundException("El cliente no fue encontrado.");
            }
            else
            {
                return mapper.Map<ClientResponseDto>(client);
            }
        }

        public async Task<ActionResult<List<ClientResponseDto>>> GetAllClients()
        {
            var clients = await clientRepository.GetAll();
            if (clients == null)
            {
                throw new Exception("Clientes no encontradas");
            }
            else
            {
                return mapper.Map<List<ClientResponseDto>>(clients);
            }
        }

        public async Task DeleteClient(int id)
        {
            var client = await clientRepository.GetById(id);
            if(client == null)
            {
                throw new KeyNotFoundException("El cliente no fue encontrado");
            }
            else
            {
                client.Status = false;
                await clientRepository.Update(client);
            }
        }

    }
}