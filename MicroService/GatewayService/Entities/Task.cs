namespace GatewayService.Entities
{
    /// <summary>
    /// Represents a task entity.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the unique identifier for the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text description of the task.
        /// </summary>
        public required string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the task is marked as done or not.
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with the task.
        /// </summary>
        public int userId { get; set; }
    }

    /// <summary>
    /// Represents a data transfer object (DTO) for a task.
    /// </summary>
    public class TaskDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text description of the task.
        /// </summary>
        public required string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the task is marked as done or not.
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with the task.
        /// </summary>
        public int userId { get; set; }
    }

    /// <summary>
    /// Represents a data transfer object (DTO) for creating a new task.
    /// </summary>
    public class TaskCreate
    {
        /// <summary>
        /// Gets or sets the text description of the task to be created.
        /// </summary>
        public required string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the task is initially marked as done or not.
        /// </summary>
        public bool IsDone { get; set; }
    }
}
