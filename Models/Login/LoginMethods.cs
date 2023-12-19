namespace TestBudgeting.Models.Login
{
    public static class LoginMethods
    {
        private static IConfiguration Configuration { get; set; }

        static LoginMethods()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public static bool LoginAttempt(Login login)
        {
            string username = Configuration["LoginCredentials:Username"];
            string password = Configuration["LoginCredentials:Password"];

            if (login.Username == username && login.Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
