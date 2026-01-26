namespace model;

using System.Text;

public class ItemDePedido
{
    public int Qtde { get; set; }
    public double Preco { get; set; }
    public Livro Livro { get; set; } 

    public ItemDePedido(Livro livro, int qtde = 1, double preco = 0)
    {
        Livro = livro;
        Qtde = qtde;
        Preco = preco;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("=== ItemDePedido ===");
        sb.Append(Environment.NewLine);
        sb.Append("Qtde: ");
        sb.Append(Qtde);
        sb.Append(Environment.NewLine);
        sb.Append("Preco: ");
        sb.Append(Preco);
        sb.Append(Environment.NewLine);
        sb.Append("Livro do item:");
        sb.Append(Environment.NewLine);
        sb.Append(Livro.ToString());
        return sb.ToString();
    }
}