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
            //_httpClient = new HttpClient();
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new System.Uri("http://localhost:5000/");
        }

        public async Task<UserDTO> AuthenticateUser(string username, string password)
        {
            UserLogin userLogin = new() { Name = username, Pass = password };
            UserDTO result = null;
            Console.WriteLine("TEST 1: ");
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/User/login", userLogin);
            Console.WriteLine("TEST 2: ");    
            Console.WriteLine(response.Content);

            // Désérialiser la chaîne JSON en un objet approprié
            if (response.IsSuccessStatusCode)
            {
                 result = await response.Content.ReadFromJsonAsync<UserDTO>();
            }

            /*return new UserDTO
            {
                Id = 0,
                Email = "test@test.fr",
                Name = "test",
            };*/

            return result;
        }
    }
}

