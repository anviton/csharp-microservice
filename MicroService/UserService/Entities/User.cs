
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace UserService.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set;}
        public string? Email { get; set;}
        public string? PasswordHash { get; set; }

        public override string ToString()
        {
            return $"Id: ${Id} Name: ${Name} Email : ${Email} Pass: ${PasswordHash}";
        }
    }

    public class UserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }

    public class UserRegister
    {
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Le nom d'utilisateur ne peut contenir que des caractères alphanumériques.")]
        public required string Name { get; set; }

        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Le mot de passe ne peut contenir que des caractères alphanumériques.")]
        public required string Pass { get; set; }
        [EmailAddress(ErrorMessage = "Le format de l'adresse email est incorrect.")]
        public required string Email { get; set; }
    }

    public class UserUpdateModel
    {
        public int Id { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
    public class UserLogin
    {
        public required string Name { get; set; }
        public required string Pass { get; set; }
    }

    public class JWTAndUser
    {
        public required string Token { get; set; }
        public required UserDTO User { get; set; }
    }
}
