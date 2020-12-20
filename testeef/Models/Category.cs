using System.ComponentModel.DataAnnotations;

namespace testeef.Models
{
    public class Category
    {
        [Key]
        public int id{get; set;}

        [Required(ErrorMessage="Campo Obrigatorio")]
        public string title{get; set;}
    }
}