namespace model;

using System.Globalization;
using System.Text;

public class LivroFisico : Livro
{
    public double Peso { get; set; }
    public double ValorFrete { get; set; }

    public LivroFisico(string isbn, string titulo, string descricao, string autor,
                       int estoque, double preco, string categoria,
                       double peso, double valorFrete)
        : base(isbn, titulo, descricao, autor, estoque, preco, categoria)
    {
        Peso = peso;
        ValorFrete = valorFrete;
    }

    public override double CalcularPrecoTotal()
    {
        return Preco + ValorFrete;
    }

    public override string ToStringFormatted(CultureInfo cultura)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToStringFormatted(cultura));
        sb.Append(Environment.NewLine);
        sb.Append("Peso: ");
        sb.Append(Peso);
        sb.Append(Environment.NewLine);
        sb.Append("ValorFrete: ");
        sb.Append(ValorFrete.ToString("C", cultura));
        return sb.ToString();
    }
}
