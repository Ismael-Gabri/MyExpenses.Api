using MyExpenses.Domain.Handlers;
using MyExpenses.Domain.Infra.Contexts;
using MyExpenses.Domain.Infra.Repositories;
using MyExpenses.Domain.Infra.Services;
using MyExpenses.Domain.Repositories;
using MyExpenses.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<UserHandler, UserHandler>();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMvc();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
