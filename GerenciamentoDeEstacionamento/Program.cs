using System.ComponentModel;
using System.Data.Common;
using System.Net.Http.Headers;
using System.Net.Mail;
using GerenciamentoDeEstacionamento.Common.Models;

class Program
{
    static void Main()
    {
        Vagas vagas = new Vagas();
        bool rodar = true;
        
            Console.Clear();
            Console.WriteLine("\n---Vagas disponiveis Disponibilidade---");
            vagas.VeficarDisponibilidade();
            Console.ReadKey(); 

            while(rodar)
            {
                Console.WriteLine("\n--- Menu de Opções ---");
                Console.WriteLine("1. Verificar Disponibilidade");
                Console.WriteLine("2. Estacionar Carro");
                Console.WriteLine("3. Listar Carros Estacionados");
                Console.WriteLine("4. Calcular Valor do Estacionamento e Remover Carro");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                string escolha = Console.ReadLine();
                
                switch (escolha)
                {
                    case "1":
                        vagas.VeficarDisponibilidade();
                        break;
                    
                    case "2":
                        Console.Write("Digite a placa do carro: ");
                        string placa = Console.ReadLine();
                        Console.Write("Digite o modelo do carro: ");
                        string modelo = Console.ReadLine();
                        Console.Write("Digite o título da vaga onde deseja estacionar: ");
                        string tituloVaga = Console.ReadLine();

                        Carro carro = new Carro(placa, modelo);
                        vagas.EstacionarCarro(tituloVaga, carro);
                        break;
                    
                    case "3":
                        vagas.ListarCarrosEstacionados();
                        break;
                    
                    case "4":
                        Console.Write("Digite o bloco onde deseja calcular o valor e remover o carro: ");
                        string tituloVagaParaRemover = Console.ReadLine();
                        vagas.CalcularValorEstacionamento(tituloVagaParaRemover);
                        break;

                    case "5":
                        rodar = false;
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        
    }
}