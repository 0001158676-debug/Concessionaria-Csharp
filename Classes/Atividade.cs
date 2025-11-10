namespace Concessionaria.Classes
{
    [Serializable]
    public class Atividade
    {
        public string Tipo { get; set; }  // Venda, Reserva, Aquisição
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
        public Vendedor Vendedor { get; set; }
        public DateTime Data { get; set; }

        public Atividade() { }

        public Atividade(string tipo, Cliente cliente, Veiculo veiculo, Vendedor vendedor)
        {
            Tipo = tipo;
            Cliente = cliente;
            Veiculo = veiculo;
            Vendedor = vendedor;
            Data = DateTime.Now;
        }

        public override string ToString()
        {
            return "{Tipo} | Cliente: {Cliente.Nome} | Vendedor: {Vendedor.Nome} | Veículo: {Veiculo.Marca} {Veiculo.Modelo} | Data: {Data}";
        }
    }
}

