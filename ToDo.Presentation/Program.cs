using System.Reflection.Metadata;
using ToDo.Application.Interfaces;
using ToDo.Application.Queries.GetAllItems;
using ToDo.Data.Dependency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Dependency
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

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
