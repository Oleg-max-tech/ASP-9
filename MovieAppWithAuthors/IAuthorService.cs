using System.Collections.Generic;

public interface IAuthorService
{
    IEnumerable<AuthorDto> GetAllAuthors();
    AuthorDto GetAuthorById(int id);
    AuthorDto AddAuthor(AuthorDto author);
    void DeleteAuthor(int id);
}