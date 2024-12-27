using contactManagement.APIs.Middlewares;
using contactManagement.DAL;
using contactManagement.DAL.Implementations;
using contactManagement.DAL.Interfaces;
using contactManagement.DomainModels.Entities;
using contactManagement.Services.Implementations;
using contactManagement.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Automatically return a BadRequest response with model state errors
        options.SuppressModelStateInvalidFilter = false;
    });

//Register Repositories
builder.Services.AddTransient<IContactRepository, ContactRepository>();

//Register Services
builder.Services.AddScoped<IContactService, ContactService>();

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

//configure global custom middlerware for error handling
app.UseErrorHandlingMiddleware();

app.UseAuthorization();
app.MapControllers();



app.Run();
