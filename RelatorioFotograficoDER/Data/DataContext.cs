using Microsoft.EntityFrameworkCore;
using RelatorioFotograficoDER.Models;

namespace RelatorioFotograficoDER.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<RelatorioFotografico> RelatorioFotograficos { get; set; }
        public DbSet<RelatorioAteste> RelatorioAtestes { get; set; }
        public DbSet<RelatorioFotograficoAnexo> RelatorioFotograficoAnexos { get; set; }
        public DbSet<RelatorioAtesteAnexo> RelatorioAtesteAnexos { get; set; }
        public DbSet<PdfAnexo> PdfAnexos { get; set; }
        public DbSet<OrcamentoEletronico> OrcamentoEletronicos { get; set; }
        public DbSet<RelacaoOrcamento> RelacaoOrcamentos { get; set; }
        public DbSet<Coordenacao> Coordenacaos { get; set; }
        public DbSet<ProcessoManutencao> ProcessoManutencaos { get; set; }

    }
}