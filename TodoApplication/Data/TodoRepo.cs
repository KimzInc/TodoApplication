using Microsoft.EntityFrameworkCore;
using TodoApplication.Models;

namespace TodoApplication.Data
{
    public class TodoRepo : ITodoRepo
    {
        private readonly TodoDbContext _context;

        public TodoRepo(TodoDbContext context)
        {
            _context = context;
        }

        public async Task CreateTodoItem(Todo item)
        {
            if (item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            await _context.AddAsync(item);
        }

        public void DeleteTodoItem(Todo todo)
        {
            if (todo==null)
            {
                throw new ArgumentNullException(nameof(todo));
            }

            _context.Todos.Remove(todo);
        }

        public async Task<IEnumerable<Todo>> GetAllTodoItems()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo?> GetTodoItemById(int id)
        {
            return await _context.Todos.FirstOrDefaultAsync(c =>c.Id == id);
        }

        public async Task SaveChangesAsyc()
        {
            await _context.SaveChangesAsync();
        }
    }
}
