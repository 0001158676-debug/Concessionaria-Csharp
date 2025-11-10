namespace Concessionaria.Classes
{
    [Serializable]
    public class Veiculo
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public double Preco { get; set; }

        public Veiculo() { }

        public Veiculo(string modelo, string marca, int ano, double preco)
        {
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            Preco = preco;
        }

        public override string ToString()
        {
            return "{Marca} {Modelo} ({Ano}) - R$ {Preco:N2}";
        }
    }
}

