using System.ComponentModel.DataAnnotations;

namespace Front.Entities
{
    /// <summary>
    /// Represents a user data transfer object.
    /// </summary>
    public class UserDTO
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user's name.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        public required string Email { get; set; }

        public required string Role { get; set; }
    }

    /// <summary>
    /// Represents a data transfer object for user login information.
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// Gets or sets the user's name for login.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the user's password for login.
        /// </summary>
        public required string Pass { get; set; }
        public string Role { get; set; }

    }

    /// <summary>
    /// Represents a data transfer object for user registration information.
    /// </summary>
    public class UserRegister
    {
        /// <summary>
        /// Gets or sets the user's name for registration.
        /// </summary>
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Username can only contain alphanumeric characters.")]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the user's password for registration.
        /// </summary>
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Password can only contain alphanumeric characters.")]
        public required string Pass { get; set; }

        /// <summary>
        /// Gets or sets the user's email address for registration.
        /// </summary>
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public required string Email { get; set; }
    }

    /// <summary>
    /// Represents a data transfer object containing JWT token and user information.
    /// </summary>
    public class JWTAndUser
    {
        /// <summary>
        /// Gets or sets the JWT token.
        /// </summary>
        public required string Token { get; set; }

        /// <summary>
        /// Gets or sets the user information.
        /// </summary>
        public required UserDTO User { get; set; }


        public required string Role { get; set; }

    }
}