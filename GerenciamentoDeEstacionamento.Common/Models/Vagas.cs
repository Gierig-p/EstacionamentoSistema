using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace GerenciamentoDeEstacionamento.Common.Models
{
    public class Vagas
    {
        private List<Vaga> listaVagas;
        private const double ValorInicial = 10.0;
        private const double ValorPorHora = 1.50;
        
        public Vagas()
        {
            listaVagas = new List<Vaga>
            {
                new Vaga("Bloco 1", false),
                new Vaga("Bloco 2", false),
                new Vaga("Bloco 3", false),
                new Vaga("Bloco 4", true),
                new Vaga("Bloco 5", false),
                new Vaga("Bloco 6", false),
                new Vaga("Bloco 7", false),
                new Vaga("Bloco 8", false),
                new Vaga("Bloco 9", true),
                new Vaga("Bloco 10", false),
                new Vaga("Bloco 11", false),
                new Vaga("Bloco 12", false),
            };
        }

        public void VeficarDisponibilidade()
        {
            Console.WriteLine("Você se encixa como PCD? ('S' para Sim ou 'N' para Não): ");
            string resposta = Console.ReadLine().ToUpper();

            bool clientePCD = resposta == "S";

            ListarVagasDisponiveis(clientePCD);
        }

        private void ListarVagasDisponiveis(bool clientePCD)
        {
            var vagasDiponiveis = listaVagas.Where(v => v.Disponivel &&(!clientePCD || v.ParaPCD)).ToList();

            if (vagasDiponiveis.Count == 0)
            {
                Console.WriteLine("Não há vagas disponíveis no momento.");
            }
            else
            {
                Console.WriteLine("Vagas disponíveis:");
                foreach (var vaga in vagasDiponiveis)
                {
                    Console.WriteLine($"- {vaga.Titulo} (PCD: {(vaga.ParaPCD ? "Sim" : "Não")})");
                }
            }

            ListarVagasIndisponiveis();
        }

        private void ListarVagasIndisponiveis()
        {
            var vagasIndisponiveis = listaVagas.Where(v => !v.Disponivel).ToList();

            if (vagasIndisponiveis.Count > 0)
            {
                Console.WriteLine("\n Vagas indiponíveis: ");
                foreach (var vaga in vagasIndisponiveis)
                {
                    Console.WriteLine($"- {vaga.Titulo}");
                }
            }
        }

        public void EstacionarCarro(string tituloVaga, Carro carro)
        {
            var vaga = listaVagas.FirstOrDefault(v => v.Titulo == tituloVaga && v.Disponivel);
            if (vaga != null)
            {
                vaga.CarroEstacionado = carro;
                vaga.Disponivel = false;
                Console.WriteLine($"O carro {carro.ModeloDoCarro} (Placa: {carro.Placa}) está estacionado na vaga {vaga.Titulo}.");
            }
            else
            {
                Console.WriteLine("Vaga não disponível ou já ocupada.");
            }
        }

        public void ListarCarrosEstacionados()
        {
            var vagasComCarros = listaVagas.Where(v => v.CarroEstacionado != null).ToList();

            if (vagasComCarros.Count == 0)
            {
                Console.WriteLine("Não há carros estacionados.");
            }
            else
            {
                Console.WriteLine("Carros estacionados:");
                foreach (var vaga in vagasComCarros)
                {
                    Console.WriteLine($"- Vaga {vaga.Titulo}: {vaga.CarroEstacionado.Placa} - (Modelo do carro: {vaga.CarroEstacionado.ModeloDoCarro})");
                }
            }
        }

        public void CalcularValorEstacionamento(string tituloVaga)
        {
            var vaga = listaVagas.FirstOrDefault(v => v.Titulo == tituloVaga && !v.Disponivel && v.CarroEstacionado != null);
            if (vaga != null)
            {
                Console.WriteLine("Quantas horas o cliente passou estacionado?");
                int horas;
                while (!int.TryParse(Console.ReadLine(), out horas) || horas < 0)
                {
                    Console.WriteLine("Por favor, insira um número válido de horas.");
                }

                double valorTotal = ValorInicial + (horas * ValorPorHora);
                Console.WriteLine($"O valor total a pagar é: R${valorTotal:F2}");

                Console.WriteLine("O pagamento foi efetuado? (Digite 'S') para Sim ou 'N' para Não");
                string pagamento = Console.ReadLine().ToUpper();

                if (pagamento == "S")
                {
                    RemoverCarro(vaga);
                    Console.WriteLine("O pagamento já foi efetuado, O carro já pode ser retirado.");
                }
                else
                {
                    Console.WriteLine("Pagamento não efetuado. O carro não foi liberado");
                }
            }
            else
            {
                Console.WriteLine("Vaga não encontada ou não há carro estacionado.");
            }
        }
        public void RemoverCarro(Vaga vaga)
        {
            vaga.CarroEstacionado = null;
            vaga.Disponivel = true;
        }
        public void AlterarDisponibilidade(string titulo, bool disponivel)
        {
            var vaga = listaVagas.FirstOrDefault(v => v.Titulo == titulo);
            if (vaga != null)
            {
                vaga.Disponivel = disponivel;
                Console.WriteLine($"Disponibilidade da vaga {titulo} atualizada para {(disponivel ? "disponível" : "indisponível")}.");   
            }
            else
            {
                Console.WriteLine("Vaga não encontrada.");
            }
        }
    }
}