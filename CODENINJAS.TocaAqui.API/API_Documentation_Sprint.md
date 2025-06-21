# Documentación de Web Services - API TocaAqui

## Introducción

En este Sprint se ha logrado implementar y documentar completamente la API REST de TocaAqui utilizando OpenAPI/Swagger. La API incluye endpoints para la gestión de eventos musicales, usuarios/autenticación, aplicaciones a eventos, invitaciones y pagos. Todos los endpoints están documentados con anotaciones Swagger y están disponibles tanto en desarrollo como en producción.

**Logros alcanzados:**
- ✅ 25+ endpoints completamente documentados con OpenAPI
- ✅ Swagger UI habilitado en producción
- ✅ Arquitectura DDD implementada
- ✅ Autenticación JWT implementada
- ✅ CORS configurado para frontend
- ✅ Módulos de Events, IAM y Payments completamente funcionables

## URL del Repositorio y Commits

- **Repositorio:** `CODENINJAS.TocaAqui.API`
- **Branch:** `feature/payments`
- **Commits relacionados con documentación:**
  - Implementación de Swagger y documentación OpenAPI
  - Habilitación de Swagger en producción
  - Configuración de anotaciones SwaggerOperation

## Tabla de Endpoints Documentados

| Módulo | Endpoint | Verbo HTTP | Descripción | Parámetros | Autenticación |
|--------|----------|------------|-------------|------------|---------------|
| **IAM** | `/api/v1/users/sign-up` | POST | Registro de usuario | Body: RegisterUserResource | No |
| **IAM** | `/api/v1/users/sign-in` | POST | Inicio de sesión | Body: LoginUserResource | No |
| **IAM** | `/api/v1/users` | GET | Obtener todos los usuarios | - | Sí |
| **IAM** | `/api/v1/users/{id}` | GET | Obtener usuario por ID | Path: id (int) | Sí |
| **Events** | `/api/v1/events` | GET | Obtener todos los eventos | - | No |
| **Events** | `/api/v1/events/{id}` | GET | Obtener evento por ID | Path: id (int) | No |
| **Events** | `/api/v1/events/promoter/{promoterId}` | GET | Eventos por promotor | Path: promoterId (int) | No |
| **Events** | `/api/v1/events` | POST | Crear evento | Body: CreateEventResource | No |
| **Events** | `/api/v1/events/{id}` | DELETE | Eliminar evento | Path: id (int) | No |
| **Event Applicants** | `/api/v1/eventapplicants` | POST | Aplicar a evento | Body: CreateEventApplicantResource | No |
| **Event Applicants** | `/api/v1/eventapplicants/{id}` | GET | Obtener aplicación por ID | Path: id (int) | No |
| **Event Applicants** | `/api/v1/eventapplicants/event/{eventId}` | GET | Aplicaciones por evento | Path: eventId (int) | No |
| **Event Applicants** | `/api/v1/eventapplicants/user/{userId}` | GET | Aplicaciones por usuario | Path: userId (int) | No |
| **Event Applicants** | `/api/v1/eventapplicants/event/{eventId}/user/{userId}` | GET | Aplicación específica | Path: eventId, userId (int) | No |
| **Event Applicants** | `/api/v1/eventapplicants/{id}/status` | PATCH | Actualizar estado aplicación | Path: id (int), Body: UpdateEventApplicantStatusResource | No |
| **Event Applicants** | `/api/v1/eventapplicants/{id}` | DELETE | Eliminar aplicación | Path: id (int) | No |
| **Invitations** | `/api/v1/invitations` | POST | Crear invitación | Body: CreateInvitationResource | No |
| **Invitations** | `/api/v1/invitations/{id}` | GET | Obtener invitación por ID | Path: id (int) | No |
| **Invitations** | `/api/v1/invitations/event/{eventId}` | GET | Invitaciones por evento | Path: eventId (int) | No |
| **Invitations** | `/api/v1/invitations/artist/{artistId}` | GET | Invitaciones por artista | Path: artistId (int) | No |
| **Invitations** | `/api/v1/invitations/promoter/{promoterId}` | GET | Invitaciones por promotor | Path: promoterId (int) | No |
| **Invitations** | `/api/v1/invitations/{id}/respond` | PATCH | Responder invitación | Path: id (int), Body: UpdateEventApplicantStatusResource | No |
| **Invitations** | `/api/v1/invitations/{id}` | DELETE | Eliminar invitación | Path: id (int) | No |
| **Payments** | `/api/v1/payments` | POST | Crear pago | Body: CreatePaymentResource | No |
| **Payments** | `/api/v1/payments/{id}` | GET | Obtener pago por ID | Path: id (int) | No |
| **Payments** | `/api/v1/payments` | GET | Obtener todos los pagos | - | No |
| **Payments** | `/api/v1/payments/user/{userId}` | GET | Pagos por usuario | Path: userId (int), Query: userRole | No |
| **Payments** | `/api/v1/payments/{id}/status` | PATCH | Actualizar estado pago | Path: id (int), Body: UpdatePaymentStatusResource | No |

## Detalles de Endpoints por Módulo

### 1. Módulo IAM (Identity and Access Management)

