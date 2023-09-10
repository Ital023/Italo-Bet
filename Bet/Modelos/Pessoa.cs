namespace Bet.Modelos;
    public class Pessoa
    {
        private string Nome { get; set; }

        private int Idade { get; set; }

        private int Cpf { get; set; }

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

        public string SetNome(string Nome)
        {
            return Nome;
        }

        public int SetIdade(int Idade)
        {
            return Idade;
        }

        public int SetCpf(int Cpf)
        {
            return Cpf;
        }


}

