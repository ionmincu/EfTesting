using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace EfTesting
{
    [DbConfigurationType(typeof(UiMicrosoftSqlDbConfiguration))]
    public class SchoolContext : DbContext
    {
        public SchoolContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }

    public class MyDbProviderFactoryResolverAsdasd : IDbProviderFactoryResolver
    {
        public DbProviderFactory ResolveProviderFactory(DbConnection connection)
        {
            return Microsoft.Data.SqlClient.SqlClientFactory.Instance;
        }
    }

    public class UiMicrosoftSqlDbConfiguration : DbConfiguration
    {
        public UiMicrosoftSqlDbConfiguration()
        {
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);

            SetProviderFactory(MicrosoftSqlProviderServices.ProviderInvariantName, Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            SetProviderServices(MicrosoftSqlProviderServices.ProviderInvariantName, MicrosoftSqlProviderServices.Instance);

            // --------------------------------------------
            // System.Data.SqlClient or Microsoft.Data.SqlClient
            if (Program.UseMicrosoftSqlClient)
            {
                SetProviderFactoryResolver(new MyDbProviderFactoryResolverAsdasd());
            }
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
