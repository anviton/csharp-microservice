using Front.Entities;

namespace Front.Services
{
    public class RegisterService
    {
        private readonly HttpClient _httpClient;

        public RegisterService(HttpClient httpClient)
        {
            //_httpClient = new HttpClient();
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new System.Uri("http://localhost:5000/");
        }

        public async Task<int> RegisterUser(string username, string password, string email)
        {
            UserRegister userRegister = new() { Name = username, Pass = password, Email = email };
            int result = 1;
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/User/register", userRegister);

            // Désérialiser la chaîne JSON en un objet approprié
            if (response.IsSuccessStatusCode)
            {
                //result = await response.Content.ReadFromJsonAsync<UserDTO>();
                result = 0;
            }

            return result;
        }
    }
}
