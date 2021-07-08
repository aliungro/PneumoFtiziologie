using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Introduceți data")]
        [Display(Name = "Dată")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Selectați un pacient")]
        [Display(Name ="Patient")]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Selectați un doctor")]
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }


        [Required(ErrorMessage = "Introduceți ora")]
        [Display(Name = "Ora")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public string FromTime { get; set; }


        [Display(Name = "Pacient")]
        public Patient Patient { get; set; }
        [Display(Name = "Doctor")]
        public Doctor Doctor { get; set; }

       [Display(Name ="A mai fost")]
        public bool HasOccured { get; set; }



    }
}