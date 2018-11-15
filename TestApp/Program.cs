using Kest.Domain;
using Kest.Domain.Interfaces;

namespace TestApp
{
    class Program
    {
        private static IUserRepository userRepository;
        static void Main(string[] args)
        {
            userRepository = RepositoryProvider.Factory.CreateUserRepository();
            var list = userRepository.GetPage(1,2);
            
        }
    }
}
