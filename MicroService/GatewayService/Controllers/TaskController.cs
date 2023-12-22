using GatewayService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

/**
 * quand je create depuis swagger de la gateway
 * je vois rien quand je get depuis swagger de TaskService
**/
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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Create an HttpClient instance using the factory
            using (var client = _httpClientFactory.CreateClient())
            {
                // Set the base address of the API you want to call
                client.BaseAddress = new System.Uri("http://localhost:5002/");

                // Send a POST request to the login endpoint
                HttpResponseMessage response = await client.DeleteAsync("api/Tasks/delete/" + id);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return Ok();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Task with the specified ID was not found
                    return NotFound();
                }
                else
                {
                    return BadRequest("Delete failed");
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Create an HttpClient instance using the factory
            using (var client = _httpClientFactory.CreateClient())
            {
                // Set the base address of the API you want to call
                client.BaseAddress = new System.Uri("http://localhost:5002/");

                // Send a POST request to the login endpoint
                HttpResponseMessage response = await client.GetAsync("api/Tasks");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // You can deserialize the response content here if needed
                    var result = await response.Content.ReadFromJsonAsync<IEnumerable<TaskDTO>>();
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Get failed");
                }
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // Create an HttpClient instance using the factory
            using (var client = _httpClientFactory.CreateClient())
            {
                // Set the base address of the API you want to call
                client.BaseAddress = new System.Uri("http://localhost:5002/");

                // Send a POST request to the login endpoint
                HttpResponseMessage response = await client.GetAsync("api/Tasks/" + id);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // You can deserialize the response content here if needed
                    var result = await response.Content.ReadFromJsonAsync<TaskDTO>();
                    return Ok(result);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Task with the specified ID was not found
                    return NotFound();
                }
                else
                {
                    return BadRequest("Get failed");
                }
            }
        }

        
    }
}
    