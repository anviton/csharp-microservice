namespace Front.Entities
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
}
