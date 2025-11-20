# Clean Architecture Template
O *Template* Básico proposto visa simplificar a demonstração do fluxo de dados entre as camadas da Clean Architecture, dispensando a utilização de Design Patterns avançados como Mediator ou bibliotecas de mapeamento, como o AutoMapper.

Em alinhamento com esta premissa de simplicidade, a solução omite a criação de DTOs de entrada dedicados à Camada de Apresentação, como `CriarProdutoRequest`. Em vez disso, o Objeto `Command` (definido na Camada de Aplicação) é utilizado diretamente como modelo de entrada (payload) nos *endpoints* da API. Essa abordagem é justificada pela paridade estrutural dos modelos de dados. Como o `Command` já encapsula exatamente os dados necessários para a execução do Caso de Uso - Regra de Negócio da Aplicação - e o cenário proposto não exige transformações de dados ou regras de negócio que demandem um mapeamento explícito na fronteira da Camada de Apresentação, evitamos a duplicação desnecessária de classes e simplificamos o fluxo.

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
