# Alarm Service

This is a modular, event-driven .NET 7 microservice designed to evaluate alarms, persist results, and publish events. It supports containerized deployment via Docker and includes Redis for pub/sub capabilities.

## 📦 Project Structure

```
AlarmService.Api/             # Web API project
AlarmService.Core/            # Domain models and business logic
AlarmService.Infrastructure/  # Persistence and event publishing via Redis
AlarmService.Tests/           # Unit tests for core logic
```

## 🚀 Features

- Evaluate alarms using business logic
- Persist alarm status in Redis
- Publish alarm events over Redis pub/sub
- Swagger UI for API testing
- Dockerized service with `docker-compose`
- Supports external simulation and subscriptions
- Unit tests with command-line execution

---

## 🔧 Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/)
- [Redis](https://hub.docker.com/_/redis) (included in `docker-compose`)
- PowerShell or terminal for CLI execution

---

## 🐳 Running with Docker

Build and run the API and Redis:

```bash
docker-compose up --build
```

Then access:
- Swagger UI: [http://localhost:5050/swagger](http://localhost:5050/swagger)
- Health Check: `GET http://localhost:5050/status`

---

## 📬 API Endpoints

### `POST /evaluate`

Evaluates an alarm based on threshold comparison.

#### Request Payload

```json
{
  "alarmId": "sensor-101",
  "operator": "GreaterThan",
  "value": 75,
  "threshold": 70
}
```

#### Response

```json
{
  "status": "Raised"
}
```

---

## 🔁 Event Publishing

Each alarm result is published as:
- Internal event via `AlarmRaisedEvent`
- Redis channel: `alarms`, message format:  
  `Alarm:<AlarmId> Status:<Raised|Normal>`

You can subscribe using any Redis client:

```bash
redis-cli SUBSCRIBE alarms
```

---

## 🧪 Running Unit Tests

Tests are located in the `AlarmService.Tests` project:

```bash
dotnet test AlarmService.Tests
```

---

## 🧠 Simulating Real Events (Optional)

You can simulate real-world behavior using a separate CLI or script:

```bash
curl -X POST http://localhost:5050/evaluate \
-H "Content-Type: application/json" \
-d '{"alarmId": "sensor-55", "operator": "GreaterThan", "value": 90, "threshold": 85}'
```

This will trigger event publication and persistence in Redis.

---

## 🛠️ Configuration

Modify `Program.cs` to change Redis host:

```csharp
ConnectionMultiplexer.Connect("localhost"); // or use environment variables
```

---

## 📄 License

MIT License. Feel free to fork and extend.