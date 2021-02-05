using System.ComponentModel.DataAnnotations;

namespace CrudApi.Dtos
{
    public class NuevoClientDto
    {
        [Required]
        public string NombeCliente { get; set; }

        [Required]
        [StringLength(20,MinimumLength=10,ErrorMessage="You must specify a correct phone number")]
        public string Telefono { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [StringLength(15,MinimumLength=13,ErrorMessage="You must specify a correct RFC")]
        public string RFC { get; set; }
    }
}