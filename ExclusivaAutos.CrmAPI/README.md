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

## 🎥 2. Guión para Grabación de Pantalla (5–7 minutos)

Este guion está diseñado para que **expliques con claridad, confianza y profesionalismo**, como un Senior.

> 🎯 Objetivo del video: demostrar que **entiendes el problema, la arquitectura, la seguridad y la calidad**.

---

### 🎬 Inicio (0:00–0:45)  
**Pantalla**: Visual Studio — solución abierta  
**Dice**:  
> “Hola, soy Jhon Oliveros, y en esta prueba técnica voy a desarrollar una API en .NET 8 que consuma un servicio de Power Automate, tal como lo solicita *Exclusiva de Autos SAS*.  
>  
> Lo primero que hice fue estructurar el proyecto con **Clean Architecture**, separando claramente las responsabilidades: presentación, lógica de negocio, dominio e infraestructura.  
> Esto garantiza mantenibilidad, testabilidad y escalabilidad — clave en entornos empresariales.”

---

### 🏗 Arquitectura (0:45–2:00)  
**Pantalla**: Explorador de soluciones → muestra los 4 proyectos  
**Dice**:  
> “Aquí vemos las cuatro capas:
> - `Domain`: contiene los modelos — como `Customer` y `CustomerRequest` — y los contratos, como `IExternalCustomerClient`. Es completamente independiente: **sin dependencias externas**.
> - `Application`: orquesta la lógica de negocio. Por ejemplo, `CustomerService` recibe un ID, valida y delega la llamada al cliente externo.
> - `Infrastructure`: implementa los detalles técnicos: el `HttpClient`, la obtención del token OAuth, el manejo de JSON.
> - `CrmApi`: la capa de presentación — controladores, Swagger, configuración de inyección de dependencias.
>
> Esta separación permite cambiar la infraestructura — por ejemplo, migrar de Power Automate a una API REST directa — sin tocar la lógica de negocio.”

---

### 🔐 Seguridad y OAuth (2:00–3:15)  
**Pantalla**: `OAuthSettings.cs` + `ExternalCustomerClient.cs` → método `GetAccessTokenAsync`  
**Dice**:  
> “Respecto a la seguridad: el endpoint requiere OAuth 2.0.  
> Aquí definí una clase `OAuthSettings` para inyectar `ClientId`, `ClientSecret` y `TenantId` desde la configuración — **nunca están hardcodeados**.  
>
> En `ExternalCustomerClient`, obtengo el token llamando al endpoint estándar de Azure AD, y lo incluyo en el header `Authorization: Bearer`.  
>  
> En producción, estos valores se cargarían desde **Azure Key Vault** o **User Secrets**, y la comunicación sería 100% sobre HTTPS — cumpliendo con el requisito de autenticación encriptada.”

---

### 📡 Consumo del Servicio (3:15–4:00)  
**Pantalla**: `ExternalCustomerClient.cs` → método `GetCustomerAsync`  
**Dice**:  
> “El flujo es así:
> 1. Obtengo el token OAuth.
> 2. Armo el payload con `{ 'CustomerId': id }`.
> 3. Hago un `POST` al endpoint de Power Automate.
> 4. Si la respuesta es exitosa, deserializo el JSON en un objeto `Customer`.
>  
> Además, hay manejo robusto de errores: timeouts (30 segundos), fallos HTTP y excepciones — todo sin romper la API.”

---

### 🧪 Pruebas Unitarias (4:00–4:45)  
**Pantalla**: `CustomerServiceTests.cs` + ejecución de pruebas (Test Explorer)  
**Dice**:  
> “Para asegurar calidad, implementé pruebas unitarias con xUnit y Moq.  
> Por ejemplo:  
> - Si el ID es válido, debe retornar un cliente.  
> - Si es nulo o vacío, retorna `null`.  
> - Si falla el cliente externo, no se lanza excepción no controlada.  
>  
> Esto garantiza que la lógica de negocio se comporta como se espera — clave para deployments confiables.”

---

### 🌐 Swagger y Demo (4:45–5:30)  
**Pantalla**: Ejecutar → abrir `https://localhost:5001/swagger` → probar `/api/customer/123456789`  
**Dice**:  
> “Finalmente, documenté la API con Swagger — accesible en `/swagger`.  
> Aquí puedo probar el endpoint `GET /api/customer/{id}`.  
>  
> Como el endpoint de Power Automate es ficticio (propósito de la prueba), actualmente devuelve `null`, pero el código está listo para funcionar con un entorno real.  
>  
> Para demostración, podría incluir un mock — pero preferí mantener la implementación real, como se espera en un entorno senior.”

---

### ✅ Cierre (5:30–6:00)  
**Pantalla**: Vista del repositorio en GitHub (si ya subiste) o del `README.md`  
**Dice**:  
> “En resumen:  
> ✔️ Arquitectura limpia y mantenible  
> ✔️ Seguridad OAuth 2.0 sin datos sensibles en código  
> ✔️ Manejo de errores y timeouts  
> ✔️ Pruebas unitarias y documentación interactiva  
>  
> Todo listo para integrarse en producción.  
> Gracias por su tiempo.”

---

## 🎁 Bonus: Tips para la Grabación

- Usa fondo limpio y buena iluminación.
- Habla con calma, como explicando a un colega.
- No digas “no sé” — si algo falla, di: *“En un entorno real, esto se resolvería con X…”*
- Mantén el código limpio (elimina comentarios innecesarios antes de grabar).

---