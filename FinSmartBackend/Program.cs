// Import necessary namespaces
using FinSmartBackend.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;

// Create a web application builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add MVC controllers
builder.Services.AddControllers();
builder.Services.AddTransient<SeedData>();
// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
// Add Entity Framework Core DbContext service with SQL Server as the database provider
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add authorization services
builder.Services.AddAuthorization();

// Add Identity services for user authentication
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<DataContext>();

// Build the application
var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata") SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedData>();
        service.Initialize(scope.ServiceProvider);
    }
}

// Configure the HTTP request pipeline.

// Enable Swagger and Swagger UI only in the development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Map Identity API endpoints for user authentication
app.MapIdentityApi<IdentityUser>();

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable authorization middleware
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Start the application
app.Run();
