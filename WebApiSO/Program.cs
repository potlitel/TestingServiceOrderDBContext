using WebApiSO.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApi(builder.Configuration);

var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("WebApiSOCors");

app.UseAuthorization();

app.MapControllers();
app.UseResponseCaching();
app.Run();
