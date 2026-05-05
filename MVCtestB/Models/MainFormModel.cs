using System.ComponentModel.DataAnnotations;

namespace MVCtestB.Models
{
    public class MainFormModel
    {
        [Required(ErrorMessage ="Musi obsahovat jmeno!")]
        [RegularExpression(@"^[a-zA-Z]{5,}$",ErrorMessage ="Zadej jmeno ktere ma aspon 5 znaku")]
        public string Jmeno { get; set; }
        public double Castka { get; set; }
        public Kurzy kurz { get; set; }
        public string CisloUctu { get; set; }

    }
}
