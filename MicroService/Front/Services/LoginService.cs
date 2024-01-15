using Front.Entities;

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
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/User/login", userLogin);

            // Désérialiser la chaîne JSON en un objet approprié
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<UserDTO>();
            }
            return result;
        }
    }
}

