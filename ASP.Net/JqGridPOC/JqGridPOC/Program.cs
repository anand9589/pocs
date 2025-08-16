using Newtonsoft.Json;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/api/customers", () =>
{
    string jsonString = File.ReadAllText(@"C:\Users\anand\source\repos\pocs\ASP.Net\JqGridPOC\testdata.json");

    var persons = JsonConvert.DeserializeObject<Person[]>(jsonString);


return Results.Json(new
{
    total = 1,
    page = 1,
    records = persons.Length,
    rows = persons
});
});


app.Run();


public class Person
{
   public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}