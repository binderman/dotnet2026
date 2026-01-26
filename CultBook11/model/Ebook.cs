namespace model;

using System.Globalization;
using System.Text;

public class Ebook : Livro
{
    public double TamanhoMB { get; set; }

    public Ebook(string isbn, string titulo, string descricao, string autor,
                 int estoque, double preco, string categoria,
                 double tamanhoMB)
        : base(isbn, titulo, descricao, autor, estoque, preco, categoria)
    {
        TamanhoMB = tamanhoMB;
    }

    public override double CalcularPrecoTotal()
    {
        return Preco;
    }

    public override string ToStringFormatted(CultureInfo cultura)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToStringFormatted(cultura));
        sb.Append(Environment.NewLine);
        sb.Append("TamanhoMB: ");
        sb.Append(TamanhoMB);
        return sb.ToString();
    }
}
