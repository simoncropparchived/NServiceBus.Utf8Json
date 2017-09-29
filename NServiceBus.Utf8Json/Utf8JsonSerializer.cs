using System;
using NServiceBus.MessageInterfaces;
using NServiceBus.Serialization;
using NServiceBus.Settings;

namespace NServiceBus.Utf8Json
{
    /// <summary>
    /// Defines the capabilities of the Utf8Json serializer
    /// </summary>
    public class Utf8JsonSerializer : SerializationDefinition
    {
        /// <summary>
        /// <see cref="SerializationDefinition.Configure"/>
        /// </summary>
        public override Func<IMessageMapper, IMessageSerializer> Configure(ReadOnlySettings settings)
        {
            return mapper =>
            {
                var resolver = settings.GetResolver();
                var contentTypeKey = settings.GetContentTypeKey();
                return new JsonMessageSerializer(mapper, resolver, contentTypeKey);
            };
        }
    }
}