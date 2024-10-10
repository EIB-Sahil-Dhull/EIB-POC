using GdprApp.Models; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() 
                   .AllowAnyMethod() 
                   .AllowAnyHeader(); 
        });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = "mongodb://localhost:27017";
var databaseName = "GDPRAppDB";
builder.Services.AddSingleton<MongoDbContext>(sp => new MongoDbContext(connectionString, databaseName));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
