namespace model;

public abstract class Livro
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

    public abstract double CalcularPrecoTotal();

    public override string ToString()
    {
        return string.Join(Environment.NewLine,
            "=== Livro ===",
            $"ISBN: {Isbn}",
            $"Titulo: {Titulo}",
            $"Descricao: {Descricao}",
            $"Autor: {Autor}",
            $"Estoque: {Estoque}",
            $"Preco: {Preco}",
            $"Categoria: {Categoria}");
    }
}