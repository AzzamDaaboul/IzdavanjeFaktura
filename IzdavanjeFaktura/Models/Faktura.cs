using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace IzdavanjeFaktura.Models
{
    public class Faktura
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Broj fakture")]
        public int BrojFakture { get; set; }

        [Required]
        [Display(Name = "Datum stvaranja fakture")]
        public DateTime DatumStvaranjaFakture { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Datum dospijeca fakture")]
        public DateTime DatumDospijecaFakture { get; set; } = DateTime.Now;

        //[DisplayFormat(DataFormatString = "{0:0.000}", ApplyFormatInEditMode = true)]
        //[Column(TypeName = "smallmoney")]
        [Required]
        [Display(Name = "Ukupna cijena bez poreza")]
        public int UkupnaCijenaBezPoreza { get; set; }

        //[DisplayFormat(DataFormatString = "{0:0.000}", ApplyFormatInEditMode = true)]
        //[Column(TypeName = "smallmoney")]
        [Required]
        [Display(Name = "Ukupna cijena sa porezom")]
        public decimal UkupnaCijenaSaPorezom { get; set; }

        [Required(ErrorMessage = "Stvaratelj računa polje je obavezno.")]
        [Display(Name = "Stvaratelj računa")]
        public string StvarateljRacuna { get; set; } = "";

        [Required(ErrorMessage = "Primatelj računa polje je obavezno.")]
        [Display(Name = "Primatelj računa")]
        public string PrimateljRacuna { get; set; } = "";

        public virtual List<FakturaStavka> FakturaStavki { get; set; } = new List<FakturaStavka>();

    }
}
