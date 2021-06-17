namespace RelatorioFotograficoDER.Models
{
    public class RelatorioFotograficoAnexo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public int RelatorioAtesteId { get; set; }
    }
}