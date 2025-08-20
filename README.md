# DapperUserApi

Este projeto é uma API RESTful desenvolvida com **.NET 9**, **Dapper** e **SQL Server**, com o objetivo de gerenciar funcionários.

## 🚀 Funcionalidades

- ✅ Cadastro, edição, leitura e exclusão de usuários
- ✅ Documentação interativa com Scalar
- ✅ Repository Pattern

## 🛠️ Tecnologias Utilizadas

- NET 9
- Dapper
- SQL Server
- Scalar

## ▶️ Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/thallesmb/DapperUserApi

2. Acesse a pasta do projeto:
   ```bash
   cd seu-repositorio

3. Configure a connection string no appsettings.json
   ```bash
   "DefaultConnection": "server= localhost\\SQLEXPRESS; database= WebApiLivraria; trusted_connection=true; trustservercertificate=true;"

4. Execute o projeto:
   ```bash
   dotnet run

6. Acesse a documentação Scalar:
   ```bash
   https://localhost:{porta}/scalar/v1

# 🔹 Endpoints

| Método | Endpoint       | Descrição                     |
|--------|----------------|-------------------------------|
| GET    | /users         | Retorna a lista de usuários.  |
| GET    | /users/{id}    | Retorna um usuário pelo ID.   |
| POST   | /users         | Adiciona um novo usuário.     |
| PUT    | /users/{id}    | Atualiza um usuário existente.|
| DELETE | /users/{id}    | Remove um usuário.            |
