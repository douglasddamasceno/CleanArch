# CleanArch Template
Template básico sem utilização do Mediator ou libs para mapeamento, apenas apresentando de forma mais simples o fluxo de dados entre as camadas da arquitetura.
> A solução dispensa o uso do DTO de entrada do tipo "[Nome]Request", integrante da camada de Apresentação (Api), pois o modelo do "Command" (Application) já cumpre esse papel de entrada tendo em vista que seu payload já representa a necessidade de entrada já que não há exigências de aplicação de regras de transição de objetos que exijam os dois modelos.
