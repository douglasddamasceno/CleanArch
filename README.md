# Clean Architecture Template
O *Template* Básico proposto visa simplificar a demonstração do fluxo de dados entre as camadas da Clean Architecture, dispensando a utilização de Design Patterns avançados como Mediator ou bibliotecas de mapeamento, como o AutoMapper.

Em alinhamento com esta premissa de simplicidade, a solução omite a criação de DTOs de entrada dedicados à Camada de Apresentação, como `CriarProdutoRequest`. Em vez disso, o Objeto `Command` (definido na Camada de Aplicação) é utilizado diretamente como modelo de entrada (payload) nos *endpoints* da API. Essa abordagem é justificada pela paridade estrutural dos modelos de dados. Como o `Command` já encapsula exatamente os dados necessários para a execução do Caso de Uso - Regra de Negócio da Aplicação - e o cenário proposto não exige transformações de dados ou regras de negócio que demandem um mapeamento explícito na fronteira da Camada de Apresentação, evitamos a duplicação desnecessária de classes e simplificamos o fluxo.

> Nota: Em cenários onde a arquitetura exige a transição explícita entre modelos de dados - mapear um `Request` da API para um `Command` da Aplicação, ou uma `Entidade` para um Response - a prática de mapeamento é crucial. Para gerenciar essa transição, o projeto pode adotar:
1. Bibliotecas de mapeamento por convenção, como AutoMapper ou Mapster.
2. O uso de Métodos de Extensão (`.ToCommand()`, `.ToResponse()`, `.ToMap` ou `.ToEntidade`) ou *mappers* dedicados, que oferecem maior rastreabilidade e menos dependências externas.
Particularmente, priorizo os Métodos de Extensão por promoverem um fluxo de dados mais transparente e desacoplado de bibliotecas de terceiros.

## Projeto
### Migrations
1. Adicionar versão
```powershell
dotnet ef migrations add VersaoInicial --startup-project .\src\Api\ --project .\src\Infrastructure\
```
2. Aplicar versão na base da dados
```powershell
dotnet ef database update --startup-project .\src\Api\ --project .\src\Infrastructure\
```
