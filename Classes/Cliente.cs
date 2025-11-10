namespace Concessionaria.Classes
{
    [Serializable]
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Cliente() { }

        public Cliente(string nome, string cpf, string telefone, string email)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
        }

        public override string ToString()
        {
            return "{Nome} | CPF: {Cpf} | Telefone: {Telefone} | E-mail: {Email}";
        }
    }
}

