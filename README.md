# UserManagement API

A clean and testable ASP.NET Core Web API for managing users, built with layered architecture and secured with JWT authentication.

## 🚀 Features

- ✅ User registration with hashed & salted passwords
- ✅ Secure login with JWT token generation
- ✅ JWT token returned on both registration and login
- ✅ Get all users (protected)
- ✅ Delete user by username (protected)
- ✅ Clean architecture: Core / Infrastructure / Web API separation
- ✅ PostgreSQL database integration
- ✅ Result pattern for consistent and testable outcomes

---

## 🧱 Tech Stack

- **ASP.NET Core 8 Web API**
- **Entity Framework Core**
- **PostgreSQL**
- **JWT Authentication**
- **Clean Architecture (Core, Infrastructure, Web layers)**

---

## 📁 Project Structure

```
UserManagement/
│
├── UserManagement.WebApi/         → ASP.NET Core API (controllers, Program.cs)
├── UserManagement.Core/           → Business logic, Result pattern, interfaces
├── UserManagement.Infrastructure/ → EF Core DbContext, repositories, UoW
```

---

## 🛠️ Setup Instructions

### 1. Clone the repo
```bash
git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name
```

### 2. Create PostgreSQL database

Create a PostgreSQL database named `user-management` (or edit it in `appsettings.json`).

### 3. Set up connection string

In `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=user-management;Username=postgres;Password=yourpassword"
}
```

### 4. Run migrations (if needed)
```bash
dotnet ef database update -p UserExercise.Infrastructure -s UserExercise.WebApi
```

### 5. Run the API
```bash
dotnet run --project UserExercise.WebApi
```

---

## 🔐 Authentication & Roles

This API uses **JWT Bearer Tokens** for authentication and role-based access.

- You receive a JWT token upon **registration** and **login**
- The token includes a **role claim** (`User` or `Admin`)
- Certain endpoints (like delete) require `Admin` role
  
```http
Authorization: Bearer your.jwt.token
```

---

## 🧪 Example HTTP Requests

> All endpoints assume the server is running at: `https://localhost:7254`

---

### 📌 Register a new user

```http
POST https://localhost:7254/api/v1/users/register
Content-Type: application/json

{
  "username": "johndoe",
  "password": "YourSecurePassword123"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

---

### 🔐 Login to receive JWT

```http
POST https://localhost:7254/api/v1/users/login
Content-Type: application/json

{
  "username": "johndoe",
  "password": "YourSecurePassword123"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

---

### 👤 Get all users (any authenticated user)

```http
GET https://localhost:7254/api/v1/users
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
Accept: application/json
```

---

### 🗑️ Delete a user by username (admin only)

```http
DELETE https://localhost:7254/api/v1/users/johndoe
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

---
## 📄 License

This project is proprietary and all rights are reserved.  
You are free to view the code, but copying or redistributing it is prohibited without permission.

---
