using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dance_MVCRepository.Models
{
    public class Aprendices
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public String Nombre { get; set; }//nombre

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "El apellido es obigatorio")]
        public String ApPaterno { get; set; }//apPaterno

        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "El apellido materno es obligatorio")]
        public String ApMaterno { get; set; }//apMaterno

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "La edad es obligatorio")]
        public int Edad { get; set; }//Edad

        [Display(Name = "Foto instrutor")]
        [DataType(DataType.ImageUrl)]
        public String UrlFoto { get; set; }//foto
    }
}
