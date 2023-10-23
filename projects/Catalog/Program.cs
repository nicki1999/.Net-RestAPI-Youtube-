using Catalog.Repositories;
using Catalog.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


// Add services to the container.
//Register dependency

//Whenever there is GUID serialize it into string
BsonSerializer.RegisterSerializer(new GuidSerializer(representation: BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(representation: BsonType.String));

builder.Services.AddSingleton<IMongoClient>(ServiceProvider => {
    var settings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
    return new MongoClient(settings?.ConnectionString);
});
builder.Services.AddSingleton<IItemsRepository, MongoDbItemsRepository>();
builder.Services.AddControllers(Options => {
    Options.SuppressAsyncSuffixInActionNames = false;
});
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

app.UseAuthorization();

app.MapControllers();

app.Run();
