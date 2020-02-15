# <img src="/src/icon.png" height="30px"> NServiceBus.Utf8Json

[![Build status](https://ci.appveyor.com/api/projects/status/oiqo5mrf54mh9iu8/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/nservicebus-Utf8Json)
[![NuGet Status](https://img.shields.io/nuget/v/NServiceBus.Utf8Json.svg)](https://www.nuget.org/packages/NServiceBus.Utf8Json/)


Add support for [NServiceBus](https://particular.net/NServiceBus) message serialization via [Utf8Json](https://github.com/neuecc/Utf8Json)

toc

<!--- StartOpenCollectiveBackers -->

[Already a Patron? skip past this section](#endofbacking)


## Community backed

**It is expected that all developers [become a Patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976) to use NServiceBusExtensions. [Go to licensing FAQ](https://github.com/NServiceBusExtensions/Home/#licensingpatron-faq)**


### Sponsors

Support this project by [becoming a Sponsor](https://opencollective.com/nservicebusextensions/contribute/sponsor-6972). The company avatar will show up here with a website link. The avatar will also be added to all GitHub repositories under the [NServiceBusExtensions organization](https://github.com/NServiceBusExtensions).


### Patrons

Thanks to all the backing developers! Support this project by [becoming a patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976).

<img src="https://opencollective.com/nservicebusextensions/tiers/patron.svg?width=890&avatarHeight=60&button=false">

<a href="#" id="endofbacking"></a>

<!--- EndOpenCollectiveBackers -->


## NuGet package

https://nuget.org/packages/NServiceBus.Utf8Json/


## Usage

snippet: Utf8JsonSerialization


### Resolver

It is possible to customize the instance of [IJsonFormatterResolver](https://github.com/neuecc/Utf8Json#resolver) used for serialization.

snippet: Utf8JsonResolver


### Custom content key

When using [additional deserializers](https://docs.particular.net/nservicebus/serialization/#specifying-additional-deserializers) or transitioning between different versions of the same serializer it can be helpful to take explicit control over the content type a serializer passes to NServiceBus (to be used for the [ContentType header](https://docs.particular.net/nservicebus/messaging/headers#serialization-headers-nservicebus-contenttype)).

snippet: Utf8JsonContentTypeKey


## Currently not supported

The use of `DataBusProperty<T>` is not supported because the property doesn't provide a default constructor. However, the use of the [databus conventions](https://docs.particular.net/nservicebus/messaging/databus) is supported.


## Security contact information

To report a security vulnerability, use the [Tidelift security contact](https://tidelift.com/security). Tidelift will coordinate the fix and disclosure.


## Icon

[Fractal](https://thenounproject.com/term/fractal/26234/) designed by [Yi Chen](https://thenounproject.com/jsczcy/) from [The Noun Project](https://thenounproject.com).