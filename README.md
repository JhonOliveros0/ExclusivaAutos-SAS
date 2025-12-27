# 🚗 ExclusivaAutos CRM API  
**Solución técnica para integración con Power Automate — Analista Senior de CRM**

[![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4?logo=.net)](https://dotnet.microsoft.com)
[![Clean Architecture](https://img.shields.io/badge/Arquitectura-Clean_Architecture-0078D4)](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture)
[![Swagger](https://img.shields.io/badge/API-Docs-Swagger-85EA2D?logo=swagger)](https://swagger.io)

---

## 🎯 Objetivo

Desarrollar una API REST en **.NET 10** que consuma un servicio externo expuesto por **Power Automate**, integrando seguridad OAuth 2.0, manejo robusto de errores y arquitectura mantenible.

> ✅ Solución lista para producción, cumpliendo 100% con los requerimientos técnicos de la prueba.

---

## 🛠 Arquitectura

Implementación basada en **Clean Architecture (por capas)**:

| Capa | Responsabilidad | Proyecto |
|------|------------------|----------|
| **Presentación/Presentation** | Exposición de endpoints, documentación (Swagger), configuración inicial | `ExclusivaAutos.CrmApi` |
| **Applicación/Application** | Lógica de negocio, orquestación de servicios | `ExclusivaAutos.Application` |
| **Dominio/Domain** | Modelos de negocio y contratos (interfaces) — **independiente** | `ExclusivaAutos.Domain` |
| **Infraestructura/Infrastructure** | Implementaciones técnicas: HTTP, OAuth, persistencia | `ExclusivaAutos.Infrastructure` |

```mermaid
graph LR
  A[Presentación/Presentacion] --> B[Applicación/Application]
  B --> C[Dominio/Domain]
  B -.-> D[Infraestructura/Infrastructure]
  D --> C
