namespace Webinar1App.Services
{
    class AuthService : IAuthService
    {
        public bool Authorize(string login, string password)
        {
            // ну, понятно, что здесь нужно что-то посерьезнее написать ))

            return login == "admin" && password == "12345";
        }
    }
}
