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
                        string placa;
                        do
                        {
                            Console.Write("Digite a placa do carro: ");
                            placa = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(placa))
                            {
                                Console.WriteLine("Placa não pode estar vazia. Por favor, insira uma placa válida.");
                            }
                        } while(string.IsNullOrWhiteSpace(placa));

                        string modelo;
                        do
                        {
                            Console.Write("Digite o modelo do carro: ");
                            modelo = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(modelo))
                            {
                                Console.WriteLine("Modelo não pode estar vazio. Por favor, insira um modelo válido.");
                            }
                        } while(string.IsNullOrWhiteSpace(modelo));

                        string tituloVaga;
                        do
                        {
                            Console.Write("Digite o título da vaga onde deseja estacionar: ");
                            tituloVaga = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(tituloVaga))
                            {
                                Console.WriteLine("Título da vaga não pode estar vazio. Por favor, insira um título válido.");
                            }
                        } while (string.IsNullOrWhiteSpace(tituloVaga));

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