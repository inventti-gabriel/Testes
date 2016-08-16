namespace TesteTDD
{
    public interface IRegraDeCalculo
    {
        double Calcula(Funcionario f);
    }
    public class DezOuVintePorCento : IRegraDeCalculo
    {
        public double Calcula(Funcionario funcionario)
        {
            if (funcionario.Salario > 3000)
            {
                return funcionario.Salario*0.8;
            }
            return funcionario.Salario*0.9;
        }
    }
    public class QuinzeOuVinteCincoPorCento : IRegraDeCalculo
    {
        public double Calcula(Funcionario funcionario)
        {
            if (funcionario.Salario < 2500)
            {
                return funcionario.Salario*0.85;
            }
            return funcionario.Salario*0.75;
        }
    }

    public class Cargo
    {
        public static Cargo DESENVOLVEDOR => new Cargo(new DezOuVintePorCento());

        public static Cargo DBA => new Cargo(new QuinzeOuVinteCincoPorCento());

        public static Cargo TESTADOR => new Cargo(new QuinzeOuVinteCincoPorCento());

        public IRegraDeCalculo Regra
        {
            get;
            private set;
        }
        private
        Cargo(IRegraDeCalculo regra)
        {
            this.Regra = regra;
        }
    }

    public class Funcionario
    {
        public string Nome
        {
            get;
            private set;
        }

        public double Salario { get; private set; }

        public Cargo Cargo { get; private set; }

        public Funcionario(string nome, double salario, Cargo cargo)
        {
            this.Nome = nome;
            this.Salario = salario;
            this.Cargo = cargo;
        }
    }
}