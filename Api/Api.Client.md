## Create a Client (POST /api/clients):

### JSON Request:

```json
{
    "name": "BumiTech Solutions Sdn Bhd",
    "email": "info@bumitech.com.my",
    "clientContact": {
        "phone": "03-12345678",
        "address": "Petaling Jaya, Selangor, Malaysia"
    }
}
```

### JSON Response (Success - 201 Created):

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "BumiTech Solutions Sdn Bhd",
    "email": "info@bumitech.com.my",
    "clientContact": {
        "phone": "03-12345678",
        "address": "Petaling Jaya, Selangor, Malaysia"
    },
    "projectIds": []
}
```

## Get a Client by ID (GET /api/clients/{clientId}):

### JSON Response (Success - 200 OK):

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "BumiTech Solutions Sdn Bhd",
    "email": "info@bumitech.com.my",
    "clientContact": {
        "phone": "03-12345678",
        "address": "Petaling Jaya, Selangor, Malaysia"
    },
    "projectIds": [
    "00000000-0000-0000-0000-000000000000",
    "00000000-0000-0000-0000-000000000000"
    ]
}
```

## Update a Client (PUT /api/clients/{clientId}):

### JSON Request:

```json
{
    "name": "pearlxcore ltd",
    "email": "pxc.ltd@mail",
    "clientContact": {
        "phone": "023303393",
        "address": "Bangsar KL"
    }
}
```

### JSON Response (Success - 200 OK):

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "pearlcore ltd",
    "email": "pxc.ltd@mail",
    "clientContact": {
        "phone": "023303393",
        "address": "Bangsar KL"
    },
    "projectIds": []
}
```

## Delete a Client (DELETE /api/clients/{clientId}):

### Response (Success - 204 No Content)
