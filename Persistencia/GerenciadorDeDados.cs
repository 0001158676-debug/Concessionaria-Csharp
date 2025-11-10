using System.Text.Json;
using Concessionaria.Classes;

namespace Concessionaria.Persistencia
{
    public static class GerenciadorDeDados
    {
        private const string CaminhoClientes = "clientes.json";
        private const string CaminhoVendedores = "vendedores.json";
        private const string CaminhoVeiculos = "veiculos.json";
        private const string CaminhoAtividades = "atividades.json";

        public static List<Cliente> Clientes { get; private set; } = new();
        public static List<Vendedor> Vendedores { get; private set; } = new();
        public static List<Veiculo> Veiculos { get; private set; } = new();
        public static List<Atividade> Atividades { get; private set; } = new();

        public static void Inicializar()
        {
            Clientes = Carregar<Cliente>(CaminhoClientes) ?? new List<Cliente>
            {
                new Cliente("João Silva", "111.222.333-44", "(31) 98877-6655", "joao@email.com"),
                new Cliente("Maria Souza", "555.666.777-88", "(31) 97788-1122", "maria@email.com"),
                new Cliente("Carlos Pereira", "999.888.777-66", "(31) 91234-5678", "carlos@email.com")
            };

            Vendedores = Carregar<Vendedor>(CaminhoVendedores) ?? new List<Vendedor>
            {
                new Vendedor("Lucas Andrade", "V001", "(31) 98888-1234", 0.05),
                new Vendedor("Fernanda Lima", "V002", "(31) 98777-4321", 0.06)
            };

            Veiculos = Carregar<Veiculo>(CaminhoVeiculos) ?? new List<Veiculo>
            {
                new Veiculo("Civic", "Honda", 2022, 145000),
                new Veiculo("Corolla", "Toyota", 2023, 150000),
                new Veiculo("Onix", "Chevrolet", 2021, 89000),
                new Veiculo("Compass", "Jeep", 2024, 189000)
            };

            Atividades = Carregar<Atividade>(CaminhoAtividades) ?? new List<Atividade>();
        }

        private static List<T>? Carregar<T>(string caminho)
        {
            if (File.Exists(caminho))
            {
                string json = File.ReadAllText(caminho);
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            return null;
        }

        public static void SalvarTudo()
        {
            Salvar(CaminhoClientes, Clientes);
            Salvar(CaminhoVendedores, Vendedores);
            Salvar(CaminhoVeiculos, Veiculos);
            Salvar(CaminhoAtividades, Atividades);
        }

        private static void Salvar<T>(string caminho, List<T> dados)
        {
            string json = JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminho, json);
        }
    }
}

