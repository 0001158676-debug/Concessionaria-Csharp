﻿using System;
using Concessionaria.Classes;
using Concessionaria.Persistencia;

namespace Concessionaria
{
    class Program
    {
        static void Main(string[] args)
        {
            GerenciadorDeDados.CarregarDados();
            Console.Clear();

            Console.WriteLine("=== SISTEMA DA CONCESSIONÁRIA ===\n");

            if (!FazerLogin())
                return;

            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1 - Vender veículo");
                Console.WriteLine("2 - Reservar veículo");
                Console.WriteLine("3 - Adquirir veículo");
                Console.WriteLine("4 - Listar clientes");
                Console.WriteLine("5 - Listar veículos");
                Console.WriteLine("6 - Listar vendedores");
                Console.WriteLine("0 - Sair");
                Console.Write("\nEscolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Atividade.RealizarAtividade("Venda");
                        break;
                    case 2:
                        Atividade.RealizarAtividade("Reserva");
                        break;
                    case 3:
                        Atividade.RealizarAtividade("Aquisição");
                        break;
                    case 4:
                        Cliente.ListarClientes();
                        break;
                    case 5:
                        Veiculo.ListarVeiculos();
                        break;
                    case 6:
                        Vendedor.ListarVendedores();
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);

            GerenciadorDeDados.SalvarDados();
            Console.WriteLine("\nSaindo do sistema...");
        }

        static bool FazerLogin()
        {
            Console.Write("Usuário: ");
            string usuario = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            if (usuario == "admin" && senha == "1234")
            {
                Console.WriteLine("\nLogin realizado com sucesso!");
                System.Threading.Thread.Sleep(1000);
                return true;
            }
            else
            {
                Console.WriteLine("\nUsuário ou senha incorretos!");
                return false;
            }
        }
    }
}


