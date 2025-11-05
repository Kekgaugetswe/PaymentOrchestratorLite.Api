# Payment Orchestrator Lite – Backend API (ASP.NET Core 9)

## 📌 Overview

**Payment Orchestrator Lite** is a simplified **Buy Now Pay Later (BNPL)** demonstration application.  
It showcases clean backend architecture, authentication, paginated data retrieval, and structured logging, packaged with Docker support for easy deployment.

Pairs with the Angular Frontend: *(Replace with your repo link once pushed)*  
> 🔗 **Frontend UI:** https://github.com/kekgaugetswe/PaymentOrchestratorWeb

---

## ✨ Features

- ✅ JWT Authentication with ASP.NET Core Identity
- ✅ Create Payment requests
- ✅ Paginated & searchable payment list
- ✅ Confirm payment status (Pending → Confirmed)
- ✅ SQLite database (file-based, zero external setup)
- ✅ Serilog logging to console + rolling log files
- ✅ Fully Dockerized (with persistent DB + logs)

---

## 🧱 Tech Stack

- **ASP.NET Core 9 Web API**
- **Entity Framework Core (SQLite)**
- **Serilog Logging**
- **JWT Authentication**
- **Docker**
- **Angular (Frontend UI)**

---

## 💾 Database

This API uses **SQLite**, stored in a local file `app.db`.

- No SQL Server setup required
- Easy to ship with the project
- Persists locally when mapped using Docker volumes

---

## 📝 Logging

Serilog writes logs to:

- **Console output** (visible via `docker logs <container>`)
- **Rolling log files** stored inside the container: `/app/logs/app-*.log`

To persist logs on your machine:

```bash
-v $(pwd)/logs:/app/logs
```
---
## 🐳 Running the API via Docker

### 1️⃣ Build the Docker Image

```bash
docker build -t payment-api -f PaymentOrchestratorLite.Api/Dockerfile .

```
### 2️⃣ Run the Container (with Persistent Database + Logs)

```bash
docker run \
  -p 7297:8080 \
  -v $(pwd)/app.db:/app/app.db \
  -v $(pwd)/logs:/app/logs \
  payment-api

```
### ✅ What this does

| Flag | Meaning |
|------|---------|
| `-p 7297:8080` | Exposes the API at **http://localhost:7297** |
| `-v $(pwd)/app.db:/app/app.db` | Keeps your **SQLite database persistent** outside the container |
| `-v $(pwd)/logs:/app/logs` | Stores **Serilog log files** on your machine (not lost when container stops) |