namespace model;

using System.Globalization;
using System.Text;

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
        return ToStringFormatted(new CultureInfo("pt-BR"));
    }

    public virtual string ToStringFormatted(CultureInfo cultura)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("=== Livro ===");
        sb.Append(Environment.NewLine);
        sb.Append("ISBN: ");
        sb.Append(Isbn);
        sb.Append(Environment.NewLine);
        sb.Append("Titulo: ");
        sb.Append(Titulo);
        sb.Append(Environment.NewLine);
        sb.Append("Descricao: ");
        sb.Append(Descricao);
        sb.Append(Environment.NewLine);
        sb.Append("Autor: ");
        sb.Append(Autor);
        sb.Append(Environment.NewLine);
        sb.Append("Estoque: ");
        sb.Append(Estoque);
        sb.Append(Environment.NewLine);
        sb.Append("Preco: ");
        sb.Append(Preco.ToString("C", cultura));
        sb.Append(Environment.NewLine);
        sb.Append("Categoria: ");
        sb.Append(Categoria);
        return sb.ToString();
    }
}