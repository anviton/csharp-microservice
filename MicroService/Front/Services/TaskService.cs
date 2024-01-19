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

        // Méthode pour supprimer une tâche
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

        // Méthode pour mettre à jour une tâche
        public async Task<bool> UpdateTask(TaskToDo updatedTask)
        {
            var jwt = await _storage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);

            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5000/api/Task/{updatedTask.Id}", updatedTask);

            return response.IsSuccessStatusCode;
        }


        // Ajout une tâche
        public async Task<bool> AddTask(TaskToDo newTask)
        {
            var jwt = await _storage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/Task/create", newTask);

            return response.IsSuccessStatusCode;
        }

    }
}
