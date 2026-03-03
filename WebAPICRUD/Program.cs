using Microsoft.EntityFrameworkCore;
using WebAPICRUD.Data;
using WebAPICRUD.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddCors(options =>
{ 
options.AddPolicy("AllowAngular",
policy => policy
.WithOrigins("http://localhost:4200")
.AllowAnyHeader()
.AllowAnyMethod());
});

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

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.Use(async (context, next) =>
{
    var startTime = DateTime.UtcNow;

    await next();

    var endTime = DateTime.UtcNow;
    var duration = endTime - startTime;

    Console.WriteLine($"Request took: {duration.TotalMilliseconds} ms");
});
app.Use(async (context, next) =>
{
    Console.WriteLine($" Inline : {context.Request.Path}");
    await next();
}
);



app.UseHttpsRedirection();
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();


app.Run();
