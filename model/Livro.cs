namespace model;

public class Livro
{
    public string Isbn { get; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Autor { get; set; }
    public int Estoque { get; set; }
    public double Preco { get; set; }
    public string Categoria { get; set; }

    public Livro(string isbn, string titulo, string descricao, string autor,
                         int estoque, double preco, string categoria)
    {
        Isbn = isbn;
        Titulo = titulo;
        Descricao = descricao;
        Autor = autor;
        Estoque = estoque;
        Preco = preco;
        Categoria = categoria;
    }

    public void Mostrar()
    {
        Console.WriteLine("=== Livro ===");
        Console.WriteLine($"ISBN: {Isbn}");
        Console.WriteLine($"Titulo: {Titulo}");
        Console.WriteLine($"Descricao: {Descricao}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Estoque: {Estoque}");
        Console.WriteLine($"Preco: {Preco}");
        Console.WriteLine($"Categoria: {Categoria}");
    }
}