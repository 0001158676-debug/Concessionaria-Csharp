using System;
using Concessionaria.Persistencia;

namespace Concessionaria.Classes
{
    public class Atividade
    {
        public string Tipo { get; set; }
        public string Cliente { get; set; }
        public string Veiculo { get; set; }
        public string Vendedor { get; set; }
        public DateTime Data { get; set; }

        public static void RealizarAtividade(string tipo)
        {
            Console.Clear();
            Console.WriteLine("=== VENDA DE VEÍCULO ===");

            Console.Write("Nome do cliente: ");
            string cliente = Console.ReadLine();

            Console.Write("Modelo do veículo: ");
            string veiculo = Console.ReadLine();

            Console.Write("Nome do vendedor: ");
            string vendedor = Console.ReadLine();

            GerenciadorDeDados.Dados.Atividades.Add(new Atividade
            {
                Tipo = tipo,
                Cliente = cliente,
                Veiculo = veiculo,
                Vendedor = vendedor,
                Data = DateTime.Now
            });

            
            Console.WriteLine(string.Format("\n{0} registrada com sucesso!", tipo));
        }
    }
}