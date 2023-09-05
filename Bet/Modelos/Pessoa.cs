namespace Bet.Modelos;
    internal class Pessoa
    {
        public string Nome { get; set; }

        public int Idade { get; set; }

        public int Cpf { get; set; }

        public string GetNome()
        {
            return Nome;
        }

        public int GetIdade()
        {
            return Idade;
        }

        public int GetCpf()
        {
            return Cpf;
        }


}

