namespace model;

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

    public override string ToString()
    {
        return string.Join(Environment.NewLine,
            base.ToString(),
            $"Peso: {Peso}",
            $"ValorFrete: {ValorFrete}");
    }
}
