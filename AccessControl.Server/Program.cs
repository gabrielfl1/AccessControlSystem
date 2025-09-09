using AccessControl.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options => {
        options.SuppressModelStateInvalidFilter = true;
    })
    .AddJsonOptions(x => {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; 
        //x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault; << voltar isso se eu quiser que não apareçam os campos null nos GETs
    });

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AccessControlSystemDataContext>(options => {
    options.UseSqlite(connectionString);
});


var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
