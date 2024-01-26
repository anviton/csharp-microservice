using Front.Components.Pages;
using Front.Entities;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Front.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private ProtectedLocalStorage _storage;

        public UserService(HttpClient httpClient, ProtectedLocalStorage storage)
        {
            _httpClient = httpClient;
            _storage    = storage;
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var jwt = await _storage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);

            try
            {
                List<UserDTO> users = null;

                var response = await _httpClient.GetFromJsonAsync<List<UserDTO>>("http://localhost:5000/api/User/users");

                if (response != null)
                {
                    users = response.ToList();
                }

                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        // Get an user by a given ID
        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var jwt = await _storage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);

            try
            {
                var response = await _httpClient.GetFromJsonAsync<UserDTO>($"http://localhost:5000/api/User/{userId}");

                return response;
            }
            catch (Exception ex)
            {
                // Gérez les erreurs, par exemple, en journalisant l'exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        // ADMIN : delete an user
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var jwt = await _storage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);

            try
            {
                var response = await _httpClient.DeleteAsync($"http://localhost:5000/api/User/{userId}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // It's a good practice to log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}
