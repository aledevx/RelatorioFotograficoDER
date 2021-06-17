using System;

namespace RelatorioFotograficoDER.Models
{
    public class Coordenacao
    {
        public int Id { get; set; }
        public int OrcamentoeletronicoId { get; set; }
        public int RelacaoOrcamentoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataEnvio { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}