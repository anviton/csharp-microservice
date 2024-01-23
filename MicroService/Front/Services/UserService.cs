using Front.Components.Pages;
using Front.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Front.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
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
    }
}
