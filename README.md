# mrv

Desafio Full Stack em .Net Core e VueJS.

## Execução

🟣 [BackEnd] (/backend/mrv)

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
  
ATENÇÃO: O FrontEnd só aceita ou rejeita _leads_ existentes. Para criar suas _leads_ para teste, é necessário acessar o endpoint _/api/lead/_ de método "POST" da API, passando um _body_ do tipo:

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
  
Outras operações básicas não utilizadas pelo FrontEnd foram criadas para facilitar a manipulação dos dados, como documentado no Swagger, que deve estar disponível no endereço https://localhost:7079/swagger/index.html.


🔵 [FrontEnd] (/frontend/mrv)
 
 Executar os comandos
   ```
  npm install
  npm run dev
  ```
A Aplicação Web deve estar rodando no endereço [https://localhost:8000/.] (http://localhost:8080/)
