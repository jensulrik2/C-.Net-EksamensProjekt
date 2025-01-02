using BusinessLogic.BLL;
using DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the TidsregistreringBLL service
builder.Services.AddScoped<TidsregistreringBLL>();

// Register AfdelingBLL and its dependencies
builder.Services.AddScoped<AfdelingBLL>();

// Register MedarbejderBLL and its dependencies
builder.Services.AddScoped<MedarbejderBLL>();

// Register SagBLL and its dependencies
builder.Services.AddScoped<SagBLL>();

// Register DbContext
//builder.Services.AddDbContext<Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();