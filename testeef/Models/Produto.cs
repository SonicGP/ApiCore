using System.ComponentModel.DataAnnotations;

namespace testeef.Models
{
    public class Produto
    {
        [Key]
        public int id{get; set;}

        [Required(ErrorMessage="Campo obvrigatorio")]
        public string title{get; set;}

        public string descripiton {get; set;}

        public decimal price{get; set;}

        [Required(ErrorMessage="Campo Obrigatorio")]
        public int CategoryId {get; set;}

        public Category category {get; set;}
    }
}