using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Concessionaria.Classes;

namespace Concessionaria.Persistencia
{
    /// <summary>
    /// Gerencia o carregamento e salvamento dos dados do sistema em um arquivo JSON.
    /// </summary>
    public static class GerenciadorDeDados
    {
        public static string CaminhoArquivo = "Dados/dados.json";

        public static DadosSistema Dados { get; set; } = new DadosSistema();

        /// <summary>
        /// Tenta carregar os dados do sistema a partir do arquivo JSON.
        /// Se o arquivo não existir, inicia com um novo objeto DadosSistema.
        /// </summary>
        public static void CarregarDados()
        {
            if (File.Exists(CaminhoArquivo))
            {
                string json = File.ReadAllText(CaminhoArquivo);
                Dados = JsonSerializer.Deserialize<DadosSistema>(json) ?? new DadosSistema();
            }
        }

        /// <summary>
        /// Salva o estado atual dos dados do sistema no arquivo JSON, formatado para melhor leitura.
        /// </summary>
        public static void SalvarDados()
        {
            // Garante que o diretório existe antes de tentar escrever o arquivo
            string diretorio = Path.GetDirectoryName(CaminhoArquivo);
            if (!string.IsNullOrEmpty(diretorio) && !Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            string json = JsonSerializer.Serialize(Dados, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(CaminhoArquivo, json);
        }
    }

    /// <summary>
    /// Classe que armazena todas as listas de dados do sistema (Veículos, Clientes, etc.).
    /// </summary>
    public class DadosSistema
    {
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
        public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
        public List<Atividade> Atividades { get; set; } = new List<Atividade>();
    }
}