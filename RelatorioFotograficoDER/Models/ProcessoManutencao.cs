namespace RelatorioFotograficoDER.Models
{
    public class ProcessoManutencao
    {
        public int Id { get; set; }
        public int RelatoriofotograficoId { get; set; }
        public int CoordenacaoId { get; set; }
        public int RelatorioAtesteId { get; set; }
    }
}