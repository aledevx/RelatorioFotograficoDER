namespace RelatorioFotograficoDER.Models
{
    public class RelatorioAtesteAnexo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public int RelatorioAtesteId { get; set; }
    }
}