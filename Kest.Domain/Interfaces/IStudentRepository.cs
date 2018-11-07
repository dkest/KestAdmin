using Kest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kest.Domain.Interfaces
{
    /// <summary>
    /// ICustomerRepository 接口
    /// 注意， 这里我们用到的业务对象，是领域对象
    /// </summary>
    public interface IStudentRepository : IRepository<Student>
    {
        // 一些 Customer 独有的接口 

        Customer GetByEmail(string email);
    }
}
