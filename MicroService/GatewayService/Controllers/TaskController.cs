using GatewayService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

/**
 * quand je create depuis swagger de la gateway
 * je vois rien quand je get depuis swagger de TaskService

namespace GatewayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public TaskController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        //Mettre methode get, get par id et post
        [HttpPost("create")]
        public async Task<IActionResult> Create(TaskCreate model)
        {
            // Create an HttpClient instance using the factory
            using (var client = _httpClientFactory.CreateClient())
            {
                // Set the base address of the API you want to call
                client.BaseAddress = new System.Uri("http://localhost:5002/");

                // Send a POST request to the login endpoint
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Tasks/create", model);

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    // You can deserialize the response content here if needed
                    var result = await response.Content.ReadFromJsonAsync<TaskDTO>();
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Create failed");
                }
            }
        }

        
    }
}
