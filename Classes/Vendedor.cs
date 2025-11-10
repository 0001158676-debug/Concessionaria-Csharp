namespace Concessionaria.Classes
{
    [Serializable]
    public class Vendedor
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Telefone { get; set; }
        public double Comissao { get; set; }

        public Vendedor() { }

        public Vendedor(string nome, string codigo, string telefone, double comissao)
        {
            Nome = nome;
            Codigo = codigo;
            Telefone = telefone;
            Comissao = comissao;
        }

        public override string ToString()
        {
            return "{Nome} | Código: {Codigo} | Telefone: {Telefone} | Comissão: {Comissao * 100}%";
        }
    }
}

