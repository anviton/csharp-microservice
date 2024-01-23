using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace UserService.Entities
{
    /// <summary>
    /// Represents a user entity with properties like Id, Name, Email, and PasswordHash.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>z
        /// Gets or sets the user's name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the password hash associated with the user's password.
        /// </summary>
        public string? PasswordHash { get; set; }

        public string? Role { get; set; }

        /// <summary>
        /// Overrides the ToString() method to provide a string representation of the user.
        /// </summary>
        /// 
        public override string ToString()
        {
            return $"Id: ${Id} Name: ${Name} Email : ${Email} Pass: ${PasswordHash}";
        }
    }

    /// <summary>
    /// Represents a data transfer object (DTO) for users with properties like Id, Name, and Email.
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user's name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        public string? Email { get; set; }

        public string? Role { get; set; }
    }

    /// <summary>
    /// Represents a data transfer object (DTO) for user registration with properties like Name, Pass, and Email.
    /// </summary>
    public class UserRegister
    {
        /// <summary>
        /// Gets or sets the required name for user registration.
        /// </summary>
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Le nom d'utilisateur ne peut contenir que des caractères alphanumériques.")]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the required password for user registration.
        /// </summary>
        public required string Pass { get; set; }


        /// <summary>
        /// Gets or sets the required email for user registration.
        /// </summary>
        [EmailAddress(ErrorMessage = "Le format de l'adresse email est incorrect.")]
        public required string Email { get; set; }
    }

    /// <summary>
    /// Represents a data transfer object (DTO) for updating user information with properties like Id, Password, Name, and Email.
    /// </summary>
    public class UserUpdateModel 
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the user's name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        public string? Email { get; set; }
    }

    /// <summary>
    /// Represents a data transfer object (DTO) for user login with properties like Name and Pass (Password).
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// Gets or sets the required name for user login.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the required password for user login.
        /// </summary>
        public required string Pass { get; set; }

    }

    /// <summary>
    /// Represents a data transfer object (DTO) for JWT (JSON Web Token) along with user information.
    /// </summary>
    public class JWTAndUser 
    {
        /// <summary>
        /// Gets or sets the required JWT token.
        /// </summary>
        public required string Token { get; set; }

        /// <summary>
        /// Gets or sets the required user information.
        /// </summary>
        public required UserDTO User { get; set; }


        public required string Role {  get; set; }
    }
}
