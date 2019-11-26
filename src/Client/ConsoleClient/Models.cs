namespace Apep.ConsoleApp
{
    public static class Models
    {
        public class SecurityToken
        {
            public string auth_token { get; set; }
        }

        public class Login
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

    }
}
