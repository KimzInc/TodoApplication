﻿namespace TodoApplication.Dtos
{
    public class TodoReadDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool IsComplete { get; set; }
    }
}
