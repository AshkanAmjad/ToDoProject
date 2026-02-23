using Microsoft.EntityFrameworkCore;
using ToDo.Data.Context;
using ToDo.Data.Repositores;
using ToDo.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region DbContext
builder.Services.AddDbContext<ToDoContext>(opts =>
opts.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
#endregion

#region LifeCycle
builder.Services.AddScoped<IItemRepository, ItemRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();



app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
