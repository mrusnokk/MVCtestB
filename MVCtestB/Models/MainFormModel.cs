using System.ComponentModel.DataAnnotations;

namespace MVCtestB.Models
{
    public class MainFormModel
    {
        [Required(ErrorMessage ="Musi obsahovat jmeno!")]
        [RegularExpression(@"^[a-zA-Z]{5,}$",ErrorMessage ="Zadej jmeno ktere ma aspon 5 znaku")]
        public string Jmeno { get; set; }
        [Required(ErrorMessage ="Castka je povinna!")]
        public double Castka { get; set; }
        [Required(ErrorMessage = "Kurz je povinny!")]
        public string penize { get; set; }
        [Required(ErrorMessage = "Cislo uctu je povinne!")]
        [RegularExpression(@"^\d{1,6}-\d{2,10}/\d{4}$", ErrorMessage ="Musis zadat ........")]
        public string CisloUctu { get; set; }

    }
}
