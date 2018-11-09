using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kest.Domain.Interfaces
{
    public interface IRepositoryFactory
    {
        IUserRepository CreateUserRepository();
    }
}
