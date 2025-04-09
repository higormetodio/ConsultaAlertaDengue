# ConsultaAlertaDengue
Este é um projeto que tem como propósito a realização de consultas a API Alerta Dengue ( https://info.dengue.mat.br/services/api/doc )


## Objetivos :page_facing_up:
:white_check_mark: Criação de uma aplicação para consultar dados da API Alerta Dengue e persistir esses dados em banco.

:white_check_mark: Criação uma API com um endpoint que realize uma consulta ao banco com base da semanha epidemiológica e o ano.

:white_check_mark: Criação das informação da consulta em uma aplicação Web. 



## Entregas :pencil:
:arrow_forward: Aplicação Web criada em ASP.NET Core MVC com .NET 8.

:arrow_forward: Web API criada em ASP.NET WebAPI com .NET 8.

:arrow_forward: Front End em React


## Tecnologias, Pacotes e Versões
:arrow_forward: [C#](https://learn.microsoft.com/en-us/dotnet/csharp/)

:arrow_forward: [ASP.NET Core 8.0.14](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0)

:arrow_forward: [Entity Framework Core 8.0.14](https://learn.microsoft.com/en-us/ef/)

:arrow_forward: [Pomelo EntityFrameworkCore MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)

:arrow_forward: [MySql 8.3.0](https://www.mysql.com/downloads/)

:arrow_forward: [FluentAssertions 7.0.0](https://fluentassertions.com/introduction )

:arrow_forward: [XUnit 2.5.3](https://xunit.net/)

:arrow_forward: [MEntity FrameworkCore.InMemory 2.5.3](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli)

:arrow_forward: [NSubstitute 5.3.0](https://nsubstitute.github.io/)

:arrow_forward: [Bogus](https://github.com/bchavez/Bogus)

:arrow_forward: [React](https://pt-br.legacy.reactjs.org/)


## Orgranização - Estrutura de pastas do projeto
```
- ConsultaAlertaDengue/
  - src/
    - ConsultaAlertaDengue.API/
    - ConsultaAlertaDengue.Application/
    - ConsultaAlertaDengue.Domain/
    - ConsultaAlertaDengue.Infrastructure/
    - ConsultaAlertaDengue.WebApp/
    - ConsultaAlertaDengue.WebReact/
  - tests/
    - API.Tests/
    - Application.Test/
    - CommonTestUtilities/
    - WebApp.Test/      
```


## Rodando a aplicação com .NET
Ao baixar a aplicação você pode rodar as seguintes aplicações.

Aplicando as Migrations
```powershell
dotnet database update --project ConsultaAlertaDengue.Infrastructure.csproj --startup-project  ./ConsultaAlertaDengue/src/ConsultaAlertaDengue.API/ConsultaAlertaDengue.API.csproj --context ConsultaAlertaDengue.Infrastructure.DataAccess.ConsultaAlertaDengueDbContext
```

Dentro da pasta do Projeto ConsultaAlertaDengu.WebApp - Executar para ter acesso a aplicação que gera e atualiza os dados
```powershell
dotnet watch run
```

Dentro da pasta do Projeto ConsultaAlertaDengu.API - Executar para ter acesso ao endpoint da API que está fazendo consultas no banco
```powershell
dotnet watch run
```

Dentro da pasta do Projeto ConsultaAlertaDengue.WebReact na pasta consulta-alerta-dengue-webreact - Executar para ter acesso a WebApp que exibe os dados persistidos em banco
```powershell
npm start
```


## Testes de Unidade e Integração
Para os testes de unidade foram utilizados os pacotes NSubstitute que é uma biblioteca de mocking para .NET, projetada para facilitar a criação de testes unitários e o Bogus que é uma biblioteca para a geração de dados falsos. Além disso, foi utilizado o FluentAssertions para ganho de produtividade na escrita dos testes. 
IMPORTANTE: Como o FluentAssertions agora é pago você pode "travar" a atualização do pacote 7.0.0 da seguinte forma: 

```arquivo .csproj do projeto de testes
<PackageReference Include="FluentAssertions" Version="[7.0.0]" />
```
