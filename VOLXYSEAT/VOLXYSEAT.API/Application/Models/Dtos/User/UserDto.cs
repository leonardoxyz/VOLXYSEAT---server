namespace VOLXYSEAT.API.Application.Models.Dtos.User
{
    public class UserDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Role { get; set; }
    }
}
