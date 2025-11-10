﻿using Concessionaria.Classes;
using Concessionaria.Persistencia;

GerenciadorDeDados.Inicializar();

Console.Title = "🏎️ Sistema da Concessionária - InstaSharp";
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("==============================================");
Console.WriteLine("         SISTEMA DE CONCESSIONÁRIA CLI");
Console.WriteLine("==============================================");
Console.ResetColor();

// ==== LOGIN ====
bool logado = false;
while (!logado)
{
    Console.Write("\nUsuário: ");
    string usuario = Console.ReadLine() ?? "";

    Console.Write("Senha: ");
    string senha = LerSenha();

    if (usuario == "Admin" && senha == "1234")
    {
        logado = true;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nLogin realizado com sucesso!\n");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nUsuário ou senha incorretos, tente novamente.");
        Console.ResetColor();
    }
}

// ==== MENU PRINCIPAL ====
int opcao;
do
{
    Console.WriteLine("\n===== MENU PRINCIPAL =====");
    Console.WriteLine("1 - Registrar Venda");
    Console.WriteLine("2 - Registrar Reserva");
    Console.WriteLine("3 - Registrar Aquisição");
    Console.WriteLine("4 - Listar Clientes");
    Console.WriteLine("5 - Listar Vendedores");
    Console.WriteLine("6 - Listar Veículos");
    Console.WriteLine("7 - Listar Atividades");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    int.TryParse(Console.ReadLine(), out opcao);
    Console.WriteLine();

    switch (opcao)
    {
        case 1:
            RegistrarAtividade("Venda");
            break;
        case 2:
            RegistrarAtividade("Reserva");
            break;
        case 3:
            RegistrarAtividade("Aquisição");
            break;
        case 4:
            Listar(GerenciadorDeDados.Clientes);
            break;
        case 5:
            Listar(GerenciadorDeDados.Vendedores);
            break;
        case 6:
            Listar(GerenciadorDeDados.Veiculos);
            break;
        case 7:
            Listar(GerenciadorDeDados.Atividades);
            break;
        case 0:
            Console.WriteLine("Encerrando o sistema...");
            GerenciadorDeDados.SalvarTudo();
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

} while (opcao != 0);

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\nObrigado por usar o sistema da Concessionária!");
Console.ResetColor();

// ================= FUNÇÕES AUXILIARES =================

void RegistrarAtividade(string tipo)
{
    Console.WriteLine($"--- Registro de {tipo} ---");

    var cliente = Escolher("cliente", GerenciadorDeDados.Clientes);
    var vendedor = Escolher("vendedor", GerenciadorDeDados.Vendedores);
    var veiculo = Escolher("veículo", GerenciadorDeDados.Veiculos);

    if (cliente == null || vendedor == null || veiculo == null)
    {
        Console.WriteLine("Erro: seleção inválida.");
        return;
    }

    var atividade = new Atividade(tipo, cliente, veiculo, vendedor);
    GerenciadorDeDados.Atividades.Add(atividade);
    GerenciadorDeDados.SalvarTudo();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n✅ {tipo} registrada com sucesso!");
    Console.ResetColor();
}

T? Escolher<T>(string tipo, List<T> lista)
{
    if (lista.Count == 0)
    {
        Console.WriteLine("Nenhum {tipo} cadastrado.\n");
        return default;
    }

    Console.WriteLine("\nSelecione um {tipo}:");
    for (int i = 0; i < lista.Count; i++)
        Console.WriteLine($"{i + 1} - {lista[i]}");

    Console.Write($"Digite o número do {tipo} desejado: ");
    if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= lista.Count)
        return lista[escolha - 1];

    Console.WriteLine("Opção inválida.\n");
    return default;
}

void Listar<T>(List<T> lista)
{
    if (lista.Count == 0)
    {
        Console.WriteLine("Nenhum registro encontrado.\n");
        return;
    }

    Console.ForegroundColor = ConsoleColor.Yellow;
    foreach (var item in lista)
        Console.WriteLine(item);
    Console.ResetColor();
    Console.WriteLine();
}

string LerSenha()
{
    string senha = "";
    ConsoleKeyInfo tecla;
    do
    {
        tecla = Console.ReadKey(true);
        if (tecla.Key != ConsoleKey.Backspace && tecla.Key != ConsoleKey.Enter)
        {
            senha += tecla.KeyChar;
            Console.Write("*");
        }
        else if (tecla.Key == ConsoleKey.Backspace && senha.Length > 0)
        {
            senha = senha.Substring(0, senha.Length - 1);
            Console.Write("\b \b");
        }
    } while (tecla.Key != ConsoleKey.Enter);

    Console.WriteLine();
    return senha;
}


