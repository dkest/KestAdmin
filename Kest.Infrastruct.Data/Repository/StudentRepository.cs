using Kest.Domain.Interfaces;
using Kest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kest.Infrastruct.Data.Repository
{
    /// <summary>
    /// Customer仓储，操作对象还是领域对象
    /// </summary>
    public class StudentRepository : Repository<Customer>, IStudentRepository
    {
        public Customer GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
