<div align="center">
<img src="https://readme-typing-svg.herokuapp.com/?font=Fira+Code&size=32&duration=3000&center=true&vCenter=true&width=600&lines=CodePulse;Full-Stack+Blogging+Platform;🔥+Production+Ready" />
  <br><br>
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/Angular-16-DD0031?style=for-the-badge&logo=angular&logoColor=white" />
  <img src="https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" />
</div>

## ✨ Features
- 🔐 **JWT Authentication** - Role-based (Admin/User)
- 📝 **Rich Text Editor** - Image upload support
- 🖼️ **Image Management** - Cloud-ready storage
- 📱 **Responsive Design** - Web-first responsive UI
- 📊 **RESTful APIs** - Swagger documented

## 📱 Screenshots
<div align="center">

![Login](screenshots/Screenshot%202025-12-08%20205018.png)
![Dashboard](screenshots/Screenshot%202025-12-08%20205038.png)
![Blog Editor](screenshots/Screenshot%202025-12-09%20135254.png)
![Swagger](screenshots/Screenshot%202025-12-09%20135314.png)

</div>


## 🛠️ Tech Stack
| Frontend | Backend | Database | Tools |
|----------|---------|----------|-------|
| Angular 16 | ASP.NET Core 8 | SQL Server | Swagger |
| TypeScript | Entity Framework | SQLite (Dev) | Postman |
| Bootstrap 5 | JWT Auth | | Git |

## 🚀 Quick Start
### 1. Clone & Backend

### 2. Frontend (New Terminal)
**Backend:** `https://localhost:7001` **Frontend:** `https://localhost:4200` **Swagger:** `https://localhost:7001/swagger`


## 🔧 Environment Setup
**Backend (.NET 8):** `"ConnectionStrings": {"Default": "Server=localhost;Database=CodePulse;Trusted_Connection=true;"}`  
**Frontend (Angular):** `apiUrl: 'https://localhost:7001/api'`

## 📖 API Documentation
- **Swagger UI:** `/swagger`
- **Auth:** `POST /api/auth/login`
- **Posts:** `GET/POST/PUT/DELETE /api/posts`
- **Images:** `POST /api/images/upload`

## 🐛 Troubleshooting
| Issue | Solution |
|-------|----------|
| `dotnet ef` fails | `dotnet tool install --global dotnet-ef` |
| CORS error | Check `Program.cs` CORS policy |
| JWT 401 | Verify `appsettings.json` JWT key |

## 🤝 Contributing
1. Fork repo
2. Create feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit (`git commit -m 'Add some AmazingFeature'`)
4. Push (`git push origin feature/AmazingFeature`)
5. Open Pull Request

<div align="center">
  <strong>Built with ❤️ by <a href="https://github.com/Kedar-Kawale">Kedar Kawale</a></strong><br>
  <a href="https://www.linkedin.com/in/kedar-kawale">
    <img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" />
  </a>
</div>
