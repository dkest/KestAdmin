using AutoMapper;

using Kest.Application.ViewModels;
using Kest.Domain.Models;

namespace Kest.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile:Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>();
        }
    }
}
