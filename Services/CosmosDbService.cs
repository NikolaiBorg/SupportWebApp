using Microsoft.Azure.Cosmos;
using SupportWebApp.Models;

namespace SupportWebApp.Services;

public class CosmosDbService
{
    private readonly Container _container;

    public CosmosDbService(IConfiguration configuration)
    {
        string connectionString =
            configuration["CosmosDb:ConnectionString"]
            ?? throw new InvalidOperationException("Cosmos DB connection string mangler.");

        string databaseName =
            configuration["CosmosDb:DatabaseName"]
            ?? throw new InvalidOperationException("Database-navn mangler.");

        string containerName =
            configuration["CosmosDb:ContainerName"]
            ?? throw new InvalidOperationException("Container-navn mangler.");

        CosmosClient cosmosClient = new CosmosClient(connectionString);
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    public async Task CreateSupportMessageAsync(SupportMessage message)
    {
        await _container.CreateItemAsync(
            message,
            new PartitionKey(message.Category)
        );
    }

    public async Task<List<SupportMessage>> GetSupportMessagesAsync()
    {
        var messages = new List<SupportMessage>();

        var query = _container.GetItemQueryIterator<SupportMessage>(
            "SELECT * FROM c ORDER BY c.datoTidspunkt DESC"
        );

        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            messages.AddRange(response);
        }

        return messages;
    }
}