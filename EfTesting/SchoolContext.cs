using System.Data.Entity;
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

    public class UiMicrosoftSqlDbConfiguration : DbConfiguration
    {
        public UiMicrosoftSqlDbConfiguration()
        {
            SetProviderFactory(MicrosoftSqlProviderServices.ProviderInvariantName, Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            SetProviderServices(MicrosoftSqlProviderServices.ProviderInvariantName, MicrosoftSqlProviderServices.Instance);
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
