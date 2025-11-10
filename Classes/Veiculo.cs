using System;
using System.Collections.Generic;
using Concessionaria.Persistencia;

namespace Concessionaria.Classes
{
    public class Veiculo
    {
        public string Modelo { get; set; }
        public string Placa { get; set; }

        public static void ListarVeiculos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE VEÍCULOS ===");
            if (GerenciadorDeDados.Dados.Veiculos.Count == 0)
                Console.WriteLine("Nenhum veículo cadastrado.");
            else
                foreach (var v in GerenciadorDeDados.Dados.Veiculos)
                    Console.WriteLine("Modelo: {v.Modelo} | Placa: {v.Placa}");
        }
    }
}


