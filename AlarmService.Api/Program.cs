
using AlarmService.Core;
using AlarmService.Infrastructure;
using AlarmService.Core.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AlarmEvaluator>();
builder.Services.AddScoped<AlarmRepository>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Alarm Service is running");
app.MapGet("/status", () => "Service is healthy");
app.MapPost("/evaluate", (AlarmInput input, AlarmEvaluator evaluator, AlarmRepository repository) =>
{
    evaluator.AlarmId = input.AlarmId;
    evaluator.Operator = input.Operator switch
    {
        "GreaterThan" => "GT",
        "LessThan" => "LT",
        _ => string.Empty
    };

    var result = evaluator.Evaluate(input.Value, input.Threshold);
    repository.SaveResult(evaluator.AlarmId, result);

    return Results.Ok(new { Status = result ? "Raised" : "Normal" });
});
app.Run();
