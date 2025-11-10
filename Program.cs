using System;
using Concessionaria.Classes;
using Concessionaria.Persistencia;

namespace Concessionaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sistema da Concessionária";

            // Tela de login
            Console.WriteLine("=== SISTEMA DA CONCESSIONÁRIA ===\n");
            Console.Write("Usuário: ");
            string usuario = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = LerSenha();

            if (usuario != "admin" || senha != "1234")
            {
                Console.WriteLine("\nUsuário ou senha incorretos!");
                return;
            }

            // Menu principal
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1 - Registrar Venda");
                Console.WriteLine("2 - Registrar Reserva");
                Console.WriteLine("3 - Registrar Aquisição");
                Console.WriteLine("4 - Listar Clientes");
                Console.WriteLine("5 - Listar Vendedores");
                Console.WriteLine("6 - Listar Veículos");
                Console.WriteLine("7 - Listar Atividades");
                Console.WriteLine("0 - Sair");
                Console.Write("\nEscolha uma opção: ");

                int.TryParse(Console.ReadLine(), out opcao);
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        Atividade.RealizarAtividade("Venda");
                        GerenciadorDeDados.Salvar();
                        Pausar();
                        break;
                    case 2:
                        Atividade.RealizarAtividade("Reserva");
                        GerenciadorDeDados.Salvar();
                        Pausar();
                        break;
                    case 3:
                        Atividade.RealizarAtividade("Aquisição");
                        GerenciadorDeDados.Salvar();
                        Pausar();
                        break;
                    case 4:
                        Cliente.ListarClientes();
                        Pausar();
                        break;
                    case 5:
                        Vendedor.ListarVendedores();
                        Pausar();
                        break;
                    case 6:
                        Veiculo.ListarVeiculos();
                        Pausar();
                        break;
                    case 7:
                        ListarAtividades();
                        Pausar();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Pausar();
                        break;
                }
            } while (opcao != 0);
        }

        static void ListarAtividades()
        {
            Console.WriteLine("=== LISTA DE ATIVIDADES ===");
            if (GerenciadorDeDados.Dados.Atividades.Count == 0)
                Console.WriteLine("Nenhuma atividade registrada.");
            else
                foreach (var a in GerenciadorDeDados.Dados.Atividades)
                    Console.WriteLine($"{a.Tipo} | Cliente: {a.Cliente} | Veículo: {a.Veiculo} | Vendedor: {a.Vendedor} | Data: {a.Data}");
        }

        static void Pausar()
        {
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        static string LerSenha()
        {
            string senha = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    senha += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && senha.Length > 0)
                {
                    senha = senha.Substring(0, (senha.Length - 1));
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return senha;
        }
    }
}

