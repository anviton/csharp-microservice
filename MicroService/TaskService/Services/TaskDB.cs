namespace TaskService.Services
{
    public class TaskDB
    {
        public List<Entities.Task> Tasks { get; set; }
        public int taskIndex { get; set;}
        public TaskDB()
        {
            Tasks = new List<Entities.Task>();
            taskIndex = 0;
        }
    }
}
