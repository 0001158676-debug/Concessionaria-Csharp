using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Concessionaria.Classes;

namespace Concessionaria.Persistencia
{
    public static class GerenciadorDeDados
    {
        public static string CaminhoArquivo = "Dados/dados.json";

        public static DadosSistema Dados { get; set; } = new DadosSistema();

        public static void CarregarDados()
        {
            if (File.Exists(CaminhoArquivo))
            {
                string json = File.ReadAllText(CaminhoArquivo);
                Dados = JsonSerializer.Deserialize<DadosSistema>(json) ?? new DadosSistema();
            }
        }

        public static void SalvarDados()
        {
            string json = JsonSerializer.Serialize(Dados, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(CaminhoArquivo, json);
        }
    }

    public class DadosSistema
    {
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
        public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
        public List<Atividade> Atividades { get; set; } = new List<Atividade>();
    }
}


