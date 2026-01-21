namespace model;

public class ItemDePedido
{
    public int Qtde { get; set; }
    public double Preco { get; set; }
    public Livro Livro { get; set; } 

    public ItemDePedido(Livro livro, int qtde, double preco)
    {
        Livro = livro;
        Qtde = qtde;
        Preco = preco;
    }

    public void Mostrar()
    {
        Console.WriteLine("=== ItemDePedido ===");
        Console.WriteLine($"Qtde: {Qtde}");
        Console.WriteLine($"Preco: {Preco}");
        Console.WriteLine("Livro do item:");
        Livro.Mostrar();
    }
}