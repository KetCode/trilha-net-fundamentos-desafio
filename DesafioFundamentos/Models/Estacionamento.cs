using System.Text.RegularExpressions;
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
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            
            while (true){
                Console.WriteLine("\nDigite a placa do veículo para estacionar: (as placas precisam ser validas no padrão XXX0X00 ou XXX0000)");
                string placa = Console.ReadLine();
                
                if (ValidarVeiculo(placa)){
                    veiculos.Add(placa);
                    break;
                } else {
                    Console.WriteLine("Placa inválida");
                }
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("\nDigite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("\nDigite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = 0;
                decimal valorTotal = 0; 

                horas = int.Parse(Console.ReadLine());
                valorTotal = (precoInicial + (precoPorHora * horas));
                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*

                veiculos.Remove(placa);
                Console.WriteLine($"\nO veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}\n");
            }
            else
            {
                Console.WriteLine("\nDesculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("\nOs veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                for(int i = 0; i < veiculos.Count; i++){
                    Console.WriteLine($"{veiculos[i]}");
                } 
            }
            else
            {
                Console.WriteLine("\nNão há veículos estacionados.");
            }
        }

        public bool ValidarVeiculo(string placa)
        {
            string placaValida = @"^[a-zA-Z]{3}\d[a-zA-Z]\d{2}$";
            string placaValidaMercosul = @"[a-zA-Z]{3}\d{4}$";
            return Regex.IsMatch(placa, placaValida) || Regex.IsMatch(placa, placaValidaMercosul);
        }
    }
}
