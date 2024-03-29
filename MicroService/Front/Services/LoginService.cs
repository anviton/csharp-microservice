﻿using Front.Entities;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Front.Services
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;
        private ProtectedLocalStorage _storage;

        public LoginService(HttpClient httpClient, ProtectedLocalStorage storage)
        {
            _httpClient = httpClient;
            _storage = storage;
        }

        // Authenticate a user by sending a POST request to the login API
        public async Task<UserDTO> AuthenticateUser(string username, string password)
        {
            UserLogin userLogin = new() { Name = username, Pass = password };
            JWTAndUser result = null;
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/User/login", userLogin);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<JWTAndUser>();
                await _storage.SetAsync("jwt", result.Token);
            }
            return result == null ? null : result.User;
        }
    }
}
