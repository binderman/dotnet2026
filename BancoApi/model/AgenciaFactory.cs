namespace exemplo.model;

public class AgenciaFactory
{
    public static Agencia CriarAgenciaComMockupData()
    {
        var agencia = new Agencia();

        // Criando contas correntes
        var conta1 = new ContaCorrente(1001, "João Silva", "1234");
        conta1.Depositar(1500.00);
        
        var conta2 = new ContaCorrente(1002, "Maria Santos", "5678");
        conta2.Depositar(2500.00);
        
        var conta3 = new ContaCorrente(1003, "Pedro Oliveira", "9012");
        conta3.Depositar(800.00);

        // Criando contas especiais
        var contaEspecial1 = new ContaEspecial(2001, "Ana Costa", "3456", 1000.00);
        contaEspecial1.Depositar(3000.00);
        
        var contaEspecial2 = new ContaEspecial(2002, "Carlos Souza", "7890", 2000.00);
        contaEspecial2.Depositar(5000.00);

        var contaEspecial3 = new ContaEspecial(2003, "Juliana Lima", "1111", 1500.00);
        contaEspecial3.Depositar(1200.00);

        // Adicionando contas à agência
        agencia.AbrirConta(conta1);
        agencia.AbrirConta(conta2);
        agencia.AbrirConta(conta3);
        agencia.AbrirConta(contaEspecial1);
        agencia.AbrirConta(contaEspecial2);
        agencia.AbrirConta(contaEspecial3);

        return agencia;
    }
}
