using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace mg.Controllers
{
    public class TaskController : ApiController
    {
        private static List<Task> tasks = new List<Task>(); 

        public IHttpActionResult CreateTask(Task task)
        {
            if (task == null)
            {
                return BadRequest("Wrong task data");
            }

            tasks.Add(task);
            return Ok("Task created");
        }

        public IHttpActionResult GetAllTasks()
        {
            return Ok(tasks);
        }

        public IHttpActionResult GetTaskById(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
        public IHttpActionResult UpdateTask(int id, Task updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Status = updatedTask.Status;

            return Ok("Task updated");
        }
        public IHttpActionResult DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            tasks.Remove(task);
            return Ok("Task deleted");
        }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
