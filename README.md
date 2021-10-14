# PaymentContext (Curso 1975 - Modelando Domínios Ricos - balta.io)

Projeto em dotnet para criação de um aplicativo de pagamento usando metodologia de domínios ricos
É aplicado os conceitos de OOP, DDD e CQRS para modelar um contexto de pagamentos.
Foi criado um contexto de um projeto de pagamentos (gateway de pagamentos) onde é possível passar por todas as etapas na modelagem da solução separados em cada branch.

# Este projeto foi criado usando a modelagem de domínios ricos

- [X] Conceitos de OOP

- [X] Aplicação DDD (Domain-Driven Design)

- [X] Conceito de CQRS (Command Query Responsibility Segregation)

- [X] Conceitos de SOLID e Clean Code

- [X] Corrupção no código

- [X] Evitar a obsessão por tipos primitivos no seu código

- [X] Utilização Design by Contracts

- [X] Utilização da extensão Flunt para validações [Documentação Flunt](https://balta.io/blog/flunt) 

- [X] Implementação Fail-Fast Validations

- [X] Implementação do Repository Pattern

- [X] Testes de Entidades e Value Objects

- [X] Testes de Handlers e Queries

# Tecnologias e versões utilizadas
C#

# Branchs do projeto
**#01 - Branch Projeto Base** -> branch com a estrutura inicial do projeto.

**#02 - Branch Entidades** -> branch com a criação das entidades utilizadas no projeto

**#03 - Branch Corrupção de Código** -> branch com a correção deixando o acesso para manipulação das entidades mais restritas

**#04 - Branch values Objects** -> branch com a criação dos values objects 

**#05 - Branch Validations** -> branch com a criação das validações

**#06 - Branch testes de Unidade** -> branch com acriaçaõ dos testes de unidade (Value Obejcts)

**#07 - Branch Commands** -> branch com a criação dos commands e testes

**#08 - Branch Repositório And Handlers** -> branch com a criação de um MOck do repositório, criação dos handlers, mock de Queries e testes

**#Main#** - Branch com o projeto final 

# Dependências
```
dotnet add package Flunt --version 2.0.5
```
# Contribuição

Projeto realizado através do curso realizado através da Plataforma [Balta.io](https://balta.io/)

In
dotnet add package Flunt --version 2.0.0

