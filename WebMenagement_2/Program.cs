using Contracts;
using NLog;
using WebMenagement_2.Extensions;
using LoggerService;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(Path.Combine(Directory.GetCurrentDirectory(), "NLog.config"));


// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerManager();
builder.Services.ConfigureSqlServer(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
})
    
 
    .AddApplicationPart(typeof(ProjectManagement.Presentation.AssemblyReference).Assembly);



var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerMenager>();
app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
{
	app.UseHsts();


}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
