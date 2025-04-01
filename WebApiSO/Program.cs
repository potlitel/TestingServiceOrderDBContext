using FSA.Core.Data.Extensions;
using FSA.Core.Server.Extensions;
using WebApiSO.Data;
using WebApiSO.Extension;

var builder = WebApplication.CreateBuilder(args);

#region NotWorkging
// Add services to the container.
//builder.Services.ConfigureApi(builder.Configuration);

//var app = builder.Build();

//app.UseSwagger();
//app.UseSwaggerUI();

//app.UseHttpsRedirection();
//app.UseCors("WebApiSOCors");

//#region FSA CoreServer
////Run pending migrations.
//await app.Services.InitialiseDatabaseAsync<AppDbContext>();
////await app.Services.SeedDataBaseBasicInfo();
////app.MapControllers(); //Registramos endpoints implementados en este proyecto no en FSACoreServer.
//app.UseFSACoreServerServices();
//app.MapFSAServiceOrderRoutes();

//app.UseAntiforgery();

//#endregion

//app.Run();
#endregion

//Refactorizando!!
//builder.Services.AddControllers();
//builder.Services.AddCorsServices();
builder.Services.ConfigureApi(builder.Configuration);

//#region FSA CoreServer

//builder.Services.AddFSACoreServerServices(builder.Configuration);
//builder.Services.AddFSASwaggerDocumentationServices("FSA ServiceOrders Test Api", "v1");
//builder.Services.AddFSAServiceOrderDbContext<AppDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
//});
//builder.Services.AddFSAServiceOrderFeaturesServices();

//builder.Services.AddScoped<ManagementDatabaseSeeder>();

//#endregion

//builder.Services.AddAntiforgery();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.ConfigureServiceOrdersWebApp();
//app.UseSwagger();
//app.UseSwaggerUI();

//#region FSA CoreServer
////Run pending migrations.
//await app.Services.InitialiseDatabaseAsync<AppDbContext>();
//await app.Services.SeedDataBaseBasicInfo();
//app.UseFSACoreServerServices();
//app.MapControllers();//Register Local endpoints
//app.MapFSAServiceOrderRoutes();

//app.UseAntiforgery();
//app.UseHttpsRedirection();
//app.UseCors("WebApiCors");

//#endregion

app.Run();