#### POST `/api/v1/users/sign-up`
**Descripción:** Registro de nuevo usuario en la plataforma

**Request Body:**
```json
{
  "name": "Juan Pérez",
  "email": "juan@ejemplo.com",
  "password": "password123",
  "role": "musico",
  "genre": "rock",
  "type": "banda",
  "description": "Banda de rock alternativo",
  "imageUrl": "https://ejemplo.com/imagen.jpg"
}
```

**Response (200):**
```json
{
  "message": "User created successfully"
}
```

#### POST `/api/v1/users/sign-in`
**Descripción:** Inicio de sesión de usuario

**Request Body:**
```json
{
  "email": "juan@ejemplo.com",
  "password": "password123"
}
```

**Response (200):**
```json
{
  "user": {
    "id": 1,
    "email": "juan@ejemplo.com",
    "name": "Juan Pérez",
    "role": "musico",
    "genre": "rock",
    "type": "banda",
    "description": "Banda de rock alternativo",
    "imageUrl": "https://ejemplo.com/imagen.jpg"
  },
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### 2. Módulo Events

#### GET `/api/v1/events`
**Descripción:** Obtiene todos los eventos disponibles

**Response (200):**
```json
[
  {
    "id": 1,
    "promoterId": 2,
    "name": "Concierto de Rock",
    "date": "2024-12-15T20:00:00Z",
    "time": "20:00",
    "location": "Teatro Nacional",
    "status": "published",
    "capacity": 500,
    "payment": 1500.00,
    "genre": "rock",
    "description": "Gran concierto de rock"
  }
]
```

#### POST `/api/v1/events`
**Descripción:** Crea un nuevo evento

**Request Body:**
```json
{
  "promoterId": 2,
  "name": "Concierto Jazz",
  "date": "2024-12-20T19:00:00Z",
  "time": "19:00",
  "publishDate": "2024-11-15T10:00:00Z",
  "location": "Club de Jazz",
  "imageUrl": "https://ejemplo.com/jazz.jpg",
  "status": "draft",
  "capacity": 200,
  "adminName": "Carlos Admin",
  "adminContact": "carlos@ejemplo.com",
  "requirements": "Instrumentos propios",
  "description": "Noche de jazz íntimo",
  "payment": 800.00,
  "duration": 120,
  "genre": "jazz",
  "equipment": "Sistema de sonido incluido"
}
```

### 3. Módulo Payments

#### POST `/api/v1/payments`
**Descripción:** Crea un nuevo pago

**Request Body:**
```json
{
  "eventId": 1,
  "musicianId": 3,
  "promoterId": 2,
  "amount": 1500.00,
  "paymentMethod": "bank_transfer",
  "bankAccountNumber": "1234567890",
  "bankName": "Banco de Crédito",
  "accountType": "savings",
  "description": "Pago por presentación en evento"
}
```

**Response (201):**
```json
{
  "id": 1,
  "eventId": 1,
  "musicianId": 3,
  "promoterId": 2,
  "amount": 1500.00,
  "currency": "PEN",
  "status": "Pending",
  "paymentMethod": "BankTransfer",
  "description": "Pago por presentación en evento",
  "createdAt": "2024-11-15T10:30:00Z",
  "updatedAt": "2024-11-15T10:30:00Z"
}
```

#### PATCH `/api/v1/payments/{id}/status`
**Descripción:** Actualiza el estado de un pago

**Request Body:**
```json
{
  "status": "Completed",
  "comment": "Pago procesado exitosamente"
}
```

## Códigos de Respuesta HTTP

| Código | Descripción |
|--------|-------------|
| 200 | OK - Operación exitosa |
| 201 | Created - Recurso creado exitosamente |
| 400 | Bad Request - Error en los datos enviados |
| 401 | Unauthorized - No autorizado |
| 404 | Not Found - Recurso no encontrado |
| 500 | Internal Server Error - Error interno del servidor |

## Configuración de Swagger

La documentación Swagger está disponible en:
- **Desarrollo:** `https://localhost:7000/`
- **Producción:** `[URL_PRODUCCION]/`

### Configuración en Program.cs
```csharp
// Swagger habilitado también en producción
app.UseSwagger();
app.UseSwaggerUI(ui =>
{
    ui.SwaggerEndpoint("/swagger/v1/swagger.json", "CODENINJAS.TocaAqui.API v1");
    ui.RoutePrefix = string.Empty;
});
```

## Autenticación JWT

Los endpoints marcados con "Sí" en autenticación requieren el header:
```
Authorization: Bearer [JWT_TOKEN]
```

El token se obtiene mediante el endpoint `/api/v1/users/sign-in`.

## Notas Técnicas

1. **CORS:** Configurado para permitir cualquier origen durante desarrollo
2. **Base de datos:** MySQL con Entity Framework Core
3. **Arquitectura:** Domain-Driven Design (DDD)
4. **Convenciones:** Rutas en kebab-case y minúsculas
5. **Logging:** Habilitado para development con información detallada

## Próximos Pasos

- Implementar más validaciones en los endpoints
- Agregar paginación a las consultas que retornan listas
- Implementar rate limiting
- Agregar más tests de integración
- Documentar esquemas de respuesta de error 