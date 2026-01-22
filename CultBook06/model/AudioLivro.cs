namespace model;

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

    public override string ToString()
    {
        return string.Join(Environment.NewLine,
            base.ToString(),
            $"TempoDuracao: {TempoDuracao}",
            $"Narrador: {Narrador}");
    }
}
