using Front.Entities;

namespace Front.Services
{
    public class RegisterService
    {
        private readonly HttpClient _httpClient;

        public RegisterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> RegisterUser(string username, string password, string email)
        {
            UserRegister userRegister = new() { Name = username, Pass = password, Email = email };
            int result = 1;

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/User/register", userRegister);

            if (response.IsSuccessStatusCode && password != null)
            {
                result = 0;
            }

            return result;
        }
    }
}
