namespace RelatorioFotograficoDER.Models
{
    public class OrcamentoEletronico
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Codigo { get; set; }
        public int PdfAnexoId { get; set; }
        public PdfAnexo PdfAnexo { get; set; }
    }
}