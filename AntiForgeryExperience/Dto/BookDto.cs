namespace AntiForgeryExperience.Dto;

public record BookDto(string Title, string Author, string Publisher,
    string Country, int PagesQuantity, DateTime ReleaseDate);