# My Expenses API
[![NPM](https://img.shields.io/npm/l/react)](https://github.com/Ismael-Gabri/MyExpenses.Api/blob/main/LICENCE) 

# Sobre o projeto

https://github.com/Ismael-Gabri/MyExpenses.Api

My Expenses.API é uma aplicação web construída por mim após realizar o curso de programação backend .NET do Balta.io (https://balta.io/carreiras/desenvolvedor-backend-dotnet)

A aplicação consiste em realizar uma overview sobre as despesas e rendas do usuário, agindo como um app de controle financeiro, onde o usuário fará log in e irá listar suas despesas e suas entradas monetárias mensais, dessa forma a aplicação irá gerar projeções e gráficos baseando-se nesses dados.

## Implementação do Log in
![Web 1](https://github.com/Ismael-Gabri/assets/blob/main/imagens/Medium%20Login%20Screen.png)
O sistema de log in foi projetado com JWT Bearer, o código irá utilizar o email e a senha de usuário para no fim gerar um Token de acesso, dessa forma o usuário poderá performar requisições padrões de um usuário logado, como por exemplo, realizar um CRUD completo em suas despesas e rendas. O token gerado tem um tempo de validade de 8 horas, sendo necessário realizar um novo log in após esse período.

![Web 2](https://github.com/Ismael-Gabri/assets/blob/main/imagens/Login%20Requisition%202.png)

## Modelo conceitual
![Modelo Conceitual](https://github.com/acenelio/assets/raw/main/sds1/modelo-conceitual.png)

# Tecnologias utilizadas
## Back end
- C#
- .NET
- Entitiy Framework Core
- Maven
## Banco de dados
- MySQL
- Docker
## Front end
- HTML / CSS / JS / TypeScript
- Angular

# Autor

Ismael Gabri de Castro Junior

https://www.linkedin.com/in/ismael-gabri-ab76b9223/
