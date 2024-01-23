namespace Front.Entities
{
    /// <summary>
    /// Represents a task entity.
    /// </summary>
    public class TaskToDo
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text description of the task.
        /// </summary>
        public required string Text { get; set; }

        public bool IsDone { get; set; }
        public int userId { get; set; }
    }

    /// <summary>
    /// Represents a DTO (Data Transfer Object) for a task.
    /// </summary>
    public class TaskDTO
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text description of the task.
        /// </summary>
        public required string Text { get; set; }

        public bool IsDone { get; set; }
        public int userId { get; set; }
    }

    /// <summary>
    /// Represents a DTO (Data Transfer Object) for creating a new task.
    /// </summary>
    public class TaskCreate
    {
        /// <summary>
        /// Gets or sets the text description of the task.
        /// </summary>
        public required string Text { get; set; }

        public bool IsDone { get; set; }
    }
}
