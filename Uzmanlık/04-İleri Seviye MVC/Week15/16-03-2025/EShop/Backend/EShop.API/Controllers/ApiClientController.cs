using EShop.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [ApiController]
    [Route("api/apiclient")]
    [Authorize(Roles = "Admin")] // Sadece admin kullanıcılar API client'ları yönetebilir
    public class ApiClientController : ControllerBase
    {
        private readonly IApiClientService _apiClientService;

        public ApiClientController(IApiClientService apiClientService)
        {
            _apiClientService = apiClientService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateApiClientRequest request)
        {
            var result = await _apiClientService.CreateApiClientAsync(request.Name, request.Description);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _apiClientService.GetAllApiClientsAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{apiKey}")]
        public async Task<IActionResult> GetByKey(string apiKey)
        {
            var result = await _apiClientService.GetApiClientByKeyAsync(apiKey);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{apiKey}/deactivate")]
        public async Task<IActionResult> Deactivate(string apiKey)
        {
            var result = await _apiClientService.DeactivateApiClientAsync(apiKey);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{apiKey}/activate")]
        public async Task<IActionResult> Activate(string apiKey)
        {
            var result = await _apiClientService.ActivateApiClientAsync(apiKey);
            return StatusCode(result.StatusCode, result);
        }
    }

    public class CreateApiClientRequest
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}