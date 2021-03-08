namespace Webinar1App.Data
{
    interface IUnitOfWork
    {
        IRepository Repository { get; }

        void SaveChanges();
    }
}