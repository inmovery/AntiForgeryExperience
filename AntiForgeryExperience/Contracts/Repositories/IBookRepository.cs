namespace AntiForgeryExperience.Contracts.Repositories;

public interface IBookRepository
{
    /// <summary>
    /// Получение списка всех книг
    /// </summary>
    /// <returns>Список книг</returns>
    public Task<IEnumerable<BookEntity>> GetAllAsync();

    /// <summary>
    /// Получение экземпляра книги по её идентификатору
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    /// <returns>Экземпляр книги</returns>
    public Task<BookEntity?> GetByIdAsync(int id);

    /// <summary>
    /// Создание новой книги
    /// </summary>
    /// <param name="book">Экземпляр создаваемой книги</param>
    public Task CreateAsync(BookEntity book);

    /// <summary>
    /// Обновление книги
    /// </summary>
    /// <param name="book">Экземпляр книги</param>
    public Task UpdateAsync(BookEntity book);

    /// <summary>
    /// Удаление книги
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    public Task DeleteAsync(int id);
}