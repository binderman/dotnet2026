namespace model;

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

    public override string ToString()
    {
        return string.Join(Environment.NewLine,
            base.ToString(),
            $"TamanhoMB: {TamanhoMB}");
    }
}
