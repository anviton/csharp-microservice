using Front.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing.Tree;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Security.Claims;

namespace Front.Services
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDTO> AuthenticateUser(string username, string password)
        {
            UserLogin userLogin = new() { Name = username, Pass = password };
            var response = await _httpClient.PostAsJsonAsync("/api/User/login", userLogin);
            Console.WriteLine(response.StatusCode);
            return new UserDTO
            {
                Id = 0,
                Email = "test@test.fr",
                Name = username,
            };
        }
    }
}

