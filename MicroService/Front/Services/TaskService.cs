using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Front.Components.Pages;
using Front.Entities;

namespace Front.Services
{
    public class TaskService
    {
        private readonly HttpClient _httpClient;

        public TaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TaskToDo>> GetTasks()
        {
            List<TaskToDo> tasks = null;
            var response = await _httpClient.GetFromJsonAsync<List<TaskToDo>>("http://localhost:5002/api/Tasks");
            if (response != null)
            {
                tasks = response.ToList();
            }
            return tasks;
        }
    }
}
