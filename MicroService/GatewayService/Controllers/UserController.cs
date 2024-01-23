using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GatewayService.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GatewayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Generate a JWT token with the user's ID as a claim
        private string GenerateJwtToken(int userId)
        {
            var claims = new List<Claim>
            {
                // Add a UserId field to our token with the userId as a string value
                new Claim("UserId", userId.ToString())
            };

            // Create the encryption key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyLongLongLongLongEnough"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Configure our token
            var token = new JwtSecurityToken(
                issuer: "TodoProject", // Issuer of the token
                audience: "localhost:5000", // Token audience
                claims: claims, // Data to be encoded in the token
                expires: DateTime.Now.AddMinutes(3000), // Expiration time
                signingCredentials: creds); // Encryption key

            // Return the signed token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // POST: api/User/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin model)
        {
            // Create an HttpClient instance using the factory
            using (var client = _httpClientFactory.CreateClient())
            {
                // Set the base address of the API you want to call
                client.BaseAddress = new System.Uri("http://localhost:5001/");

                // Send a POST request to the login endpoint
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Users/login", model);

                // Check if the response status code is 200 (OK)
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // Deserialize the response content if needed
                    var user = await response.Content.ReadFromJsonAsync<UserDTO>();
                    var token = GenerateJwtToken(user.Id);
                    return Ok(new JWTAndUser(user, token, user.Role));
                }
                else
                {
                    return BadRequest("Login failed");
                }
            }
        }

        // POST: api/User/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister model)
        {
            // Create an HttpClient instance using the factory
            using (var client = _httpClientFactory.CreateClient())
            {
                // Set the base address of the API you want to call
                client.BaseAddress = new System.Uri("http://localhost:5001/");

                // Send a POST request to the login endpoint
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Users/register", model);

                // Check if the response status code is 201 (Created)
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    // Deserialize the response content if needed
                    var result = await response.Content.ReadFromJsonAsync<UserDTO>();
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Register failed");
                }
            }
        }


        // GET: api/User/users
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:5001/");

                HttpResponseMessage response = await client.GetAsync("api/Users");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var users = await response.Content.ReadFromJsonAsync<List<UserDTO>>();
                    return Ok(users);
                }
                else
                {
                    return BadRequest("Failed to retrieve users");
                }
            }
        }
    }
}
