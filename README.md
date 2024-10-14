# WKTechnology Project

Este projeto consiste em duas partes principais: a API construída com ASP.NET Core e o front-end desenvolvido em Angular. O objetivo é fornecer uma aplicação web com CRUD de Produtos e Categorias.

## Índice

- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
  - [Back-end (API)](#back-end-api)
  - [Front-end (Angular)](#front-end-angular)
- [Execução](#execução)
  - [Rodando a API](#rodando-a-api)
  - [Rodando o Front-end](#rodando-o-front-end)
- [Variáveis de Ambiente](#variáveis-de-ambiente)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)

## Pré-requisitos

Certifique-se de ter os seguintes itens instalados:

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 8.0 ou superior)
- [Node.js e NPM](https://nodejs.org/en/) (versão 16 ou superior)
- [Angular CLI](https://angular.io/cli) (instalado globalmente)
- [MySQL](https://www.mysql.com/) (para o banco de dados)

## Instalação

### Back-end (API)

1. Clone o repositório:

   ```bash
   git clone https://github.com/erismaroliveira/WKTechnology.git
   ```

2. Navegue até o diretório do projeto da API:

   ```bash
   cd WKTechnology/WKTechnology.API
   ```

3. Restaure os pacotes NuGet:

   ```bash
   dotnet restore
   ```

4. Configure o banco de dados MySQL. Crie um banco de dados para o projeto:

   ```sql
   CREATE DATABASE WKTechnologyDB;
   ```

5. Edite o arquivo `appsettings.json` para incluir a string de conexão correta:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=WKTechnologyDB;User=wktechnology;Password=WKTechnology2024;"
     }
   }
   ```

6. Execute as migrações para criar as tabelas no banco de dados:

   ```bash
   dotnet ef database update
   ```

### Front-end (Angular)

1. Navegue até o diretório do projeto do front-end:

   ```bash
   cd WKTechnology/wk-tech-app
   ```

2. Instale as dependências do projeto:

   ```bash
   npm install
   ```

## Execução

### Rodando a API

1. No diretório da API (`WKTechnology.API`), execute o seguinte comando para rodar a aplicação:

   ```bash
   dotnet run
   ```

2. A API estará rodando por padrão na URL `http://localhost:5234`.

3. Verifique se a API está funcionando acessando a documentação Swagger em:

   ```
   http://localhost:5234/swagger
   ```

### Rodando o Front-end

1. No diretório do front-end (`wk-tech-app`), execute o comando para rodar o servidor de desenvolvimento:

   ```bash
   ng serve
   ```

2. Acesse o front-end no navegador:

   ```
   http://localhost:4200
   ```

## Variáveis de Ambiente

- Para o **back-end**, as variáveis de ambiente podem ser configuradas no arquivo `appsettings.json` ou diretamente no ambiente de execução. Certifique-se de configurar a string de conexão do banco de dados.

- Para o **front-end**, configure o arquivo `src/environments/environment.ts` para definir a URL da API:

  ```typescript
  export const environment = {
    production: false,
    API_URL: "http://localhost:5234/api/",
  };
  ```

## Tecnologias Utilizadas

- **Back-end**: ASP.NET Core, Entity Framework Core, MySQL
- **Front-end**: Angular, TypeScript
- **Documentação da API**: Swagger UI
