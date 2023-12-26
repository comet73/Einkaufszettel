using Einkaufszettel.Repository;
using Einkaufszettel.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddDbContext<EinkaufContext>(options => options.UseSqlite("Data Source=Einkaufszettel.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Development environment");
    app.UseDeveloperExceptionPage();
    app.UseSpa(spa =>
    {
        spa.Options.SourcePath = "../View";
    });
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");

    routes.MapSpaFallbackRoute(
        name: "spa-fallback",
        defaults: new { controller = "Home", action = "Index" });
});

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    Console.WriteLine("Creating database");
    var context = scope.ServiceProvider.GetRequiredService<EinkaufContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    Console.WriteLine("Database created");
}

app.Run();
