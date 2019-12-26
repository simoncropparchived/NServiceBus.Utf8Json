using NServiceBus;
using NServiceBus.Utf8Json;
using Utf8Json.Resolvers;

class Usage
{
    Usage(EndpointConfiguration configuration)
    {
        #region Utf8JsonSerialization

        configuration.UseSerialization<Utf8JsonSerializer>();

        #endregion
    }

    void CustomSettings(EndpointConfiguration configuration)
    {
        #region Utf8JsonResolver

        var serialization = configuration.UseSerialization<Utf8JsonSerializer>();
        serialization.Resolver(StandardResolver.SnakeCase);

        #endregion
    }

    void ContentTypeKey(EndpointConfiguration configuration)
    {
        #region Utf8JsonContentTypeKey

        var serialization = configuration.UseSerialization<Utf8JsonSerializer>();
        serialization.ContentTypeKey("custom-key");

        #endregion
    }
}