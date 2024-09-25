using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeEstacionamento.Common.Models
{
    public class Carro
    {
        public string Placa { get; set; }

        public string ModeloDoCarro { get; set; }

        public Carro(string placa, string modeloDoCarro)
        {
            Placa = placa;
            ModeloDoCarro = modeloDoCarro;
        }

        public override string ToString()
        {
            return $"{Placa} - (Modelo do carro: {ModeloDoCarro})";
        }
    }
}