namespace Webinar1App.Services
{
    interface IAuthService
    {
        bool Authorize(string login, string password);
    }
}