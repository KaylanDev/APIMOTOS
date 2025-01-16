using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Motos.Model
{
    public class MotosM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50,MinimumLength =2)]
        public string? Modelo { get; set; }
        [Required]
        [Range(1, 3000)]
        public int Potencia { get; set; }
        [Required]
        [Range(1,100000)]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(400, MinimumLength = 2)]
        public string? Imagem { get; set; }



    }
}
