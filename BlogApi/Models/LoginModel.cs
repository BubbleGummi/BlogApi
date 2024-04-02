namespace BlogApi.Controllers
{
    public partial class IdentityController
    {
        public class LoginModel
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }
    }
}
