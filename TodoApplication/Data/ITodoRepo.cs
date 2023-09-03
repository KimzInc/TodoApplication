using TodoApplication.Models;

namespace TodoApplication.Data
{
    public interface ITodoRepo
    {
        Task SaveChangesAsyc();

        Task<Todo?> GetTodoItemById(int id);

        Task<IEnumerable<Todo>> GetAllTodoItems();

        Task CreateTodoItem(Todo item);

        void DeleteTodoItem(Todo todo);
    }
}
