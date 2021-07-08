using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Drug
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vă rog introduceți un medicament")]
        [Display(Name = "Denumire")]

        public string Name { get; set; }
        [Display(Name="Prescurtare")]
        public string GenericName { get; set; }
        [Required(ErrorMessage = "Introduceți firma producătoare")]
        [Display(Name = "Nume Producător")]
        public string Producer { get; set; }
        [Required(ErrorMessage = "Adăugați modul de utilizare")]
        [Display(Name = "Cantitate")]

        public string Usage { get; set; }
        [Required(ErrorMessage = "Adăugați numărul de mg")]
        [Display(Name = "Modul de administrare")]

        public string Indications { get; set; }
        public virtual List<Therapy> Therapies { get; set; }

        public Drug()
        {
            Therapies = new List<Therapy>();
        }

    }
}