# Customer API

The Customer API is a simple ASP.NET Core web application that provides information about customers. It reads customer data from a JSON file and exposes it through a RESTful API.

## API Endpoints

### Get Customers

- **Endpoint**: `/api/customers`
- **Method**: GET
- **Description**: Retrieve a list of customers.

### Sample Response

```json
[
  {
    "id": 1,
    "name": "Everett Brakus",
    "email": "Stanton6@gmail.com",
    "productPreference": "Shoes",
    "lastPurchaseDate": "2020-11-24",
    "numPurchasesLast30Days": 10,
    "lifetimeTotal": 3496.84
  },
  // ... other customer entries
]
```

