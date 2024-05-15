using System.Diagnostics.Metrics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseHttpsRedirection();

#region APIs

app.MapPost("/api/countries", async (HttpContext context, CountryTestModel country) =>
{
    var newItem = await repo.Add(country);
    context.Response.Headers.Location = $"/api/countries/{newItem.Id}";
    context.Response.StatusCode = 201;
    await context.Response.WriteAsJsonAsync(country);
});

app.MapGet("/api/countries", async () =>
{
    var item = await repo.GetAll();
    if (item is null)
        return Results.NotFound();
    else
        return Results.Ok(item);
});

app.MapGet("/api/countries/{id}", async (string id) =>
{
    var item = await repo.GetById(id);
    if (item is null)
        return Results.NotFound();
    else
        return Results.Ok(item);
});

app.MapDelete("/api/countries/{id}", async (string id) =>
{
    var result = await repo.Delete(id);
    if (result)
        return Results.Ok();
    else
        return Results.NotFound();
});

app.MapPost("/api/countries/{id}", async (string id, CountryTestModel country) =>
{
    var result = await repo.Update(id, country);
    if (result)
        return Results.Ok();
    else
        return Results.NotFound();
});

//-----------------------------------------------------------------------------------
app.MapGet("/api/DN7Test", async (HttpContext context) =>
{
    return Results.Ok();
});
#endregion APIs


app.Run();


public partial class Program
{
    public static Repository repo = new Repository();
}
