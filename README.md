# SupportWebApp

SupportWebApp er en Blazor Web App lavet som en del af Cloud Computing-undervisningen.

Løsningen fungerer som et simpelt supportsystem for IBAS, hvor brugeren kan oprette supporthenvendelser og se eksisterende henvendelser.

Data gemmes i Azure Cosmos DB.

## Funktioner

- Opret en ny supporthenvendelse
- Validering af inputfelter
- Gem supporthenvendelser i Azure Cosmos DB
- Vis eksisterende supporthenvendelser
- Navigation mellem oprettelse og oversigt

## Teknologier

- .NET 10
- Blazor
- C#
- Azure Cosmos DB
- Microsoft.Azure.Cosmos

## Azure Cosmos DB

Løsningen bruger:

- Database: `IBasSupportDB`
- Container: `ibassupport`
- Partition key: `/category`

En tilsvarende Cosmos DB kan oprettes med Azure CLI:

```bash
az provider register --namespace Microsoft.DocumentDB

az group create \
  --name IBasSupportRG \
  --location swedencentral

az cosmosdb create \
  --name <UNIKT-KONTO-NAVN> \
  --resource-group IBasSupportRG \
  --enable-free-tier true

az cosmosdb sql database create \
  --account-name <UNIKT-KONTO-NAVN> \
  --resource-group IBasSupportRG \
  --name IBasSupportDB

az cosmosdb sql container create \
  --account-name <UNIKT-KONTO-NAVN> \
  --resource-group IBasSupportRG \
  --database-name IBasSupportDB \
  --name ibassupport \
  --partition-key-path "/category"
```

## Konfiguration

Cosmos DB connection string gemmes lokalt og skal ikke lægges på GitHub.

Applikationen forventer følgende konfiguration:

- `CosmosDb:ConnectionString`
- `CosmosDb:DatabaseName`
- `CosmosDb:ContainerName`

## Status

Færdigt:

- Blazor Web App oprettet
- Model til supporthenvendelser
- Forbindelse til Azure Cosmos DB
- Oprettelse af supporthenvendelser
- Validering af formular
- Oversigt over supporthenvendelser
- Navigation mellem siderne
- Oprydning af standard Counter- og Weather-sider

## Næste skridt

Løsningen kan videreudvikles med funktioner som redigering og sletning af supporthenvendelser.