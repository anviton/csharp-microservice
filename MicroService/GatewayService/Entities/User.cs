using System.ComponentModel.DataAnnotations;

namespace GatewayService.Entities
{
    /// <summary>
    /// Represents a data transfer object (DTO) for user information.
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the required user name.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the required user email.
        /// </summary>
        public required string Email { get; set; }

        public string? Role { get; set; }
    }

    /// <summary>
    /// Represents a data transfer object (DTO) for user login information.
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// Gets or sets the required user name for login.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the required user password for login.
        /// </summary>
        public required string Pass { get; set; }
    }

    /// <summary>
    /// Represents a data transfer object (DTO) for user registration information.
    /// </summary>
    public class UserRegister
    {
        /// <summary>
        /// Gets or sets the required user name for registration.
        /// </summary>
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Le nom d'utilisateur ne peut contenir que des caractères alphanumériques.")]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the required user password for registration.
        /// </summary>
        /// 
        public required string Pass { get; set; }

        /// <summary>
        /// Gets or sets the required user email for registration with email format validation.
        /// </summary>
        [EmailAddress(ErrorMessage = "Le format de l'adresse email est incorrect.")]
        public required string Email { get; set; }
    }

    /// <summary>
    /// Represents a data transfer object (DTO) containing a JWT token and user information.
    /// </summary>
    public class JWTAndUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JWTAndUser"/> class with user information and a token.
        /// </summary>
        /// <param name="user">The user information.</param>
        /// <param name="token">The JWT token.</param>
        public JWTAndUser(UserDTO user, string token, string role)
        {
            User = user;
            Token = token;
            Role = role;
        }

        /// <summary>
        /// Gets or sets the JWT token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the user information.
        /// </summary>
        public UserDTO User { get; set; }

        public string Role { get; set; }
    }
}
