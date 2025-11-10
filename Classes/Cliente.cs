using System;
using System.Collections.Generic;
using Concessionaria.Persistencia;

namespace Concessionaria.Classes
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE CLIENTES ===");
            if (GerenciadorDeDados.Dados.Clientes.Count == 0)
                Console.WriteLine("Nenhum cliente cadastrado.");
            else
                foreach (var c in GerenciadorDeDados.Dados.Clientes)
                    Console.WriteLine("Nome: {c.Nome} | CPF: {c.Cpf}");
        }
    }
}

