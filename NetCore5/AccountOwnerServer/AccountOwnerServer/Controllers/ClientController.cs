using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AccountOwnerServer.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ClientController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            try
            {
                var clients = _repository.Client.GetAllClient();
                _logger.LogInfo($"Returned all Clients from database.");


                var clientsResult = _mapper.Map<IEnumerable<ClientDTO>>(clients);
                return Ok(clientsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllClients action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{IdClientBase}")]
        public IActionResult GetClientById(int IdClientBase)
        {
            try
            {
                var client = _repository.Client.GetClientById(IdClientBase);
                if (client is null)
                {
                    _logger.LogError($"Client with IdClientBase: {IdClientBase}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Client with IdClientBase: {IdClientBase}");
                    var clientResult = _mapper.Map<ClientDTO>(client);
                    return Ok(clientResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetClientById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{IdClientBase}/cycle")]
        public IActionResult GetClientByDetaills(int IdClientBase)
        {
            try
            {
                var client = _repository.Client.GetClientByDetaills(IdClientBase);
                if (client is null)
                {
                    _logger.LogError($"Client with IdClientBase: {IdClientBase}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with details for IdClientBase: {IdClientBase}");
                    var clientResult = _mapper.Map<ClientDTO>(client);
                    return Ok(clientResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetClientByDetaills action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{IdClientBase}/ProductType")]
        public IActionResult GetClientByDetaillsWithProductType(int IdClientBase)
        {
            try
            {
                var client = _repository.Client.GetClientByDetaillsWithProductType(IdClientBase);
                if (client is null)
                {
                    _logger.LogError($"Client with IdClientBase: {IdClientBase}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with details with ProductTpye for IdClientBase: {IdClientBase}");
                    var clientResult = _mapper.Map<ClientDTO>(client);
                    //return Ok(clientResult);
                    return Ok(client);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetClientByDetaillsWithProductType action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
