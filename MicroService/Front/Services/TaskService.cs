using Microsoft.AspNetCore.Authentication;
using Front.Entities;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Front.Services
{
    public class TaskService
    {
        private readonly HttpClient _httpClient;
        private ProtectedLocalStorage _storage;

        public TaskService(HttpClient httpClient, ProtectedLocalStorage storage)
        {
            _httpClient = httpClient;
            _storage = storage;
        }

        // Fetch the user's tasks from the server
        public async Task<List<TaskToDo>> GetTasks()
        {
            var jwt = await _storage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);

            List<TaskToDo> tasks = null;

            var response = await _httpClient.GetFromJsonAsync<List<TaskToDo>>("http://localhost:5000/api/Task/");

            if (response != null)
            {
                tasks = response.ToList();
            }

            return tasks;
        }

        // Method to delete a task
        public async Task DeleteTask(int taskId)
        {
            var jwt = await _storage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);

            List<TaskToDo> tasks = null;

            HttpResponseMessage response = await _httpClient.DeleteAsync($"http://localhost:5000/api/Task/delete/{taskId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error on deleting a task.");
            }
        }

        // Method to update a task
        public async Task<bool> UpdateTask(TaskToDo updatedTask)
        {
            var jwt = await _storage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);

            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5000/api/Task/{updatedTask.Id}", updatedTask);

            return response.IsSuccessStatusCode;
        }

        // Add a new task
        public async Task<bool> AddTask(TaskToDo newTask)
        {
            var jwt = await _storage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/Task/create", newTask);

            return response.IsSuccessStatusCode;
        }
    }
}
