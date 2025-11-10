using System;
using System.Collections.Generic;
using Concessionaria.Persistencia;

namespace Concessionaria.Classes
{
    public class Vendedor
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }

        public static void ListarVendedores()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE VENDEDORES ===");
            if (GerenciadorDeDados.Dados.Vendedores.Count == 0)
                Console.WriteLine("Nenhum vendedor cadastrado.");
            else
                foreach (var v in GerenciadorDeDados.Dados.Vendedores)
                    Console.WriteLine("Nome: {v.Nome} | Matrícula: {v.Matricula}");
        }
    }
}
