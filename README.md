# 🎬 Kdrama Tracker

Personal tracker to manage your Korean drama watchlist — with status, ratings, reviews, and notes.

Built with **.NET 8 (ASP.NET Core)** + **Angular 17**.

---

## ✨ Features

- 📋 Track dramas by status: **Por ver / Viendo / Terminado**
- ⭐ Rate and review dramas you've finished
- 🔍 Search and filter by genre or status
- 💬 Add personal notes for each drama
- 📊 Stats dashboard (total, in progress, average rating)

---

## 🚀 Getting Started

### Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli): `npm install -g @angular/cli`

---

### Backend (.NET API)

```bash
cd backend/KdramaTracker
dotnet run
```

API runs at `http://localhost:5000`  
Swagger docs at `http://localhost:5000/swagger`

---

### Frontend (Angular)

```bash
cd frontend
npm install
ng serve
```

App runs at `http://localhost:4200`

---

## 📁 Project Structure

```
kdrama-tracker/
├── backend/
│   └── KdramaTracker/
│       ├── Controllers/    # DramasController (REST API)
│       ├── Models/         # Drama entity
│       ├── Data/           # AppDbContext (SQLite)
│       └── Program.cs
└── frontend/
    └── src/app/
        ├── models/         # TypeScript interfaces
        ├── services/       # DramaService (HTTP calls)
        └── app.component   # Main component
```

## 🛠️ API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/dramas` | Get all dramas (with filters) |
| GET | `/api/dramas/:id` | Get drama by id |
| POST | `/api/dramas` | Create drama |
| PUT | `/api/dramas/:id` | Update drama |
| DELETE | `/api/dramas/:id` | Delete drama |
| GET | `/api/dramas/genres` | Get all genres |
| GET | `/api/dramas/stats` | Get stats |

### Filter examples
```
GET /api/dramas?status=Viendo
GET /api/dramas?genre=Romance&status=Terminado
GET /api/dramas?search=goblin
```

---

## 👩‍💻 Author

**Sandra Marcela Garcia Grisales**  
Technical Leader | .NET & Angular Developer  
[LinkedIn](https://linkedin.com/in/smgarciagr)
