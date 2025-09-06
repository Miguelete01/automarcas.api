# automarcas
Proyecto implementando TDD, Clean Architecture, Docker
# 📌 API .NET 8 + PostgreSQL + Docker Compose

Este proyecto es una **API desarrollada en .NET 8** que utiliza **PostgreSQL** como base de datos y está contenida mediante **Docker Compose** para facilitar la orquestación y despliegue.

---

## 🚀 Tecnologías utilizadas
- [.NET 8](https://dotnet.microsoft.com/)
- [PostgreSQL](https://www.postgresql.org/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

## 🚀 Tecnologías utilizadas
- [.NET 8](https://dotnet.microsoft.com/)  
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)  
- [PostgreSQL](https://www.postgresql.org/)  
- [Docker & Docker Compose](https://docs.docker.com/compose/)  
- [xUnit](https://xunit.net/) para pruebas unitarias
  
## 📂 Estructura del proyecto
┣ 📂 Entities # Entidades del dominio
┣ 📂 Dtos # Objetos de transferencia de datos
┣ 📂 Data # DbContext y configuración de EF Core
┣ 📂 Migrations # Migraciones de base de datos
┣ 📂 Repositories # Repositorios con lógica de acceso a datos
┣ 📂 Services # Servicios con la lógica de negocio
┣ 📂 Seeder # Datos iniciales (seeders)
┣ 📂 Tests # Proyecto de pruebas unitarias (xUnit)
┣ 📜 docker-compose.yml
┣ 📜 README.md

## ⚙️ Requisitos previos
- [Docker](https://docs.docker.com/get-docker/)  
- [Docker Compose](https://docs.docker.com/compose/)  
- (Opcional) [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) para correr sin contenedores.  

---## ▶️ Ejecución del proyecto

**Clonar el repositorio**
---## Levantar servicios con Docker Compose
      docker-compose build
      docker-compose up


http://localhost:5000/swagger/index.html