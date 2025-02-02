using System.Security.Cryptography.X509Certificates;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes, Suite suite)
        {
            // Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
                Suite = suite;
            }
            else
            {
                //  Retorna uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception("Capacidade insuficiente para acomodar todos os hóspedes na suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula e retorna o valor da diária
            decimal valor = DiasReservados * Suite.ValorDiaria;

            //  Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor -= valor *0.10M;
            }

            return valor;
        }
    }
}