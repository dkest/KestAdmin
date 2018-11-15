namespace Kest.Domain.Models
{
    public enum RoleId
    {
        Unkonown = 0,
        User = 1,
        Admin = 2
    }

    public partial class Role : IEntity<RoleId>
    {
        public RoleId Id { get; private set; }

        public string Value { get; private set; }
    }
}
