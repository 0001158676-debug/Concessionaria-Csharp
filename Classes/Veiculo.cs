using System;
using System.Collections.Generic;
using Concessionaria.Persistencia;

namespace Concessionaria.Classes
{
    public class Veiculo
    {
        public string Modelo { get; set; }
        public string Placa { get; set; }

        /// <summary>
        /// Lista todos os veículos cadastrados no sistema.
        /// </summary>
        public static void ListarVeiculos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE VEÍCULOS ===");
            if (GerenciadorDeDados.Dados.Veiculos.Count == 0)
                Console.WriteLine("Nenhum veículo cadastrado.");
            else
                foreach (var v in GerenciadorDeDados.Dados.Veiculos)
                   
                    Console.WriteLine(string.Format("Modelo: {0} | Placa: {1}", v.Modelo, v.Placa));
        }

        /// <summary>
        /// Permite ao usuário cadastrar um novo veículo.
        /// </summary>
        public static void CadastrarVeiculo()
        {
            Console.Clear();
            Console.WriteLine("=== CADASTRO DE VEÍCULO ===");

            Console.Write("Digite o modelo do veículo: ");
            string modelo = Console.ReadLine();

            Console.Write("Digite a placa do veículo: ");
            string placa = Console.ReadLine();

            // Cria e adiciona o novo veículo à lista de dados
            GerenciadorDeDados.Dados.Veiculos.Add(new Veiculo
            {
                Modelo = modelo,
                Placa = placa
            });

            Console.WriteLine("\nVeículo cadastrado com sucesso!");
        }
    }
}


