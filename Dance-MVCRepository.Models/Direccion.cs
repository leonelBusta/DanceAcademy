using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dance_MVCRepository.Models
{
    public class Direccion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La Calle es obligatorio")]
        public String Calle { get; set; }//direccion

        [Display(Name = "Numero")]
        [Required(ErrorMessage = "El numero es obigatorio")]
        public int Numero { get; set; }//

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "La Ciudad es obligatorio")]
        public String Ciudad { get; set; }//#

        [Display(Name = "Colonia")]
        [Required(ErrorMessage = "La Colonia es obligatorio")]
        public String Colonia { get; set; }//#

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Estado es obligatorio")]
        public String Estado { get; set; }//#
    }
}
