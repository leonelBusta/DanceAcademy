using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dance_MVCRepository.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El genero es obligatorio")]
        public String Tipo { get; set; }//tipo de genero musical 

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "La descripcion  es obigatorio")]
        public String Descripcion { get; set; }//Descripcion



    }
}
