namespace XkcdSharp.API.Objects;

public interface IComic
{
    string Month { get; }

    int Num { get; }

    string Link { get; }

    string Year { get; }

    string News { get; }

    string SafeTitle { get; }

    string Transcript { get; }

    string AltText { get; }

    string ImgUrl { get; }

    string Title { get; }

    string Day { get; }
}