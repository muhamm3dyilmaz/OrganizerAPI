using LibraryOrganizerAPI.Extensions;
using NLog;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

//NLog konfig�rasyon
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.AddControllers(cfg =>
{
    //Farkl� tipteki Accept Headerlar� kabul eder
    cfg.RespectBrowserAcceptHeader = true;
    //Kabul edilmeyen tipte Header gelirse 406 hata kodunu verir
    cfg.ReturnHttpNotAcceptable = true;
})
    //Presentation katman�na controller i�lemlerini yerle�tirir
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

//ServicesExtensions IoC Container
builder.Services.ConfigureSqlConnection(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.ConfigureVersioning();
builder.Services.ConfigurationLoggerManager();
builder.Services.ConfigureActionFilters();




var app = builder.Build();

//ExceptionMiddlewareExceptions i�indeki kulland���m�z servisleri GetRequiredService methodu ile ekledim
var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    //Swagger versiyonlama
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryOrganizer v1");
        s.SwaggerEndpoint("/swagger/v2/swagger.json", "LibraryOrganizer v2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
