# 🐾 CLYVO DAY API

API RESTful desenvolvida em ASP.NET Core para gerenciamento contínuo da jornada de cuidado veterinário de pets, conectando tutores, clínicas e veterinários em uma experiência digital integrada.

---

# 📌 Sobre o Projeto

O projeto foi desenvolvido como solução para o desafio da CLYVO VET, cujo objetivo é melhorar a recorrência de cuidados veterinários preventivos e terapêuticos através de uma plataforma digital inteligente.

A API permite:
- gerenciamento de pets;
- gerenciamento de tutores;
- gerenciamento de clínicas;
- gerenciamento de veterinários;
- monitoramento contínuo da saúde do pet;
- eventos de cuidado veterinário;
- acompanhamento longitudinal dos dados clínicos.

---

# 🚀 Tecnologias Utilizadas

- ASP.NET Core
- C#
- Entity Framework Core
- Oracle Database
- OpenAPI
- Scalar
- REST API
- Visual Studio 2026

---

# 🏗️ Arquitetura

O projeto segue arquitetura baseada em:
- Controllers
- Models
- DbContext
- Entity Framework Core
- Migrations

---

# 📂 Estrutura do Projeto

```bash
Controllers/
Data/
Migrations/
Models/
```

---

# 🧩 Entidades Principais

## Tutor
Representa o responsável pelo pet.

## Pet
Representa o animal monitorado pela plataforma.

## Clinic
Representa clínicas veterinárias parceiras.

## Veterinarian
Representa veterinários vinculados às clínicas.

## MonitoringPet
Representa registros contínuos de monitoramento do pet.

## CareEvent
Representa eventos clínicos e preventivos realizados.

---

# 🔗 Endpoints Principais

## Pets

| Método | Endpoint |
|---|---|
| GET | /api/pets |
| GET | /api/pets/{id} |
| POST | /api/pets |
| PUT | /api/pets/{id}/weight |
| DELETE | /api/pets/{id} |

---

## Tutors

| Método | Endpoint |
|---|---|
| GET | /api/tutors |
| GET | /api/tutors/{id} |
| POST | /api/tutors |
| PUT | /api/tutors/{id}/contact |
| DELETE | /api/tutors/{id} |

---

## Clinics

| Método | Endpoint |
|---|---|
| GET | /api/clinics |
| GET | /api/clinics/{id} |
| POST | /api/clinics |
| DELETE | /api/clinics/{id} |

---

## Veterinarians

| Método | Endpoint |
|---|---|
| GET | /api/veterinarians |
| GET | /api/veterinarians/{id} |
| GET | /api/veterinarians/clinic/{clinicId} |
| POST | /api/veterinarians |
| PUT | /api/veterinarians/{id}/contact |
| DELETE | /api/veterinarians/{id} |

---

## MonitoringPet

| Método | Endpoint |
|---|---|
| GET | /api/monitoringpets |
| GET | /api/monitoringpets/pet/{petId} |
| POST | /api/monitoringpets |

---

## CareEvent

| Método | Endpoint |
|---|---|
| GET | /api/eventocuidado |
| GET | /api/eventocuidado/{id} |
| POST | /api/eventocuidado |
| DELETE | /api/eventocuidado/{id} |

---

# 🗄️ Banco de Dados

O projeto utiliza Oracle Database integrado via Entity Framework Core.

---

# ⚙️ Como Executar

## 1. Clone o repositório

```bash
git clone https://github.com/mfernandx/clyvo-day-api.git
```

---

## 2. Configure a connection string

No arquivo:

```bash
appsettings.Development.json
```

Configure:

```json
{
  "ConnectionStrings": {
    "OracleConnection": "SUA_CONNECTION_STRING"
  }
}
```

---

## 3. Execute as migrations

```bash
Add-Migration InitialCreate
Update-Database
```

---

## 4. Execute o projeto

Pressione:

```bash
F5
```

---

# 📘 OpenAPI / Scalar

A documentação interativa fica disponível automaticamente ao executar a aplicação.

---

# 🎯 Objetivo Acadêmico

Projeto desenvolvido para a disciplina:

- Advanced Business Development with .NET

---

# 👨‍💻 Integrantes da Equipe

- Maria Fernanda Santos Mendes - 2TDSPI
- Beatriz de Sousa Franco - 2TDSPI
- Giovana Souza Vieira - 2TDSPI
