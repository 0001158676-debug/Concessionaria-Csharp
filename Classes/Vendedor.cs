using System;
using System.Collections.Generic;
using Concessionaria.Persistencia;

namespace Concessionaria.Classes
{
    public class Vendedor
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }

        /// <summary>
        /// Lista todos os vendedores cadastrados no sistema.
        /// </summary>
        public static void ListarVendedores()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE VENDEDORES ===");
            if (GerenciadorDeDados.Dados.Vendedores.Count == 0)
                Console.WriteLine("Nenhum vendedor cadastrado.");
            else
                foreach (var v in GerenciadorDeDados.Dados.Vendedores)
                    
                    Console.WriteLine(string.Format("Nome: {0} | Matrícula: {1}", v.Nome, v.Matricula));
        }

        /// <summary>
        /// Permite ao usuário cadastrar um novo vendedor.
        /// </summary>
        public static void CadastrarVendedor()
        {
            Console.Clear();
            Console.WriteLine("=== CADASTRO DE VENDEDOR ===");

            Console.Write("Digite o nome do vendedor: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a matrícula do vendedor: ");
            string matricula = Console.ReadLine();

            // Cria e adiciona o novo vendedor à lista de dados
            GerenciadorDeDados.Dados.Vendedores.Add(new Vendedor
            {
                Nome = nome,
                Matricula = matricula
            });

            Console.WriteLine("\nVendedor cadastrado com sucesso!");
        }
    }
}

