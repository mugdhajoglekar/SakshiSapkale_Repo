using calculateFunction;

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
app.MapPost("/calculate", (Calculator calculator) =>
{
    switch (calculator.calculatorOperation)
    {
        case "+":
            return Results.Json(CalculatFunc.Adition(calculator.Number1, calculator.Number2));
        case "-":
            return Results.Json(CalculatFunc.Subtraction(calculator.Number1, calculator.Number2));
        case "*":
            return Results.Json(CalculatFunc.Multiplication(calculator.Number1, calculator.Number2));
        case "/":
            return Results.Json(CalculatFunc.Division(calculator.Number1, calculator.Number2));
    }
    return Results.Json("NOt supported");
});

app.Run();

public class Calculator
{
    public int Number1 { get; set; }

    public int Number2 { get; set; }

    public string? calculatorOperation { get; set; }

}


