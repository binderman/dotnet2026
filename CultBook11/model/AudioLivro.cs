namespace model;

using System.Globalization;
using System.Text;

public class AudioLivro : Livro
{
    public double TempoDuracao { get; set; }
    public string Narrador { get; set; }

    public AudioLivro(string isbn, string titulo, string descricao, string autor,
                      int estoque, double preco, string categoria,
                      double tempoDuracao, string narrador)
        : base(isbn, titulo, descricao, autor, estoque, preco, categoria)
    {
        TempoDuracao = tempoDuracao;
        Narrador = narrador;
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
        sb.Append("TempoDuracao: ");
        sb.Append(TempoDuracao);
        sb.Append(Environment.NewLine);
        sb.Append("Narrador: ");
        sb.Append(Narrador);
        return sb.ToString();
    }
}
