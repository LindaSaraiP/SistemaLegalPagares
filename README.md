# Sistema Legal de Pagarés

Aplicación web para la gestión legal de pagarés, con roles de administrador y abogados, construida con .NET 8 y SQL Server.

## Características principales

- Autenticación y autorización de usuarios (abogados, administrador)
- Panel de administración para aprobar usuarios abogados
- Gestión de pagarés (creación, edición, seguimiento)
- Seed inicial con usuario administrador

## Requisitos previos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

- [Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/) o [Visual Studio Code](https://code.visualstudio.com/)
- [.NET 8 SDK](https://dotnet.microsoft.com/es-es/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) (Express o Developer)
- [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/es-es/sql/ssms/download-sql-server-management-studio-ssms)
- [Git](https://git-scm.com/)

También es recomendable instalar las herramientas de Entity Framework:

```bash
dotnet tool install --global dotnet-ef
