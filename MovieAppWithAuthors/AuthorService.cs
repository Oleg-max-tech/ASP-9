using AutoMapper;

namespace MovieAppWithAuthors
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            var authors = _context.Authors.ToList();
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public AuthorDto GetAuthorById(int id)
        {
            var author = _context.Authors.Find(id);
            return author == null ? null : _mapper.Map<AuthorDto>(author);
        }

        public AuthorDto AddAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _context.Authors.Add(author);
            _context.SaveChanges();
            return _mapper.Map<AuthorDto>(author);
        }

        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
