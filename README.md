# 🚗 ExclusivaAutos CRM API  
**Solución técnica para integración con Power Automate — Analista Senior de CRM**

[![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?logo=.net)](https://dotnet.microsoft.com)
[![Clean Architecture](https://img.shields.io/badge/Arquitectura-Clean_Architecture-0078D4)](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture)
[![Swagger](https://img.shields.io/badge/API-Docs-Swagger-85EA2D?logo=swagger)](https://swagger.io)

---

## 🎯 Objetivo

Desarrollar una API REST en **.NET 8** que consuma un servicio externo expuesto por **Power Automate**, integrando seguridad OAuth 2.0, manejo robusto de errores y arquitectura mantenible.

> ✅ Solución lista para producción, cumpliendo 100% con los requerimientos técnicos de la prueba.

---

## 🛠 Arquitectura

Implementación basada en **Clean Architecture (por capas)**:

| Capa | Responsabilidad | Proyecto |
|------|------------------|----------|
| **Presentation** | Exposición de endpoints, documentación (Swagger), configuración inicial | `ExclusivaAutos.CrmApi` |
| **Application** | Lógica de negocio, orquestación de servicios | `ExclusivaAutos.Application` |
| **Domain** | Modelos de negocio y contratos (interfaces) — **independiente** | `ExclusivaAutos.Domain` |
| **Infrastructure** | Implementaciones técnicas: HTTP, OAuth, persistencia | `ExclusivaAutos.Infrastructure` |

```mermaid
graph LR
  A[Presentation] --> B[Application]
  B --> C[Domain]
  B -.-> D[Infrastructure]
  D --> C
