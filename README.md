# Brka-App
 Sistema de controle de conta corrente que rende 100% do CDI

![sonar quality](badges/measure.svg)
![sonar quality](badges/sonarAnalysis.png)

## Requisitos
- Dotnet Core SDK - 3.1.402  
- yarn - 1.22.5  
- Docker e Docker Compose (19.03.6) ou MySql (8.0.21)  
- Vue/Cli - 4.5.6  
- Quasar/Cli - 1.1.0  

 ## Tecnologias implementadas
 - ASP.NET Core 3.1  
 - Quartz (Cria JOB para rentabilizar conta corrente)  
 - Swagger UI 5  
 - Entity Framework Core  
 - Axios  
 - VueJs  
 - Quasar Framework  

## Fluxo Arquitetura  
```mermaid
sequenceDiagram
Fronted App ->> Contas WebApi: /ExtratoContaCorrente
Contas WebApi ->> Fronted App: Extrato
Contas WebApi ->> Bacen Gateway: /TaxasDeJuros/CdiDia
Bacen Gateway ->> Contas WebApi: Taxa CDI do Dia

Note right of Contas WebApi: Contas End Points:<br/>Acessar em<br/>Contas Api<br/>/swagger
```

## Para rodar este projeto