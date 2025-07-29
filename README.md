## 🔖 Badges

![.NET CI](https://github.com/<your-username>/dotnet-alarm-service/actions/workflows/dotnet.yml/badge.svg)
![Docker](https://img.shields.io/badge/docker-ready-blue)
![License](https://img.shields.io/github/license/<your-username>/dotnet-alarm-service)

# Alarm Service (.NET)

This is a microservice-based Alarm Service implemented in .NET 7 with Docker support.

## Projects
- **AlarmService.Api**: ASP.NET Core Web API
- **AlarmService.Core**: Evaluation logic for alarms
- **AlarmService.Infrastructure**: In-memory + Redis storage
- **AlarmService.Tests**: xUnit tests

## Getting Started

### Prerequisites
- Docker
- .NET 7 SDK

### Run with Docker
```bash
docker-compose up --build
```

### Test
```bash
dotnet test AlarmService.Tests
```

## Redis Usage
Redis is used for temporary alarm state caching.
## Swagger API Documentation

To enable Swagger UI for API exploration:

1. Add the following to `Program.cs` in `AlarmService.Api`:
```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
```

2. Then run the API and open [http://localhost:8080/swagger](http://localhost:8080/swagger) in your browser.
---

## ☁️ Azure DevOps: Build & Push to ACR

Make sure you have an Azure DevOps pipeline and service connection named `MyACRServiceConnection`.

Then commit the `azure-pipelines.yml` file and configure CI/CD in your Azure DevOps project.

```yaml
# Trigger pipeline with every push to main
trigger:
  branches:
    include:
      - main
```

---

## 📊 Monitoring with Prometheus & Grafana

### Prometheus
Use the provided `monitoring/prometheus.yml` in your Prometheus config directory. It scrapes metrics from:

```
http://alarmservice:80
```

Ensure the application exposes metrics (e.g., with Prometheus .NET exporter).

### Grafana
Use the dashboard JSON in `monitoring/grafana_dashboard.json`:

1. Open Grafana
2. Go to Dashboards → Import
3. Paste the JSON content or upload the file

You'll see request rate metrics in a time-series panel.

---