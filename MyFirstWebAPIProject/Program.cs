var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//indica este es  el último Middleware a ejecutar. El resto de códigio lo obviará
// app.Run(async context =>
// {
//     await context.Response.WriteAsync("Response from First Run Middleware");
// });

//en NET.5 app.Run estád dando un error "No se puede convertir expresión lambda en el tipo 'string' porque no es un tipo delegado"
// app.Run(async (context, next) =>
//     {
//         await context.Response.WriteAsync("Getting Response from 1st Middleware \n");
//     });
// app.Run(async context =>
//     {
//         await context.Response.WriteAsync("Response Response from second Middleware \n");
//     });



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
