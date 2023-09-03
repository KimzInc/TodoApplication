using AutoMapper;
using TodoApplication.Dtos;
using TodoApplication.Models;

namespace TodoApplication.Profiles
{
    public class TodosProfile: Profile
    {
        public TodosProfile()
        {
            // source => Target
            CreateMap<Todo, TodoReadDto>();
            CreateMap<TodoCreateDto, Todo>();
            CreateMap<TodoUpdateDto, Todo>();

        }
    }
}
