using Front.Entities;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Cryptography;

namespace Front.Services
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;
        private ProtectedLocalStorage _storage;

        public LoginService(HttpClient httpClient, ProtectedLocalStorage storage)
        {
            //_httpClient = new HttpClient();
            _httpClient = httpClient;
            _storage = storage;
            
            //_httpClient.BaseAddress = new System.Uri("http://localhost:5000/");
        }

        public async Task<UserDTO> AuthenticateUser(string username, string password)
        {
            UserLogin userLogin = new() { Name = username, Pass = password };
            JWTAndUser result = null;
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/User/login", userLogin);

            // Désérialiser la chaîne JSON en un objet approprié
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<JWTAndUser>();
                await _storage.SetAsync("jwt", result.Token);
            }
            return result.User;
        }
    }
}

