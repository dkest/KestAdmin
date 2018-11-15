using Kest.Domain.Models;

namespace Kest.Domain.Interfaces
{
    /// <summary>
    /// IUserRepository 接口
    /// 注意， 这里我们用到的业务对象，是领域对象
    /// </summary>
    public interface IUserRepository : IBaseRepository<User,int>
    {
        
        User GetByEmail(string email);
    }
}
