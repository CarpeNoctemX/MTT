using System.Data.Entity;
using System.Data.Entity.SqlServer;
namespace MTT.DAL
{
    public class OrganizationConfiguration : DbConfiguration
    {
        public OrganizationConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}