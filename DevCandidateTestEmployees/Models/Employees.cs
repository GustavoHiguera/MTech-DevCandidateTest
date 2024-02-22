
namespace DevCandidateTestEmployees.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employees
    {
        [Display(Name = "#")]
        public int ID { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Display(Name = "RFC")]
        [Required(ErrorMessage = "RFC is required")]
        [Attributes.MexicanRFCAttribute(ErrorMessage = "RFC format is not valid.")]
        [Attributes.UniqueRFCAttribute(ErrorMessage = "The RFC is already registred.")]
        public string RFC { get; set; }
        [Display(Name = "Born date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Born date is required")]
        public System.DateTime BornDate { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is required")]
        public int Status { get; set; }
    }


}
