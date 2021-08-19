using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace EfTesting
{
    class Program
    {
        public static readonly string ConStr = "Server=.\\sqlexpress;Database=TestDb2;Integrated Security=true;";

        public static bool UseMicrosoftSqlClient = true;

        static void Main(string[] args)
        {
            // Database.SetInitializer(new NullDatabaseInitializer<SchoolContext>());

            using var context = new SchoolContext(ConStr);

            context.Database.CreateIfNotExists();

            context.WriteDebugProvider();

            var studentsList = context.Students.ToList(); // or context.Set<Student>().ToList();

            Console.WriteLine("Got {0} entities.", studentsList.Count);
        }
    }
}
