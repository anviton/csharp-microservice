using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskService.Data;
using TaskService.Entities;
using TaskService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private TaskServiceContext _taskContext;

        public TasksController(TaskServiceContext taskContext)
        {
            _taskContext = taskContext;
        }

        // GET api/Tasks/5
        [HttpGet("{userId}")]
        public ActionResult<Entities.Task> Get(int userId)
        {
            List<Entities.Task> tasks = _taskContext.Task.Where(task => task.userId == userId).ToList();

            if(tasks == null)
            {
                return NotFound();
            }

            return Ok(tasks);
        }


        // POST api/Tasks/create
        [HttpPost("create/{uid}")]
        public async Task<ActionResult<Entities.Task>> CreateTask(TaskCreate taskPayload, int uid)
        {
            try
            {
                var newTask = new Entities.Task
                {
                    Text = taskPayload.Text,
                    IsDone = taskPayload.IsDone,
                    userId = uid
                };

                _taskContext.Add(newTask);
                await _taskContext.SaveChangesAsync();

                return Ok(newTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/Tasks/update/2/5
        [HttpPut("update/{UserId}/{id}")]
        public async Task<ActionResult<Entities.Task>> Put(int id, TaskCreate taskUpdate)
        {
            try
            {
                var task = await _taskContext.Task.FindAsync(id);

                if (task == null)
                {
                    return NotFound();
                }

                task.Text   = taskUpdate.Text;
                task.IsDone = taskUpdate.IsDone;
                await _taskContext.SaveChangesAsync();

                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // DELETE api/Tasks/delete/2/5
        [HttpDelete("delete/{UserId}/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var taskToRemove = _taskContext.Task.Where(task => task.Id == id).FirstOrDefault();

            if(null != taskToRemove)
            {
                _taskContext.Remove(taskToRemove);
                await _taskContext.SaveChangesAsync();

                return NoContent();
            }
            else
            {
                return NotFound();
            }
           
        }
    }
}
