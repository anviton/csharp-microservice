namespace TaskService.Entities
{
    /// <summary>
    /// Represents a task entity with properties like Id, Text, IsDone, and userId.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the unique identifier for the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the required text description of the task.
        /// </summary>
        public required string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the task is done or not.
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Gets or sets the user identifier associated with the task.
        /// </summary>
        public int userId { get; set; }
    }

    /// <summary>
    /// Represents a data transfer object (DTO) for tasks with properties like Id, Text, IsDone, and userId.
    /// </summary>
    public class TaskDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the required text description of the task.
        /// </summary>
        public required string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the task is done or not.
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Gets or sets the user identifier associated with the task.
        /// </summary>
        public int userId { get; set; }
    }

    /// <summary>
    /// Represents a data transfer object (DTO) for creating tasks with properties like Text and IsDone.
    /// </summary>
    public class TaskCreate
    {
        /// <summary>
        /// Gets or sets the required text description of the task.
        /// </summary>
        public required string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the task is done or not.
        /// </summary>
        public bool IsDone { get; set; }
    }
}
