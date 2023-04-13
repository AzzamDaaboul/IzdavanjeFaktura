using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace IzdavanjeFaktura.Models
{
    public class FakturaStavka
    {
        public FakturaStavka()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Broj stavke")]
        public int BrojStavke { get; set; }

        [Required]
        [Display(Name = "Kolicina prodane stavke")]
        public int KolicinaProdaneStavke { get; set; }

        //[DisplayFormat(DataFormatString = "{0:0.000}", ApplyFormatInEditMode = true)]
        //[Column(TypeName = "smallmoney")]
        [Required]
        [Display(Name = "Jedinicna cijena stavke bez poreza")]
        public int JedinicnaCijenaStavkeBezPoreza { get; set; }

        //[DisplayFormat(DataFormatString = "{0:0.000}", ApplyFormatInEditMode = true)]
        //[Column(TypeName = "smallmoney")]
        [Required]
        [Display(Name = "Ukupna cijena stavke bez poreza")]
        public int UkupnaCijenaStavkeBezPoreza { get; set; }

        [ForeignKey("Faktura")]
        public int FakturaId { get; set; }
        public virtual Faktura Faktura { get; set; }

        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}
