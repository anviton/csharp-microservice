using GatewayService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

/**
 * rajouter la gestion du jwt
 * 
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

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create(TaskCreate model)
        {
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (UserId == null) return Unauthorized();

            using (var client = _httpClientFactory.CreateClient())
            {
                // Set the base address of the API you want to call
                client.BaseAddress = new System.Uri("http://localhost:5002/");

                // Send a POST request to the login endpoint
                HttpResponseMessage response = await client.PostAsJsonAsync($"api/Tasks/create/{UserId}", model);

                if (response.IsSuccessStatusCode)
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

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (UserId == null) return Unauthorized();
            // Create an HttpClient instance using the factory
            using (var client = _httpClientFactory.CreateClient())
            {
                // Set the base address of the API you want to call
                client.BaseAddress = new System.Uri("http://localhost:5002/");

                // Send a POST request to the login endpoint
                HttpResponseMessage response = await client.DeleteAsync($"api/Tasks/delete/{UserId}/{id}");

                if (response.IsSuccessStatusCode)
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //avec userIdclaim on recupere l'id de l'utilisateur et on utilise pour trouver les taches associées
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            
            // On vérifie qu'elle existe bien
            if (UserId == null)
            {
                return Unauthorized("User not authenticated or missing UserId claim");
            }

            // Create an HttpClient instance using the factory
            using (var client = _httpClientFactory.CreateClient())
            {
                // Set the base address of the API you want to call
                client.BaseAddress = new System.Uri("http://localhost:5002/");

                // Send a POST request to the login endpoint
                HttpResponseMessage response = await client.GetAsync($"api/Tasks/{UserId}");

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

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TaskCreate model)
        {
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (UserId == null) return Unauthorized();

            // Create an HttpClient instance using the factory
            using (var client = _httpClientFactory.CreateClient())
            {
                // Set the base address of the API you want to call
                client.BaseAddress = new System.Uri("http://localhost:5002/");

                // Send a POST request to the login endpoint
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/Tasks/update/{UserId}/{id}", model);

                if (response.IsSuccessStatusCode)
                {
                    // You can deserialize the response content here if needed
                    return Ok();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Task with the specified ID was not found
                    return NotFound();
                }
                else
                {
                    return BadRequest("Put failed");
                }
            }
        }

        
    }
}
    