using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NServiceBus;
using NServiceBus.MessageInterfaces;
using NServiceBus.Serialization;
using Utf8Json;

class JsonMessageSerializer :
    IMessageSerializer
{
    IMessageMapper messageMapper;

    public JsonMessageSerializer(
        IMessageMapper messageMapper,
        IJsonFormatterResolver resolver,
        string contentType)
    {
        this.messageMapper = messageMapper;

        if (resolver == null)
        {
            this.resolver = global::Utf8Json.JsonSerializer.DefaultResolver;
        }
        else
        {
            this.resolver = resolver;
        }

        if (contentType == null)
        {
            ContentType = ContentTypes.Json;
        }
        else
        {
            ContentType = contentType;
        }
    }

    public void Serialize(object message, Stream stream)
    {
        try
        {
            global::Utf8Json.JsonSerializer.NonGeneric.Serialize(message.GetType(), stream, message, resolver);
        }
        catch (TypeAccessException exception)
        {
            throw new Exception($"Types need to be public. Type: {message.GetType().FullName}", exception);
        }
    }

    public object[] Deserialize(Stream stream, IList<Type> messageTypes)
    {
        if (messageTypes == null || !messageTypes.Any())
        {
            throw new Exception("Utf8Json requires message types to be specified");
        }

        var rootTypes = FindRootTypes(messageTypes);
        return rootTypes.Select(rootType =>
            {
                var messageType = GetMappedType(rootType);
                stream.Seek(0, SeekOrigin.Begin);

                try
                {
                    return global::Utf8Json.JsonSerializer.NonGeneric.Deserialize(messageType, stream, resolver);
                }
                catch (TypeAccessException exception)
                {
                    throw new Exception($"Types need to be public. Type: {messageType.FullName}", exception);
                }
            })
            .ToArray();
    }

    Type GetMappedType(Type serializedType)
    {
        return messageMapper.GetMappedTypeFor(serializedType) ?? serializedType;
    }


    static IEnumerable<Type> FindRootTypes(IEnumerable<Type> messageTypesToDeserialize)
    {
        Type? currentRoot = null;
        foreach (var type in messageTypesToDeserialize)
        {
            if (currentRoot == null)
            {
                currentRoot = type;
                yield return currentRoot;
                continue;
            }

            if (!type.IsAssignableFrom(currentRoot))
            {
                currentRoot = type;
                yield return currentRoot;
            }
        }
    }

    public string ContentType { get; }

    IJsonFormatterResolver resolver;
}