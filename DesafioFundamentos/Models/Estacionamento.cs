namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            // grava a placa em letra maiúscula
            string placaVeiculo = Console.ReadLine().ToUpper();

            // verifica se o número de caracteres é igual a zero, e chama a função para add novamente
            if (placaVeiculo.Length == 0) {
                Console.WriteLine("Placa inválida, por favor digite uma placa válida:");
                AdicionarVeiculo();
            }

            // só vai adicionar uma placa caso o número de caracteres seja superior a zero
            if (placaVeiculo.Length != 0)
                veiculos.Add(placaVeiculo);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string horasInput = "";
                horasInput = Console.ReadLine();

                while (!int.TryParse(horasInput, out int num)) {
                    Console.WriteLine("Número de horas inválido, por favor digite novamente");
                    horasInput = Console.ReadLine();
                }

                int horas = int.Parse(horasInput);
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
