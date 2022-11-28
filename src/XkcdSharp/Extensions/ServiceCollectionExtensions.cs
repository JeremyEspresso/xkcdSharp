using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Remora.Rest.Extensions;
using Remora.Results;
using XkcdSharp.API.Objects;
using XkcdSharp.API.Rest;

namespace XkcdSharp.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddXkcd(this IServiceCollection services)
    {
        var clientBuilder = services
            .AddRestHttpClient<NotFoundError>()
            .ConfigureHttpClient((_, client) =>
            {
                var asmName = Assembly.GetExecutingAssembly().GetName();
                var name = asmName.Name ?? "XKCDSharp - JeremyEspresso @ GitHub"; 
                var version = asmName.Version ?? new Version(1, 0, 0);
                client.DefaultRequestHeaders.UserAgent.Add
                (
                    new ProductInfoHeaderValue(name, version.ToString())
                );
            });

        services.AddSingleton<IXkcdRestAPI, XkcdRestAPI>();
        services.Configure<JsonSerializerOptions>(options =>
        {
            options.AddDataObjectConverter<IComic, Comic>()
                .WithPropertyName(c => c.Month, "month")
                .WithPropertyName(c => c.Num, "num")
                .WithPropertyName(c => c.Link, "link")
                .WithPropertyName(c => c.Year, "year")
                .WithPropertyName(c => c.News, "news")
                .WithPropertyName(c => c.SafeTitle, "safe_title")
                .WithPropertyName(c => c.Transcript, "transcript")
                .WithPropertyName(c => c.AltText, "alt")
                .WithPropertyName(c => c.ImgUrl, "img")
                .WithPropertyName(c => c.Title, "title")
                .WithPropertyName(c => c.Day, "day");
        });

        return services;
    }
}