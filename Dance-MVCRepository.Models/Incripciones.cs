using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dance_MVCRepository.Models
{
    public class Incripciones
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Folio es obligatorio")]
        public String Folio { get; set; }//folio

        //relacion con el aprendiz
        [Required(ErrorMessage = "Debes seleccionar un Aprendiz para el curso")]
        [Display(Name = "Aprendices")]
        public int Aprendices_Id { get; set; }

        [ForeignKey("Aprendices_Id")]
        public Aprendices AprObj { get; set; }

        //relacion con el instructor 
        [Required(ErrorMessage = "Debes seleccionar un Instructor  para el curso")]
        [Display(Name = "Instructores")]
        public int Instructores_Id { get; set; }

        [ForeignKey("Instructores_Id")]
        public Instructores InsObj { get; set; }

        //relacion con la direccion
        [Required(ErrorMessage = "Debes seleccionar una direccion para el curso")]
        [Display(Name = "Direccion")]
        public int Direccion_Id { get; set; }

        [ForeignKey("Direccion_Id")]
        public Direccion DirObj { get; set; }

        //relacion con los generos 
        [Required(ErrorMessage = "Debes seleccionar un Genero para el curso")]
        [Display(Name = "Genero")]
        public int Genero_Id { get; set; }

        [ForeignKey("Genero_Id")]
        public Genero GenObj { get; set; }

    }
}
