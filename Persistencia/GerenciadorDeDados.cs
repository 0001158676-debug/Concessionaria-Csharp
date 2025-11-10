using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Concessionaria.Classes;

namespace Concessionaria.Persistencia
{
    public class BancoDeDados
    {
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
        public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
        public List<Atividade> Atividades { get; set; } = new List<Atividade>();
    }

    public static class GerenciadorDeDados
    {
        private static string caminhoArquivo = "Dados/dados.json";
        public static BancoDeDados Dados { get; private set; } = new BancoDeDados();

        static GerenciadorDeDados()
        {
            Carregar();
        }

        public static void Salvar()
        {
            try
            {
                var json = JsonSerializer.Serialize(Dados, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(caminhoArquivo, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar dados: " + ex.Message);
            }
        }

        public static void Carregar()
        {
            try
            {
                if (File.Exists(caminhoArquivo))
                {
                    var json = File.ReadAllText(caminhoArquivo);
                    var dados = JsonSerializer.Deserialize<BancoDeDados>(json);
                    if (dados != null)
                        Dados = dados;
                }
                else
                {
                    Salvar(); // Cria arquivo se não existir
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar dados: " + ex.Message);
            }
        }
    }
}
