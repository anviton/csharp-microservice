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
        //private int _taskIndex = 0;

        public TasksController(TaskDB taskDB)
        {
            _tasks = taskDB;
            //_tasks = new List<Entities.Task>();
        }

        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<Entities.Task> Get()
        {
            return _tasks.Tasks;
        }

        // GET api/Tasks/5
        [HttpGet("{id}")]
        public Entities.Task? Get(int id)
        {
            return _tasks.Tasks.Find(t => t.Id == id);
        }

        // POST api/Tasks/create
        [HttpPost("create")]
        public ActionResult<Entities.Task> CreateTask(TaskCreate taskPayload)
        {
            var index = _tasks.taskIndex;
            _tasks.taskIndex++;
            var myTask = new Entities.Task
            {
                Id = index,
                IsDone = taskPayload.IsDone,
                Text = taskPayload.Text
            };
            _tasks.Tasks.Add(myTask);

            return CreatedAtAction("Get", new { id = index }, myTask);
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
