```markdown
# ShoppingCartDockerRestAPI

## Project Description
ShoppingCartDockerRestAPI is a .NET 8.0 web API for managing a shopping cart. It provides endpoints to add, update, delete, and retrieve shopping cart items. The project uses Entity Framework Core with an in-memory database for data storage.

## Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started)

## Setup Instructions

### Clone the Repository
```sh
git clone https://github.com/kyda-code/ShoppingCartDockerRestAPI.git
cd ShoppingCartDockerRestAPI
```

### Build and Run the Application
1. **Build the Docker image:**
   ```sh
   docker build -t shoppingcartdockerrestapi .
   ```

2. **Run the Docker container:**
   ```sh
   docker run -d -p 8080:8080 -p 8081:8081 shoppingcartdockerrestapi
   ```

### Running Locally
1. **Restore dependencies:**
   ```sh
   dotnet restore
   ```

2. **Build the project:**
   ```sh
   dotnet build
   ```

3. **Run the application:**
   ```sh
   dotnet run
   ```

## Usage
The API exposes the following endpoints:

- **GET /api/shoppingcart/items**: Retrieve all shopping cart items.
- **GET /api/shoppingcart/items/{id}**: Retrieve a specific shopping cart item by ID.
- **POST /api/shoppingcart/items**: Add a new shopping cart item.
- **PUT /api/shoppingcart/items/{id}**: Update an existing shopping cart item.
- **DELETE /api/shoppingcart/items/{id}**: Delete a shopping cart item.

## License
This project is licensed under the MIT License.
```