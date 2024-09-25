using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeEstacionamento.Common.Models
{
    public class Vaga
    {
        public string Titulo { get; set; }
        public bool Disponivel { get; set; }
        public bool ParaPCD { get; set; }
        public Carro CarroEstacionado { get; set; }

        public Vaga(string titulo, bool paraPCD)
        {
            Titulo = titulo;
            ParaPCD = paraPCD;
            Disponivel = true;
            CarroEstacionado = null;

        }
    }
}
