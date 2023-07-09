namespace AntiForgeryExperience.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BooksController(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync();

        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
            return NoContent();

        return Ok(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateBookAsync([FromForm] BookDto bookDto)
    {
        var book = _mapper.Map<BookEntity>(bookDto);

        await _bookRepository.CreateAsync(book);

        return Created("/", bookDto);
    }

    [HttpPut("{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateBookAsync(int id, [FromBody] BookDto bookDto)
    {
        var book = _mapper.Map<BookEntity>(bookDto);
        book.Id = id;

        await _bookRepository.UpdateAsync(book);

        return Ok();
    }

    [HttpDelete("{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateBookAsync(int id)
    {
        await _bookRepository.DeleteAsync(id);

        return NoContent();
    }
}