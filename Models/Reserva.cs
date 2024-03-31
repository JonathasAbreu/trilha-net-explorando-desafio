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

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a capacidade é maior ou igual ao número de hóspedes
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception($"A suíte reservada não suporta a quantidade de hóspedes informada. Capacidade da suíte: {Suite.Capacidade}. Número de hóspedes: {hospedes.Count}");
            }
            // Adiciona os hóspedes à lista
        }


        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula o valor da diária sem desconto
            decimal valorDiaria = DiasReservados * Suite.ValorDiaria;

            // Aplica desconto se o número de dias reservados for maior ou igual a 10
            if (DiasReservados >= 10)
            {
                decimal valorComDesconto = valorDiaria * 0.10M;
                valorDiaria -= valorComDesconto; // Subtrai o valor do desconto do valor da diária
            }

            return valorDiaria;
        }
    }
}