using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Adăugați numele și prenumele pacientului")]
        [Display(Name ="Nume Prenume")]
        public string NameSurName { get; set; }
      
        [Required(ErrorMessage = "Vârsta")]
        [Range(0,150, ErrorMessage ="Vârsta nu este validă") ]
        [Display(Name = "Vârsta")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Selectați sexul pacientului")]
        [Display(Name = "Sex")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Ziua de naștere")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name="Zi de naștere")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Adăugați adresa")]
     
        public string Address { get; set; }
        [Required(ErrorMessage = "Adăugați un număr de telefon")]
        [RegularExpression(@"(\+48\s\d{3}\s\d{3}\s\d{3})", ErrorMessage = "Numărul de telefon nu este valid")]
        [Display(Name="Număr de telefon")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Adăugați adresa de email")]
        [EmailAddress(ErrorMessage ="Adăugați o adresă de email validă")]
        [Display(Name="E-mail")]
        public string Email { get; set; }
        [Display(Name = "Tipul de sânge")]

        public string BloodType { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Alergii")]
        public string Allergies { get; set; }
        [Display(Name = "Istoric medical")]
        [DataType(DataType.MultilineText)]
        public string HistoryOfDiseases { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Therapy> Therapies { get; set; }

        public Patient()
        {
            this.Doctors = new List<Doctor>();
            Appointments = new List<Appointment>();
            Therapies = new List<Therapy>();
        }


       


    }
}