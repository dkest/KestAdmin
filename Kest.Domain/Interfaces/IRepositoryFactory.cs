namespace Kest.Domain.Interfaces
{
    public interface IRepositoryFactory
    {
        IUserRepository CreateUserRepository();
    }
}
