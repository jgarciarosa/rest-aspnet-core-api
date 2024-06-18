# rest-aspnet-core-api

Projeto desenvolvido e disponibilizado para fins de consultas e estudos.

---

## Tecnologias

- [ASP.NET Core](https://dotnet.microsoft.com/pt-br/apps/aspnet)
 
- [.NET 8.0](https://dotnet.microsoft.com/pt-br/)
  
- [MySQL](https://www.mysql.com/)


## Pacotes

- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
 
- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools)
  
- [Microsoft.AspNetCore.Mvc.NewtonsoftJson](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/)

- [Pomelo.EntityFrameworkCore.MySql](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql)

# Setup da aplicação (local)

## Pré-requisito

Antes de rodar a aplicação é preciso garantir que as seguintes dependências estejam corretamente instaladas:
```
Microsoft.AspNetCore.App 8.0
MySQL 8
```

## Preparando ambiente

É necessário que o SQL Server esteja sendo executado

## Instalação da aplicação

Primeiramente, faça o clone do repositório:
```
https://github.com/jgarciarosa/rest-aspnet-core-api.git
```
Feito isso, abra o projeto com sua IDE de preferência (no meu caso Microsoft Visual Studio 2022):

Abra o Console de Gerenciador de Pacotes e execute o comando abaixo para que seja criado o Banco de dados "person" contendo a Tabela: "persons":
```
Update-database
```
Execute a aplicação.

Pronto. A aplicação está disponível em https://localhost:7006/swagger/index.html

# API

O projeto disponibiliza uma API REST: Person, onde utiliza o padrão REST de comunicação, produzindo e consumindo dados no formato JSON.

Segue abaixo a API disponível no projeto:

#### Person

  - /person (POST)
     - Espera atributos no formato JSON para serem critérios de criação no body da requisição.
     - exemplo json:
    ```
    {
      "person_first_name":"Jonas",
      "person_last_name": "Garcia Rosa",
      "person_gender": "Masculino"
    }
    ```
 - /person (GET)
 - /person/{id} (GET)    
 - /person/{id} (PUT)
     -  Espera atributos no formato JSON para serem critérios de atualização no body da requisição.
     - exemplo json:
    ```
    {
      "person_first_name":"Jonas",
      "person_last_name": "G. R.",
      "person_gender": "Masculino"
    }
    ```
 - /person/{id} (PATCH)
     -  Espera atributos no formato JSON para serem critérios de atualização no body da requisição.
     - exemplo json:
    ```
    [
      {
        "path": "/Gender",
        "value": "Masc"
      }
    ]
    ```

 - /person/{id} (DELETE)
