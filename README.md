# Payment Orchestrator Lite – Backend API (ASP.NET Core 9)

## 📌 Overview

**Payment Orchestrator Lite** is a simplified **Buy Now Pay Later (BNPL)** demonstration application.  
It showcases clean backend architecture, authentication, paginated data retrieval, and structured logging, packaged with Docker support for easy deployment.

Pairs with the Angular Frontend: *(Replace with your repo link once pushed)*  
> 🔗 **Frontend UI:** https://github.com/USERNAME/PaymentOrchestratorLite.Web

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
