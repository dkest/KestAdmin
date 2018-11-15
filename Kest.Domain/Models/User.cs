namespace Kest.Domain.Models
{
    public class User : IEntity<int>
    {
        public int Id { get; private set; }

        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public RoleId RoleId { get; private set; }
    }
}
