namespace AntiForgeryExperience.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _appDbContext;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="appDbContext">Экземпляр DbContext для EF-а</param>
    public BookRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<BookEntity>> GetAllAsync()
    {
        return await _appDbContext.Books.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<BookEntity?> GetByIdAsync(int id)
    {
        return await _appDbContext.Books.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task CreateAsync(BookEntity book)
    {
        await _appDbContext.Books.AddAsync(book);

        await _appDbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdateAsync(BookEntity book)
    {
        _appDbContext.Books.Attach(book);
        _appDbContext.Entry(book).State = EntityState.Modified;

        await _appDbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int id)
    {
        var book = await _appDbContext.Books.FindAsync(id);
        if (book is not null)
        {
            _appDbContext.Books.Remove(book);
        }

        await _appDbContext.SaveChangesAsync();
    }
}