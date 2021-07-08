using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Introduceți numele și prenumele doctorului")]
        [Display(Name = "Nume Prenume")]
        public string NameSurName { get; set; }
        [Display(Name = "Vârstă")]
        [Required(ErrorMessage = "Adăugți vârsta")]
        [Range(18,80,ErrorMessage ="Introduceti o vârstă validă")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Introduceți sexul medicului")]
        [Display(Name = "Sex")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Adăugți număr de telefon")]
        [RegularExpression(@"(0\s\d{3}\s\d{3}\s\d{3})", ErrorMessage = "Numărul de telefon nu este valid. Ex: 0 743 333 333")]
        [Display(Name="Număr de telefon")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email")]
        [EmailAddress(ErrorMessage = "Email invalid")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Introduceți specializarea")]
        [Display(Name = "Specializare")]

        public string Specialty { get; set; }
        [Required(ErrorMessage = "Spitalul la care lucrează ")]
        [Display(Name = "Spital")]

        public string Hospital { get; set; }
        
        [Display(Name="Imagine doctor")]
        public string ImageUrl { get; set; }
        [Display(Name = "Detalii")]
        [Required(ErrorMessage = "Introduceți mai multe detalii despre medic")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public virtual List<Patient> Patients { get; set; }
        public List<Appointment> Appointments { get; set; }


        public Doctor()
        {
            this.Patients = new List<Patient>();
            Appointments = new List<Appointment>();
        }

   
  





    }
}