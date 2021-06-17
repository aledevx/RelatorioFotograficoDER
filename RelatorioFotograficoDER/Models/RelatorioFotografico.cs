using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;


namespace RelatorioFotograficoDER.Models
{
    public class RelatorioFotografico
    {
        public int Id { get; set; }
        public string Setor { get; set; }
        [Display(Name = "Veículo")]
        public string Veiculo { get; set; }
        [Display(Name = "Nº de Orçamento")]
        public string NumOrcamento { get; set; }
        [Display(Name = "Cartão")]
        public string Cartao { get; set; }      
        public string Placa { get; set; }
        [Display(Name = "Patrimônio")]
        public string Patrimonio { get; set; }
        [Display(Name = "Km/H")]
        public string Kmh { get; set; }
        public int Ano { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }
        public string Email { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public System.DateTime? DataInicio { get; set; }
        public System.DateTime? DataEnvio { get; set; }
        public System.DateTime? DataAtualizacao { get; set; }
        public ICollection<RelatorioFotograficoAnexo> Fotos { get; set; }

    }
}