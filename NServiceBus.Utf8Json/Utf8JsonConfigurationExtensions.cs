using NServiceBus.Configuration.AdvanceExtensibility;
using NServiceBus.Serialization;
using NServiceBus.Settings;
using NServiceBus.Utf8Json;
using Utf8Json;

namespace NServiceBus
{
    /// <summary>
    /// Extensions for <see cref="SerializationExtensions{T}"/> to manipulate how messages are serialized via Utf8Json.
    /// </summary>
    public static class Utf8JsonConfigurationExtensions
    {
        /// <summary>
        /// Configures the <see cref="IJsonFormatterResolver"/> to use.
        /// </summary>
        /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
        /// <param name="resolver">The <see cref="IJsonFormatterResolver"/> to use.</param>
        public static void Resolver(this SerializationExtensions<Utf8JsonSerializer> config, IJsonFormatterResolver resolver)
        {
            Guard.AgainstNull(config, nameof(config));
            var settings = config.GetSettings();
            settings.Set<IJsonFormatterResolver>(resolver);
        }

        internal static IJsonFormatterResolver GetResolver(this ReadOnlySettings settings)
        {
            return settings.GetOrDefault<IJsonFormatterResolver>();
        }

        /// <summary>
        /// Configures string to use for <see cref="Headers.ContentType"/> headers.
        /// </summary>
        /// <remarks>
        /// Defaults to <see cref="ContentTypes.Json"/>.
        /// This setting is required when this serializer needs to co-exist with other json serializers.
        /// </remarks>
        /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
        /// <param name="contentTypeKey">The content type key to use.</param>
        public static void ContentTypeKey(this SerializationExtensions<Utf8JsonSerializer> config, string contentTypeKey)
        {
            Guard.AgainstNull(config, nameof(config));
            Guard.AgainstNullOrEmpty(contentTypeKey, nameof(contentTypeKey));
            var settings = config.GetSettings();
            settings.Set("NServiceBus.Utf8Json.ContentTypeKey", contentTypeKey);
        }

        internal static string GetContentTypeKey(this ReadOnlySettings settings)
        {
            return settings.GetOrDefault<string>("NServiceBus.Utf8Json.ContentTypeKey");
        }
    }
}