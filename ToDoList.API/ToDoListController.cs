using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Model;

namespace ToDoList.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoListContext _context;

        public ToDoItemsController(ToDoListContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ToDoItems>> GetToDoItemsWithNoCompletedDate()
        {
            var toDoItems = _context.ToDoItems.Where(item => item.DoneDate == null).ToList();
            return Ok(toDoItems);
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoItems> GetToDoItemById(int id)
        {
            var toDoItems = _context.ToDoItems.Find(id);
            if (toDoItems == null)
            {
                return NotFound(); // Return 404 Not Found if the ToDoItem with the specified Id is not found
            }
            return Ok(toDoItems);
        }

        [HttpPost]
        public ActionResult<ToDoItems> CreateToDoItem(ToDoItems toDoItems)
        {
            _context.ToDoItems.Add(toDoItems);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetToDoItemById), new { id = toDoItems.Id }, toDoItems);
        }

        [HttpPost("{id}/complete")]
        public ActionResult CompleteToDoItem(int id)
        {
            var toDoItems = _context.ToDoItems.Find(id);
            if (toDoItems == null)
            {
                return NotFound(); // Return 404 Not Found if the ToDoItem with the specified Id is not found
            }

            // Update the CompletedDate to the current datetime
            toDoItems.DoneDate = DateTime.Now;
            
            _context.SaveChanges();
            return NoContent(); // Return 204 No Content to indicate success
        }
    }
}