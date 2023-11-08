## Create a Task (POST /api/tasks):

### JSON Request:

```json
{
  "TaskName": "Task 1",
  "TaskDescription": "This is the description of Task 1.",
  "StartDate": "2023-10-30",
  "EndDate": "2023-11-15",
  "TaskStatus": "open",
  "Priority": "medium",
  "AssignedTeamMembers": ["user-guid-1", "user-guid-2"]
}
```

### JSON Response (Success - 201 Created):

```json
{
  "TaskId": "a3a2dce1-1a4d-4b16-ba52-48a1f819cf45",
  "TaskName": "Task 1",
  "TaskDescription": "This is the description of Task 1.",
  "StartDate": "2023-10-30",
  "EndDate": "2023-11-15",
  "TaskStatus": "open",
  "Priority": "medium",
  "AssignedTeamMembers": ["user-guid-1", "user-guid-2"]
}
```

## Get a Task by ID (GET /api/tasks/{taskId}):

### JSON Response (Success - 200 OK):

```json
{
  "TaskId": "a3a2dce1-1a4d-4b16-ba52-48a1f819cf45",
  "TaskName": "Task 1",
  "TaskDescription": "This is the description of Task 1.",
  "StartDate": "2023-10-30",
  "EndDate": "2023-11-15",
  "TaskStatus": "open",
  "Priority": "medium",
  "AssignedTeamMembers": ["user-guid-1", "user-guid-2"]
}
```

## Update a Task (PUT /api/tasks/{taskId}):

### JSON Request:

```json
{
  "TaskName": "Updated Task 1",
  "TaskDescription": "Updated description of Task 1.",
  "StartDate": "2023-10-31",
  "EndDate": "2023-11-16",
  "TaskStatus": "closed",
  "Priority": "high",
  "AssignedTeamMembers": ["user-guid-1", "user-guid-3"]
}
```

### JSON Response (Success - 200 OK):

```json
{
  "TaskId": "a3a2dce1-1a4d-4b16-ba52-48a1f819cf45",
  "TaskName": "Updated Task 1",
  "TaskDescription": "Updated description of Task 1.",
  "StartDate": "2023-10-31",
  "EndDate": "2023-11-16",
  "TaskStatus": "closed",
  "Priority": "high",
  "AssignedTeamMembers": ["user-guid-1", "user-guid-3"]
}
```

## Delete a Task (DELETE /api/tasks/{taskId}):

### Response (Success - 204 No Content)
