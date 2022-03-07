using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFutbolistas.Entidades
{
    public class Futbolista
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:6, ErrorMessage = "El campo {0} solo puede tener hasta 6 caracteres")]
        public string Nombre { get; set; } 

        [Range(18,100,ErrorMessage = "El campo Edad no se encuentra dentro del rango")]
        [NotMapped]
        public int Edad { get; set; }

        [CreditCard]
        [NotMapped]
        public string Credencial { get; set; }


        [NotMapped]
        public string Genero { get; set; }

        [Url]
        [NotMapped]
        public string Url { get; set; }


        public List<Equipo> equipos { get; set; }
    }
}
