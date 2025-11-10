using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Data;  // Updated namespace for your DbContext

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure EF Core to use SQLite and the correct connection string
builder.Services.AddDbContext<MusicContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MusicContext")
        ?? "Data Source=music.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
