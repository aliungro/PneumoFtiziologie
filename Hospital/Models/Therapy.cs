using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Therapy
    {
        public int Id { get; set; }
        [Required]
        public int DrugId { get; set; }

        [Required(ErrorMessage = "Adăugți data de începere a tratamentului")]

        [Display(Name = "De la")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }
        [Required(ErrorMessage = "Adăugți data de încheiere a tratamentului")]
        [Display(Name = "Până la")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        [Display(Name = "Diagnostic")]
        public string Diagnose { get; set; }
        
        public int PatientId { get; set; }
        
        public Patient Patient { get; set; }
        

    }
}