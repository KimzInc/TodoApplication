﻿using Microsoft.EntityFrameworkCore;
using TodoApplication.Models;

namespace TodoApplication.Data
{
    public class TodoDbContext:DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            :base(options)
        {
            
        }


        public DbSet<Todo> Todos { get; set; }
    }
}
