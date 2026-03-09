using Microsoft.EntityFrameworkCore;
using WebAPICRUD.Data;
using WebAPICRUD.Middleware;
using WebAPICRUD.Services.Factories;
using WebAPICRUD.Services.Implementations;
using WebAPICRUD.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            //ValidIssuer="dsbnb",
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<INotificationFactory, NotificationFactory>();

builder.Services.AddScoped<IPaymentMethods, CardPay>();
builder.Services.AddScoped<IPaymentMethods, UPIPay>();
builder.Services.AddScoped<IPaymentMethods, PODPay>();
builder.Services.AddScoped<IPaymentFactory, PaymentFactory>();

builder.Services.AddScoped<IVehicleService, Car>();
builder.Services.AddScoped<IVehicleService, Jeep>();
builder.Services.AddScoped<IVehicleService, Bus>();
builder.Services.AddScoped<IVehicleFactory,VehicleFactory>();

builder.Services.AddScoped<ITokenService, TokenService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ExceptionMiddleware>();
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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
