using System;

namespace RelatorioFotograficoDER.Models
{
    public class RelatorioAteste
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public DateTime DataAprovacao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}