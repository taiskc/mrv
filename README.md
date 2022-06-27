# mrv

Desafio Full Stack em .Net Core e VueJS.

## Execução

🟣 [API] (/backend/mrv)

Para criar o Banco de Dados
- pelo Visual Studio:
  Abrir o Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console)
  Executar os comandos
  ```
  add-migration "initial"
  update-database
  ```
  e rodar a aplicação (botão ▶).
- pela linha de comando do Windows:
  Executar os comandos
  ```
  dotnet ef migrations add "initial"
  dotnet ef database update
  dotnet run
  ```

🔵 [Front-End] (/frontend/mrv)
 
 Executar os comandos
   ```
  npm install
  npm run dev
  ```
  
## +

O front-end só aceita ou rejeita leads existentes. Para criar suas leads para teste, é necessário acessar o endpoint /api/lead de método POST passando um body do tipo:

   ```
  {
    "firstName": "string",
    "lastName": "string",
    "email": "string",
    "phone": "string",
    "suburb": "string",
    "category": "string",
    "price": 0,
    "description": "string",
  }
  ```
