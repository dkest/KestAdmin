using Kest.Domain.Models;
using NPoco.FluentMappings;

namespace Kest.Infrastruct.Data.NPoco
{
    public class NPocoDatabaseMappings : Mappings
    {
        public NPocoDatabaseMappings()
        {


            /* begin SqlServer */
            For<User>().TableName("Users").PrimaryKey(p => p.Id, false);


            /* end SqlServer */
        }
    }
}
