using BulkyWebRazor.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
    .Services
     .AddDbContext<ApplicationDbContext>(option =>
     {
         option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
     })
    .AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error")
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        .UseHsts();
}

app.UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthorization();

app.MapRazorPages();
app.Run();
