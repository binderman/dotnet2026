namespace service;

using System.Text.Json;

public class Configurador
{
    public string Idioma { get; set; }
    public string Regiao { get; set; }
    public string ArquivoAjuda { get; set; }

    public Configurador()
    {
        Idioma = "pt-BR";
        Regiao = "pt-BR";
        ArquivoAjuda = "ajuda.txt";
        
        CarregarConfiguracao();
    }

    private void CarregarConfiguracao()
    {
        try
        {
            string caminhoConfig = "config.json";
            
            if (File.Exists(caminhoConfig))
            {
                string jsonString = File.ReadAllText(caminhoConfig);
                var config = JsonSerializer.Deserialize<ConfiguracaoJson>(jsonString);
                
                if (config != null)
                {
                    Idioma = config.idioma ?? "pt-BR";
                    Regiao = config.regiao ?? "pt-BR";
                    ArquivoAjuda = config.arquivoAjuda ?? "ajuda.txt";
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar configuração: {ex.Message}");
            Console.WriteLine("Usando configurações padrão.");
        }
    }

    private class ConfiguracaoJson
    {
        public string? idioma { get; set; }
        public string? regiao { get; set; }
        public string? arquivoAjuda { get; set; }
    }
}
