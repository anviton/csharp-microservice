using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskService.Entities;
using TaskService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private TaskDB _tasks;

        public TasksController(TaskDB taskDB)
        {
            _tasks = taskDB;
        }

        // GET api/Tasks/5
        [HttpGet("{userId}")]
        public ActionResult<Entities.Task> Get(int userId)
        {   
            List<Entities.Task> tasks = _tasks.Tasks.FindAll(t => t.userId == userId);
            if(tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks);
        }


        // POST api/Tasks/create
        [HttpPost("create/{uid}")]
        public ActionResult<Entities.Task> CreateTask(TaskCreate taskPayload, int uid)
        {
            var index = _tasks.taskIndex;
            _tasks.taskIndex++;
            var myTask = new Entities.Task
            {
                Id = index,
                IsDone = taskPayload.IsDone,
                Text = taskPayload.Text,
                userId = uid
            };
            _tasks.Tasks.Add(myTask);

            return Ok(myTask);
        }

        // PUT api/Tasks/update/5
        [HttpPut("update/{id}")]
        public ActionResult<Entities.Task> Put(int id, TaskCreate taskUpdate)
        {
            var task = _tasks.Tasks.Find(t => t.Id == id);
            if(task == null)
            {
                return NotFound();
            }
            task.Text = taskUpdate.Text;
            task.IsDone = taskUpdate.IsDone;

            return Ok(task);
        }

        // DELETE api/Tasks/delete/5
        [HttpDelete("delete/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var index = _tasks.Tasks.FindIndex(t => t.Id == id);
            if(index == -1)
            {
                return NotFound();
            }
            _tasks.Tasks.RemoveAt(index);
            return Ok(true);
        }
    }
}
