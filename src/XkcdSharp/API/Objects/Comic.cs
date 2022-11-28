namespace XkcdSharp.API.Objects;

public record Comic
(
    string Month,
    int Num,
    string Link,
    string Year,
    string News,
    string SafeTitle,
    string Transcript,
    string AltText,
    string ImgUrl,
    string Title,
    string Day
) : IComic;