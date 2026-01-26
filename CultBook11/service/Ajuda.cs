namespace service;

using System.Text;

public class Ajuda
{
    public string Texto { get; private set; }

    public Ajuda(string arquivo)
    {
        Texto = "";
        CarregarAjuda(arquivo);
    }

    private void CarregarAjuda(string arquivo)
    {
        try
        {
            if (File.Exists(arquivo))
            {
                Texto = File.ReadAllText(arquivo, Encoding.UTF8);
            }
            else
            {
                Texto = "Arquivo de ajuda não encontrado.";
                Console.WriteLine($"Aviso: Arquivo '{arquivo}' não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Texto = $"Erro ao carregar ajuda: {ex.Message}";
            Console.WriteLine($"Erro ao carregar arquivo de ajuda: {ex.Message}");
        }
    }
}
