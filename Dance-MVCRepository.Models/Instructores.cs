using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dance_MVCRepository.Models
{
    public class Instructores
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public String Nombre { get; set; }//nombre

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "El apellido es obigatorio")]
        public String ApPaterno { get; set; }//apPaterno

        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage ="El apellido materno es obligatorio")]
        public String ApMaterno { get; set; }//apMaterno

        [Display(Name = "Foto instrutor")]
        [DataType(DataType.ImageUrl)]
        public String UrlFoto { get; set; }//foto

        [Display(Name = "Codigo Instructor")]
        [Required(ErrorMessage = "El codigo del instructor es obligatorio")]
        [MaxLength(7)]
        [RegularExpression(@"^[a-zA-Z]{2}-[0-9]{4}$", ErrorMessage = "el formato es XX-0000")]

        public String CodigoInstructor { get; set; }

    }//end class
}
