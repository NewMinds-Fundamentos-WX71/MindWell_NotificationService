using Microsoft.EntityFrameworkCore;
using MindWell_NotificationService;
using MindWell_NotificationService.Notification.Domain.Repositories;
using MindWell_NotificationService.Notification.Domain.Services;
using MindWell_NotificationService.Notification.Mapping;
using MindWell_NotificationService.Notification.Persistence.Repositories;
using MindWell_NotificationService.Notification.Services;
using MindWell_NotificationService.Shared.Persistence.Context;
using MindWell_NotificationService.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

//NotificationService

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency injection
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));


var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
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



app.Run();

