using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<StoreContext>(opt =>{
//     // parsing what we gonna do in here
//     opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
// });

// builder.Services.AddCors();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// // enable the CORS header we send back to client (use authorization)
// app.UseCors(opt => 
// {
//     opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"); // not https
// });

// // Add CORS services and configure the policy
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowLocalhost3000",
//         policy => policy.AllowAnyOrigin() // Allow any origin for testing (you can change this later)
//                        .AllowAnyHeader()
//                        .AllowAnyMethod());
// });

// app.UseAuthorization();

// app.MapControllers();

// var scope = app.Services.CreateScope();
// var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
// var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

// try
// {
//     context.Database.Migrate();
//     Dbinitializer.Initialize(context);
// }
// catch (Exception ex){
//     logger.LogError(ex, "An error occurred during migration");
// }

// app.Run();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
});

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    context.Database.Migrate();
    // DbInitializer.Initialize(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "A problem occurred during migration");
}

app.Run();