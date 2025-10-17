using Microsoft.EntityFrameworkCore;
using _8to10.Features.Books;
using _8to10.Persistence;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<BookManagementContext>(options =>
    options.UseSqlite("Data Source=bookmanagement.db"));
builder.Services.AddScoped<CreateBookHandler>();
builder.Services.AddScoped<GetAllBookHandler>();
builder.Services.AddScoped<DeleteBookHandler>();
builder.Services.AddScoped<GetBookByIdHandler>();
builder.Services.AddScoped<UpdateBookHandler>();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Ensure the database is created at runtime
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BookManagementContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/books", async (CreateBookRequest req, CreateBookHandler handler) =>
    await handler.Handle(req));
app.MapGet("/books", async (int? page, int? pageSize, GetAllBookHandler handler) =>
{
    var request = new GetAllBookRequest(page ?? 1, pageSize ?? 10);
    return await handler.Handle(request);
});
app.MapDelete("/books/{id:guid}", async (Guid id, DeleteBookHandler handler) =>
    await handler.Handle(new DeleteBookRequest(id)));
app.MapGet("/books/{id:guid}", async (Guid id, GetBookByIdHandler handler) =>
    await handler.Handle(new GetBookByIdRequest(id)));
app.MapPut("/books/{id:guid}", async (Guid id, UpdateBookRequest req, UpdateBookHandler handler) =>
    await handler.Handle(req with { Id = id }));

app.Run();