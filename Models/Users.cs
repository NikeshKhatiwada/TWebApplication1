namespace TWebApplicationMVC1.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Image { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Password { get; set; }
    }
}
