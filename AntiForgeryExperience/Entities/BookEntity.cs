namespace AntiForgeryExperience.Entities;

public class BookEntity : IDatabaseEntity
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Автор
    /// </summary>
    public string? Author { get; set; }

    /// <summary>
    /// Издатель
    /// </summary>
    public string? Publisher { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Количество страниц
    /// </summary>
    public int PagesQuantity { get; set; }

    /// <summary>
    /// Дата выпуска первого тиража
    /// </summary>
    public DateTime ReleaseDate { get; set; }
}