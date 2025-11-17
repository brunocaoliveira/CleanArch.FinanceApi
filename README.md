# Api de Finanças com Clean Architecture

![.NET](https://img.shields.io/badge/.NET-8-blueviolet)
![Testes](https://img.shields.io/badge/Testes-xUnit%20%7C%20Moq-green)
![Licença](https://img.shields.io/badge/Licen%C3%A7a-MIT-blue)

API RESTful em .NET 8 para um simples gestor de finanças pessoais. Este projeto é um estudo prático focado na implementação de **Arquitetura Limpa (Clean Architecture)** e **Princípios SOLID** em um ambiente .NET.

---

## 🏛️ Arquitetura e Padrões de Design

O principal objetivo deste projeto não é apenas a funcionalidade, mas sim demonstrar uma arquitetura de back-end robusta, testável e de fácil manutenção.

O design da aplicação é baseado em uma arquitetura de 3 camadas (3-Layer) desacoplada:

1.  **Camada de Apresentação (API):**
    * Responsável por lidar com requisições **HTTP**.
    * Usa **Controllers** "burros" que apenas orquestram o fluxo.
    * Utiliza **DTOs (Data Transfer Objects)** para "blindar" a API contra **Over-Posting** e desacoplar os modelos internos dos externos.
    * Lida com a captura de exceções (`try-catch`) e retorna os `Http Status Codes` corretos (ex: 200, 400, 404).

2.  **Camada de Serviço (Service Layer):**
    * O "cérebro" da aplicação.
    * Responsável por **toda a lógica de negócio** (ex: "O valor de uma transação não pode ser zero").
    * Mapeia DTOs para os Modelos de domínio.
    * É a única camada que fala com o Repositório.

3.  **Camada de Dados (Repository Layer):**
    * Implementa o **Repository Pattern** para abstrair o acesso aos dados.
    * É a única camada que "conhece" o **Entity Framework Core**.
    * Toda a comunicação com o `DbContext` é isolada aqui.

### 🔥 Princípios Aplicados

* **S (SOLID) - Princípio da Responsabilidade Única:** Cada camada (Controller, Service, Repository) tem uma, e apenas uma, responsabilidade clara.
* **D (SOLID) - Princípio da Inversão de Dependência:** Todas as camadas dependem de **abstrações** (`Interfaces`), e não de implementações concretas, permitindo o uso da **Injeção de Dependência** nativa do .NET.
* **Testes Unitários:** A camada de Serviço (lógica de negócio) é testada usando **xUnit** e **Moq** para garantir que as regras sejam sempre aplicadas.

---

## 🛠️ Tech Stack (Tecnologias Utilizadas)

* **.NET 8**
* **ASP.NET Core Web API**
* **Entity Framework Core 8**
* **SQLite** (Banco de dados)
* **xUnit** (Motor de testes)
* **Moq** (Framework de "Mocking" para testes)
* **Swagger/OpenAPI** (Documentação da API)

---

## 🚀 Como Executar o Projeto

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/SEU-USUARIO/Dotnet.CleanArch.FinanceApi.git](https://github.com/SEU-USUARIO/Dotnet.CleanArch.FinanceApi.git)
    cd Dotnet.CleanArch.FinanceApi
    ```

2.  **Restaure os pacotes:**
    ```bash
    dotnet restore
    ```

3.  **Crie o banco de dados (SQLite):**
    Este comando aplica as "Migrations" e cria o arquivo `financas.db` na pasta da API.
    ```bash
    dotnet ef database update --project FinancasPessoais.Api/FinancasPessoais.Api.csproj
    ```

4.  **Execute o projeto:**
    ```bash
    dotnet run --project FinancasPessoais.Api/FinancasPessoais.Api.csproj
    ```

5.  **Acesse a documentação (Swagger):**
    Abra seu navegador e acesse a URL que apareceu no terminal (ex: `http://localhost:5123/swagger`).

---

## 🧪 Como Rodar os Testes

Para verificar se toda a lógica de negócio está funcionando corretamente, execute:

```bash
dotnet test
