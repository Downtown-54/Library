using LibraryApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(); // ???????? ??????? CORS
builder.Services.AddSingleton<IDbRedaers, DbReader>();
builder.Services.AddSingleton<IDbBook, DbBook>();
builder.Services.AddSingleton<IDbIssuedBook, DbIssuedBook>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
