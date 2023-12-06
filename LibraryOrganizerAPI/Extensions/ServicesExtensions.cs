using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Repository.Contracts;
using Repository.EFCore;
using Services;
using Services.Contracts;

namespace LibraryOrganizerAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlConnection(this IServiceCollection services, IConfiguration configuration)
        {
            //SQL Connection string Dependency Injection yöntemi ile projeye servis edildi.
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IBookService, BookManager>();
        }

    }
}
