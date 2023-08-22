using Microsoft.EntityFrameworkCore;
using RegisterUserAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyProjContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MyProjConn") ?? throw new InvalidOperationException("Connection string 'MyProjContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserDetailsDA, UserDetailsDA>();

var app = builder.Build();

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
