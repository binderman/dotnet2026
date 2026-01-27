namespace exemplo.model;

// ContaEspecial herda de ContaCorrente
// ContaEspecial é a subclasse (classe filha, classe derivada)
// ContaCorrente é a superclasse (classe mãe, classe base)
public class ContaEspecial : ContaCorrente
{

    public double Limite { get; set; }

    public ContaEspecial() : base(1, "Sem Cliente ainda", "0000")
    {
        Limite = 0.0;
    }

    public ContaEspecial(int numero, string titular, string senha, double limite) 
        : base(numero, titular, senha)
    {
        Limite = limite;
    }

    public override void Sacar(double valor)
    {
        if (valor <= (ConsultarSaldo() + Limite))
        {
            Saldo -= valor;
        }
    }

    public override double ConsultarSaldo()
    {
        Console.WriteLine("Consultando saldo da Conta Especial");
        return Saldo + Limite;
    }
}
