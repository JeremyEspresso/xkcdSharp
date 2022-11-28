using Remora.Rest;
using Remora.Results;
using XkcdSharp.API.Objects;

namespace XkcdSharp.API.Rest;

public class XkcdRestAPI : IXkcdRestAPI
{
    private const string BaseUrl = "https://xkcd.com";
    private readonly RestHttpClient<NotFoundError> _restClient;

    public XkcdRestAPI(RestHttpClient<NotFoundError> restClient)
    {
        _restClient = restClient;
    }

    public async Task<Result<Comic>> GetCurrentComic()
    {
        return await _restClient.GetAsync<Comic>($"{BaseUrl}/info.0.json");
    }

    public async Task<Result<Comic>> GetComic(int num)
    {
        return await _restClient.GetAsync<Comic>($"{BaseUrl}/{num}/info.0.json");
    }
}