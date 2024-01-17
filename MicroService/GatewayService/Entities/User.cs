
using System.ComponentModel.DataAnnotations;

namespace GatewayService.Entities
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
    public class UserLogin
    {
        public required string Name { get; set; }
        public required string Pass { get; set; }
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

    public class JWTAndUser
    {
        public JWTAndUser(UserDTO user, string token)
        {
            User = user;
            Token = token;
        }

        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
