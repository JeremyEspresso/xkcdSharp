using Remora.Results;
using XkcdSharp.API.Objects;

namespace XkcdSharp.API.Rest;

public interface IXkcdRestAPI
{
    Task<Result<Comic>> GetCurrentComic();

    Task<Result<Comic>> GetComic(int num);
}