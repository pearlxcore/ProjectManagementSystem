## Create a Client (POST /api/clients):

### JSON Request:

```json
{
  "ClientName": "ABC Corporation",
  "ContactInformation": {
    "Phone": "+1 123-456-7890",
    "Address": "123 Oak St, Anytown, USA"
  },
  "Projects": []
}
```

### JSON Response (Success - 201 Created):

```json
{
  "ClientId": "aa8dce11-4a16-184d-ba52-48a1f819cf45",
  "ClientName": "ABC Corporation",
  "ContactInformation": {
    "Phone": "+1 123-456-7890",
    "Address": "123 Oak St, Anytown, USA"
  },
  "Projects": []
}
```

## Get a Client by ID (GET /api/clients/{clientId}):

### JSON Response (Success - 200 OK):

```json
{
  "ClientId": "aa8dce11-4a16-184d-ba52-48a1f819cf45",
  "ClientName": "ABC Corporation",
  "ContactInformation": {
    "Phone": "+1 123-456-7890",
    "Address": "123 Oak St, Anytown, USA"
  },
  "Projects": []
}
```

## Update a Client (PUT /api/clients/{clientId}):

### JSON Request:

```json
{
  "ClientName": "XYZ Ltd",
  "ContactInformation": {
    "Phone": "+1 987-654-3210",
    "Address": "456 Maple St, Othercity, USA"
  },
  "Projects": ["project-guid-1", "project-guid-2"]
}
```

### JSON Response (Success - 200 OK):

```json
{
  "ClientId": "aa8dce11-4a16-184d-ba52-48a1f819cf45",
  "ClientName": "XYZ Ltd",
  "ContactInformation": {
    "Phone": "+1 987-654-3210",
    "Address": "456 Maple St, Othercity, USA"
  },
  "Projects": ["project-guid-1", "project-guid-2"]
}
```

## Delete a Client (DELETE /api/clients/{clientId}):

### Response (Success - 204 No Content)
