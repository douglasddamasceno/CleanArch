# CleanArch Template
Template básico sem utilização do Mediator ou libs para mapeamento, apenas apresentando de forma mais simples o fluxo de dados entre as camadas da arquitetura.
> A solução dispensa o uso do DTO de entrada do tipo "[Nome]Request", integrante da camada de Apresentação (Api), pois o modelo do "Command" (Application) já cumpre esse papel de entrada, pois o payload do "Command" já representa a necessidade de entrada sem aplicação de regras na transição entre os modelos.
