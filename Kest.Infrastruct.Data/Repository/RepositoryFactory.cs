using Kest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kest.Infrastruct.Data.Repository
{
    public sealed class RepositoryFactory : IRepositoryFactory
    {
        //public IRepositoryTransaction CreateRepositoryTransaction() { return new RepositoryTransaction(); }

        public IUserRepository CreateUserRepository() => new UserRepository();


    }
}
