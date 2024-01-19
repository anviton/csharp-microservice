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
            var response = await _httpClient.GetFromJsonAsync<List<TaskToDo>>("http://localhost:5000/api/Tasks");
            if (response != null)
            {
                tasks = response.ToList();
            }
            return tasks;
        }

        // Méthode pour lister les tâches de l'utilisateur connecté
        /*public async Task<List<TaskToDo>> GetTasksForUser(string userId)
        {
            var userTasks;

            var allTasks = await GetTasks(); // Obtenir toutes les tâches

            // Filtrer les tâches pour l'utilisateur spécifié (simulé ici)
            // userTasks = allTasks.FindAll(task => task.UserId == userId);

            return userTasks;
        }*/

        // Méthode pour supprimer une tâche
        public async Task<bool> DeleteTask(int taskId)
        {
            var allTasks = await GetTasks(); // Obtenir toutes les tâches

            // Recherche de la tâche à supprimer par son ID (simulé ici)
            var taskToDelete = allTasks.Find(task => task.Id == taskId);

            if (taskToDelete != null)
            {
                allTasks.Remove(taskToDelete);
                return true;
            }

            return false;
        }

        // Méthode pour mettre à jour une tâche
        public async Task<bool> UpdateTask(TaskToDo updatedTask)
        {
            var allTasks = await GetTasks(); // Obtenir toutes les tâches

            // Recherche de la tâche à mettre à jour par son ID 
            var taskToUpdate = allTasks.Find(task => task.Id == updatedTask.Id);

            if (taskToUpdate != null)
            {
                // Mise à jour des propriétés de la tâche 

                return true; // Indique que la mise à jour a réussi
            }

            return false;
        }

    }
}
