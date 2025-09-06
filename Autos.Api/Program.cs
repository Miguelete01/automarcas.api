using Autos.Api.Data;
using Autos.Api.Seeders;
using Autos.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//add dbContext
//builder.Services.AddDbContext<AutosDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("autosDb")));
builder.Services.AddDbContext<AutosDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("dockerContainerAutosDb"), 
    npgsqlOptions => 
    { 
        npgsqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorCodesToAdd: null);
    }));

// Add services to the container.
builder.Services.AddBasicServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

MigrationService.InitalizeMigration(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");// Enable CORS with the defined policy

app.MapControllers();

app.Run();
