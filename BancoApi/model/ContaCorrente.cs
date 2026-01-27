namespace exemplo.model;
public class ContaCorrente
{
    public int Numero { get; set; }
    public string Titular { get; set; }
    protected double Saldo { get; set; }
    public string Senha { get; set; }

    public ContaCorrente() : this(0, senha: "", titular:"")
    {

    }

    public ContaCorrente(int Numero, string titular, string senha)
    {
        this.Numero = Numero;
        Titular = titular;        
        Senha = senha;
        Saldo = 0.0;
    }

    public virtual void Sacar(double valor) 
    {
        if (valor <= 0 || valor > Saldo)
        {
            throw new ArgumentException("Valor de saque inválido");
        }
        Saldo -= valor;
    }

    public void Depositar(double valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor de depósito inválido");
        }
        Saldo += valor;
    }

    public virtual double ConsultarSaldo()
    {
        Console.WriteLine("Consultando saldo da Conta Corrente");
        return Saldo;
    }
}