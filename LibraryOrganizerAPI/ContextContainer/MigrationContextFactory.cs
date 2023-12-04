using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Repository.EFCore;

namespace LibraryOrganizerAPI.ContextContainer
{
    public class MigrationContextFactory
    {
        //Migrationların konumlandırmasını ayarlar
        public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
        {
            public RepositoryContext CreateDbContext(string[] args)
            {
                //appsetting.json dosyasına erişime olanak sağlar
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();

                //appsetting.json dosyasındaki 'sqlConnection' alanına erişir ve istenilen klasöre kaydeder
                var builder = new DbContextOptionsBuilder<RepositoryContext>()
                    .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    prj => prj.MigrationsAssembly("LibraryOrganizerAPI"));

                return new RepositoryContext(builder.Options);
            }
        }
    }
}
