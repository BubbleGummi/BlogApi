namespace BlogApi.Controllers
{
    public partial class IdentityController
    {
        public class RegisterModel
        {
            public string? Email { get; set; } 
            public string? Password { get; set; }
        }
    }
}
