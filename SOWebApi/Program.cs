using SOWebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCorsServices();

#region FSA CoreServer

//builder.Services.AddFSACoreServerServices(builder.Configuration);
//builder.Services.AddFSASwaggerDocumentationServices("FSA ServiceOrders Test Api", "v1");
//builder.Services.AddFSAServiceOrderDbContext<AppDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
//});
//builder.Services.AddFSAServiceOrderFeaturesServices();

//builder.Services.AddScoped<ManagementDatabaseSeeder>();

#endregion

builder.Services.AddAntiforgery();
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("WebApiSOCors");

#region FSA CoreServer
//Run pending migrations.
//await app.Services.InitialiseDatabaseAsync<AppDbContext>();
////await app.Services.SeedDataBaseBasicInfo();
//app.UseFSACoreServerServices();
//app.MapFSAServiceOrderRoutes();

app.UseAntiforgery();

#endregion

app.Run();
