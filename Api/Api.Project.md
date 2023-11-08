## Create a Project (POST /api/projects):

### JSON Request:

```json
{
  "ProjectName": "Project A",
  "ProjectDescription": "This is the description of Project A.",
  "StartDate": "2023-11-01",
  "EndDate": "2023-12-31",
  "Status": "in progress",
  "Priority": "medium",
  "Budget": 50000.00,
  "AssignedTeamMembers": ["user-guid-1", "user-guid-2"],
  "ClientInformation": {
    "ClientId": "client-guid-1"
  }
}
```

### JSON Response (Success - 201 Created):

```json
{
  "ProjectId": "c4a2dce1-1a4d-4b16-ba52-48a1f819cf45",
  "ProjectName": "Project A",
  "ProjectDescription": "This is the description of Project A.",
  "StartDate": "2023-11-01",
  "EndDate": "2023-12-31",
  "Status": "in progress",
  "Priority": "medium",
  "Budget": 50000.00,
  "AssignedTeamMembers": ["user-guid-1", "user-guid-2"],
  "ClientInformation": {
    "ClientId": "client-guid-1",
    "ClientName": "ABC Corporation",
    "ContactInformation": {
      "Phone": "+1 123-456-7890",
      "Address": "123 Oak St, Anytown, USA"
    }
  }
}
```

## Get a Project by ID (GET /api/projects/{projectId}):

### JSON Response (Success - 200 OK):

```json
{
  "ProjectId": "c4a2dce1-1a4d-4b16-ba52-48a1f819cf45",
  "ProjectName": "Project A",
  "ProjectDescription": "This is the description of Project A.",
  "StartDate": "2023-11-01",
  "EndDate": "2023-12-31",
  "Status": "in progress",
  "Priority": "medium",
  "Budget": 50000.00,
  "AssignedTeamMembers": ["user-guid-1", "user-guid-2"],
  "ClientInformation": {
    "ClientId": "client-guid-1",
    "ClientName": "ABC Corporation",
    "ContactInformation": {
      "Phone": "+1 123-456-7890",
      "Address": "123 Oak St, Anytown, USA"
    }
  }
}
```

## Update a Project (PUT /api/projects/{projectId}):

### JSON Request:

```json
{
  "ProjectName": "Updated Project A",
  "ProjectDescription": "Updated description of Project A.",
  "StartDate": "2023-11-02",
  "EndDate": "2024-01-15",
  "Status": "completed",
  "Priority": "high",
  "Budget": 60000.00,
  "AssignedTeamMembers": ["user-guid-1", "user-guid-3"],
  "ClientInformation": {
    "ClientId": "client-guid-2"
  }
}
```

### JSON Response (Success - 200 OK):

```json
{
  "ProjectId": "c4a2dce1-1a4d-4b16-ba52-48a1f819cf45",
  "ProjectName": "Updated Project A",
  "ProjectDescription": "Updated description of Project A.",
  "StartDate": "2023-11-02",
  "EndDate": "2024-01-15",
  "Status": "completed",
  "Priority": "high",
  "Budget": 60000.00,
  "AssignedTeamMembers": ["user-guid-1", "user-guid-3"],
  "ClientInformation": {
    "ClientId": "client-guid-2",
    "ClientName": "XYZ Ltd",
    "ContactInformation": {
      "Phone": "+1 987-654-3210",
      "Address": "456 Maple St, Othercity, USA"
    }
  }
}
```

## Delete a Project (DELETE /api/projects/{projectId}):

### Response (Success - 204 No Content)
