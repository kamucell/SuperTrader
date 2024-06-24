using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repository
{
    public static class MigrationDB 

    {
        public static void UpdateDB()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<SuperTraderContext>(options =>
                    options.UseSqlServer(@"data source=.\sqlexpress,1433;initial catalog=SuperTraderDB;Integrated Security=True;TrustServerCertificate=True;"))
                .BuildServiceProvider();



            using (var context = serviceProvider.GetService<SuperTraderContext>())
            {
                try
                {
                    context.Database.Migrate();
                    Console.WriteLine("Migration applied successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while applying migration: {ex.Message}");
                }
            }
        }    
    }
}
