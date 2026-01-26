using model;
using System.Globalization;

namespace controller.console;

public class LivroController
{
    private List<Livro> _livros;

    public LivroController()
    {
        _livros = new List<Livro>
        {
            new LivroFisico("978-3-16-148410-0", "O Senhor dos Anéis", "Uma épica aventura na Terra Média.", "J.R.R. Tolkien", 10, 59.90, "Fantasia", 0.8, 15.00),
            new LivroFisico("978-0-7432-7356-5", "O Código Da Vinci", "Um thriller de mistério envolvendo arte e história.", "Dan Brown", 5, 39.90, "Suspense", 0.5, 12.00),
            new LivroFisico("978-1-56619-909-4", "1984", "Um romance distópico sobre vigilância e totalitarismo.", "George Orwell", 8, 29.90, "Ficção Científica", 0.4, 10.00),
            new LivroFisico("978-0-452-28423-4", "Orgulho e Preconceito", "Um clássico romance sobre amor e sociedade.", "Jane Austen", 7, 24.90, "Romance", 0.3, 8.00),
            new LivroFisico("978-0-14-044913-6", "Crime e Castigo", "Um mergulho profundo na mente de um assassino.", "Fiódor Dostoiévski", 4, 34.90, "Ficção", 0.6, 13.00),
            new AudioLivro("978-0-06-231609-7", "Sapiens (Audiobook)", "Uma breve história da humanidade.", "Yuval Noah Harari", 6, 79.90, "História", 15.5, "João Silva"),
            new AudioLivro("978-85-359-1419-9", "O Alquimista (Audiobook)", "Jornada espiritual de Santiago.", "Paulo Coelho", 9, 49.90, "Ficção", 6.2, "Maria Souza"),
            new AudioLivro("978-0-525-43314-8", "Becoming (Audiobook)", "Memórias de Michelle Obama.", "Michelle Obama", 5, 69.90, "Biografia", 19.0, "Ana Martins"),
            new Ebook("978-1-23-456789-0", "A Arte da Guerra", "Tratado militar sobre estratégia e táticas.", "Sun Tzu", 15, 19.90, "Filosofia", 2.5),
            new Ebook("978-1-11-222333-4", "O Poder do Hábito", "Como os hábitos funcionam e como mudá-los.", "Charles Duhigg", 12, 29.90, "Autoajuda", 3.2)
        };
    }

    public void BuscarLivros(CultureInfo cultura)
    {
        foreach (var livro in _livros)
        {
            Console.WriteLine(livro.ToStringFormatted(cultura));
        }
    }

    public Livro? BuscarPorIsbn(string isbn)
    {
        return _livros.Find(l => l.Isbn.Equals(isbn));
    }
}
