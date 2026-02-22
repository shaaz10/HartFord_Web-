# Hartford Insurance API — Documentation

> **Stack:** ASP.NET Core 10 · Entity Framework Core 9 · SQL Server 2022 (Docker) · JWT Bearer Auth
>
> **Base URL:** `http://localhost:5254`
>
> **Database:** `HartfordInsuranceDb` on SQL Server (Docker `hartford-sqlserver`, port `1433`)

---

## Table of Contents

1. [Quick Start](#quick-start)
2. [Authentication](#authentication)
3. [Seeded Test Accounts](#seeded-test-accounts)
4. [Authorization Policies](#authorization-policies)
5. [Data Model](#data-model)
6. [Endpoints](#endpoints)
   - [Auth](#auth-api)
   - [Users](#users-api)
   - [Customers](#customers-api)
   - [Agents](#agents-api)
   - [Policies](#policies-api)
   - [Claims](#claims-api)
   - [Insurance Requests](#insurance-requests-api)
   - [Policy Recommendations](#policy-recommendations-api)
   - [Policy Applications](#policy-applications-api)
   - [Notifications](#notifications-api)
   - [Payments](#payments-api)
7. [Error Responses](#error-responses)
8. [Running the Stack](#running-the-stack)
9. [Azure Data Studio Connection](#azure-data-studio-connection)

---

## Quick Start

```bash
# 1. Start SQL Server (Docker — one command)
docker start hartford-sqlserver

# 2. Run the API
cd Hartford.Insurance.Api
dotnet run

# 3. Run the full test suite
cd ..
bash test-api.sh
```

The app automatically applies migrations and seeds the database on startup.

---

## Authentication

All protected routes require a **Bearer JWT token** in the `Authorization` header.

```http
Authorization: Bearer <token>
```

Obtain a token via `POST /api/auth/login`.

**JWT Payload includes:**

| Claim | Value |
|---|---|
| `sub` | User ID (int, as string) |
| `email` | User email |
| `role` | `admin` / `agent` / `customer` |
| `name` | User display name |
| `exp` | Expiry (24 hours from issue) |

---

## Seeded Test Accounts

| Email | Password | Role |
|---|---|---|
| `customer@insurance.com` | `password123` | `customer` |
| `agent@insurance.com` | `password123` | `agent` |
| `admin@insurance.com` | `admin123` | `admin` |

---

## Authorization Policies

| Policy | Allowed Roles |
|---|---|
| *(no attribute / `[Authorize]`)* | Any authenticated user |
| `AdminOnly` | `admin` |
| `AgentOrAdmin` | `agent`, `admin` |
| `CustomerOnly` | `customer` |

---

## Data Model

```
User ──────────── Customer (UserId FK)
                        │
               ┌────────┴────────┐
           Policy (CustomerId)   InsuranceRequest (CustomerId)
               │                       │
           Claim (PolicyId)    PolicyRecommendation (RequestId)
               │
           Payment (PolicyId)

Agent ─── Policy (AgentId)
      └── InsuranceRequest (AgentId)
      └── PolicyApplication (AgentId)

User ──── Notification (UserId)
```

**All primary keys are auto-increment `int`.** Foreign keys follow the same `int` type.

---

## Endpoints

---

### Auth API

#### `POST /api/auth/login`
Login and receive a JWT token.

**Auth required:** ❌

**Request Body:**
```json
{
  "Email": "admin@insurance.com",
  "Password": "admin123"
}
```

**Response `200 OK`:**
```json
{
  "Token": "eyJhbGci...",
  "Id": "3",
  "Name": "Admin User",
  "Email": "admin@insurance.com",
  "Role": "admin",
  "ExpiresAt": "2026-02-23T14:53:37Z"
}
```

**Errors:** `401 Unauthorized` (bad credentials), `400 Bad Request` (missing fields)

---

#### `POST /api/auth/register`
Register a new user and receive a JWT token.

**Auth required:** ❌

**Request Body:**
```json
{
  "Name": "Jane Doe",
  "Email": "jane@example.com",
  "Password": "MyPass@123",
  "Role": "customer"
}
```

**Response `201 Created`:** Same as login response.

**Errors:** `409 Conflict` (email already exists), `400 Bad Request` (missing fields)

---

### Users API

> **Requires:** `AdminOnly` policy

#### `GET /api/users`
Returns all users.

**Response `200 OK`:**
```json
[
  { "Id": 1, "Name": "John Customer", "Email": "customer@insurance.com", "Role": "customer", "CreatedAt": "..." },
  { "Id": 2, "Name": "Jane Agent", "Email": "agent@insurance.com", "Role": "agent", "CreatedAt": "..." },
  { "Id": 3, "Name": "Admin User", "Email": "admin@insurance.com", "Role": "admin", "CreatedAt": "..." }
]
```

---

#### `GET /api/users/{id}`
Returns a single user by ID.

**Response `200 OK`** | **`404 Not Found`**

---

#### `GET /api/users/by-email?email={email}`
Lookup user by email address.

**Response `200 OK`** | **`404 Not Found`**

---

#### `POST /api/users`
Create a user directly (admin use).

**Request Body:**
```json
{ "Name": "...", "Email": "...", "PasswordHash": "...", "Role": "customer" }
```

**Response `201 Created`**

---

#### `PATCH /api/users/{id}`
Partially update a user.

**Response `204 No Content`** | **`404 Not Found`**

---

#### `DELETE /api/users/{id}`
Delete a user.

**Response `204 No Content`** | **`404 Not Found`**

---

### Customers API

> **Requires:** Any authenticated user (GET) · `AgentOrAdmin` (POST, PATCH) · `AdminOnly` (DELETE)

#### `GET /api/customers`
Returns all customers.

#### `GET /api/customers/{id}`
Returns a specific customer.

#### `POST /api/customers`
Create a customer profile.

**Request Body:**
```json
{
  "UserId": 1,
  "Name": "John Customer",
  "Email": "customer@insurance.com",
  "Phone": "555-1234",
  "Address": "123 Main Street"
}
```

**Response `201 Created`**

#### `PATCH /api/customers/{id}`
Update a customer profile.

#### `DELETE /api/customers/{id}`
Delete a customer.

---

### Agents API

> **Requires:** `AgentOrAdmin` (GET) · `AdminOnly` (POST, PATCH)

#### `GET /api/agents`
Returns all agents.

#### `GET /api/agents/{id}`
Returns a specific agent.

#### `POST /api/agents`
Create an agent.

**Request Body:**
```json
{
  "Name": "Jane Agent",
  "Email": "jane@insurance.com",
  "Region": "West"
}
```

#### `PATCH /api/agents/{id}`
Update an agent.

---

### Policies API

> **Requires:** Authenticated (GET) · `AgentOrAdmin` (POST, PATCH) · `AdminOnly` (DELETE)

#### `GET /api/policies`
Returns all policies. Filter with query params:

| Query Param | Type | Description |
|---|---|---|
| `customerId` | `int` | Filter by customer |
| `agentId` | `int` | Filter by agent |

**Examples:**
```
GET /api/policies?customerId=1
GET /api/policies?agentId=1
```

#### `GET /api/policies/{id}`
Returns a specific policy.

#### `POST /api/policies`
Create a policy.

**Request Body:**
```json
{
  "CustomerId": 1,
  "AgentId": 1,
  "PolicyName": "Standard Auto Insurance",
  "Premium": 1200.00,
  "StartDate": "2026-02-22T00:00:00",
  "EndDate": "2027-02-22T00:00:00",
  "Status": "Active"
}
```

**Response `201 Created`**

#### `PATCH /api/policies/{id}`
Update a policy.

**Response `204 No Content`**

#### `DELETE /api/policies/{id}`
Delete a policy.

**Response `204 No Content`**

---

### Claims API

> **Requires:** Authenticated (GET, POST) · `AgentOrAdmin` (PATCH) · `AdminOnly` (DELETE)

#### `GET /api/claims`
Returns all claims. Filter with query params:

| Query Param | Type | Description |
|---|---|---|
| `customerId` | `int` | Filter by customer |
| `policyId` | `int` | Filter by policy |

#### `GET /api/claims/{id}`
Returns a specific claim.

#### `POST /api/claims`
Submit a new claim.

**Request Body:**
```json
{
  "CustomerId": 1,
  "PolicyId": 1,
  "Description": "Car accident on highway",
  "Amount": 5000.00,
  "Status": "Pending"
}
```

**Response `201 Created`**

#### `PATCH /api/claims/{id}`
Update a claim (e.g. approve/reject).

**Request Body:**
```json
{
  "CustomerId": 1,
  "PolicyId": 1,
  "Description": "Car accident on highway",
  "Amount": 5000.00,
  "Status": "Approved"
}
```

**Response `204 No Content`**

#### `DELETE /api/claims/{id}`
Delete a claim.

---

### Insurance Requests API

> **Requires:** Authenticated (GET, POST) · `AgentOrAdmin` (PATCH)

#### `GET /api/insuranceRequests`
Returns all insurance requests. Filter with query params:

| Query Param | Type | Description |
|---|---|---|
| `customerId` | `int` | Filter by customer |
| `agentId` | `int` | Filter by agent |

#### `GET /api/insuranceRequests/{id}`
Returns a specific request.

#### `POST /api/insuranceRequests`
Create a new insurance request.

**Request Body:**
```json
{
  "CustomerId": 1,
  "AgentId": 1,
  "Type": "Auto",
  "Amount": 100000.00,
  "Status": "Pending"
}
```

**`Type` values:** `Auto`, `Home`, `Health`, `Life`, `Travel`

**Response `201 Created`**

#### `PATCH /api/insuranceRequests/{id}`
Update request (e.g. assign agent, change status).

---

### Policy Recommendations API

> **Requires:** Authenticated (GET) · `AgentOrAdmin` (POST)

#### `GET /api/policyRecommendations`
Returns all recommendations. Filter with query params:

| Query Param | Type | Description |
|---|---|---|
| `requestId` | `int` | Filter by insurance request |

#### `GET /api/policyRecommendations/{id}`
Returns a specific recommendation.

#### `POST /api/policyRecommendations`
Create a recommendation (agent recommends a policy to a customer's request).

**Request Body:**
```json
{
  "RequestId": 1,
  "PolicyName": "Gold Health Plan",
  "Premium": 650.00,
  "Coverage": "Up to 5,00,000"
}
```

**Response `201 Created`**

---

### Policy Applications API

> **Requires:** Authenticated

#### `GET /api/policyApplications`
Returns all applications. Filter with query params:

| Query Param | Type | Description |
|---|---|---|
| `agentId` | `int` | Filter by agent |
| `customerId` | `int` | Filter by customer |

#### `GET /api/policyApplications/{id}`
Returns a specific application.

#### `POST /api/policyApplications`
Create a policy application.

**Request Body:**
```json
{
  "AgentId": 1,
  "CustomerId": 1,
  "PolicyName": "Comprehensive Home Cover",
  "Status": "Pending"
}
```

**`Status` values:** `Pending`, `Approved`, `Rejected`

**Response `201 Created`**

#### `PATCH /api/policyApplications/{id}`
Update application status.

---

### Notifications API

> **Requires:** Authenticated

#### `GET /api/notifications`
Returns all notifications. Filter with query params:

| Query Param | Type | Description |
|---|---|---|
| `userId` | `int` | Filter by user |

#### `GET /api/notifications/{id}`
Returns a specific notification.

#### `POST /api/notifications`
Create a notification.

**Request Body:**
```json
{
  "UserId": 1,
  "Message": "Your policy has been activated.",
  "IsRead": false
}
```

**Response `201 Created`**

#### `PATCH /api/notifications/{id}`
Update notification (e.g. mark as read).

**Request Body:**
```json
{
  "UserId": 1,
  "Message": "Your policy has been activated.",
  "IsRead": true
}
```

**Response `204 No Content`**

---

### Payments API

> **Requires:** Authenticated

#### `GET /api/payments`
Returns all payments. Filter with query params:

| Query Param | Type | Description |
|---|---|---|
| `policyId` | `int` | Filter by policy |

#### `GET /api/payments/{id}`
Returns a specific payment.

#### `POST /api/payments`
Record a payment against a policy.

**Request Body:**
```json
{
  "PolicyId": 1,
  "Amount": 1200.00,
  "Method": "Card"
}
```

**`Method` values:** `Card`, `Bank Transfer`, `Cash`, `UPI`

**Response `201 Created`**

---

## Error Responses

All error responses follow the format:

```json
{ "message": "Human-readable error description." }
```

| HTTP Code | Meaning |
|---|---|
| `400 Bad Request` | Missing or invalid request body |
| `401 Unauthorized` | Missing or invalid JWT token |
| `403 Forbidden` | JWT valid but insufficient role |
| `404 Not Found` | Resource does not exist |
| `409 Conflict` | Unique constraint violation (e.g. duplicate email) |
| `500 Internal Server Error` | Unexpected server error |

---

## Running the Stack

### First Time Setup

```bash
# 1. Pull & start SQL Server container
docker run -d \
  --name hartford-sqlserver \
  -e "ACCEPT_EULA=Y" \
  -e "MSSQL_SA_PASSWORD=Hartford@2026" \
  -e "MSSQL_PID=Developer" \
  -p 1433:1433 \
  mcr.microsoft.com/mssql/server:2022-latest

# 2. Wait ~30 seconds for SQL Server to boot, then run:
cd Hartford.Insurance.Api
dotnet run
# → Migrations apply automatically
# → Seed data inserted automatically

# 3. API is live at:
#    http://localhost:5254
#    Swagger UI: http://localhost:5254/swagger
```

### Daily Startup (after first setup)

```bash
# Start Docker Desktop first, then:
docker start hartford-sqlserver
cd Hartford.Insurance.Api && dotnet run
```

### Add a New Migration

```bash
cd Hartford.Insurance.Api
dotnet ef migrations add <MigrationName> --output-dir Data/Migrations
dotnet ef database update   # optional — app auto-migrates on startup
```

---

## Azure Data Studio Connection

| Setting | Value |
|---|---|
| **Server** | `localhost,1433` |
| **Authentication type** | SQL Login |
| **Username** | `sa` |
| **Password** | `Hartford@2026` |
| **Database** | `HartfordInsuranceDb` |
| **Trust Server Certificate** | ✅ Enabled |

---

## Database Tables

| Table | Rows (Seeded) | Description |
|---|---|---|
| `Users` | 3 | customer, agent, admin |
| `Customers` | 1 | Linked to customer user |
| `Agents` | 1 | Insurance agent |
| `Policies` | 2 | Auto + Home policies |
| `Claims` | 0 | Empty (test via API) |
| `InsuranceRequests` | 2 | Auto + Life requests |
| `PolicyRecommendations` | 2 | Linked to requests |
| `PolicyApplications` | 1 | Pending application |
| `Notifications` | 2 | Welcome notifications |
| `Payments` | 0 | Empty (test via API) |

---

## Test Suite

A complete bash test script is included at `test-api.sh`:

```bash
bash test-api.sh
```

**46 tests covering:**
- All 11 REST resources
- GET all, GET by ID, GET with query filters
- POST (create), PATCH (update), DELETE
- Auth guard (401 without token)
- Role guard (403 with insufficient role)
- Duplicate email registration (409)
- Invalid credentials (401)
